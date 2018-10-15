using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Healthcare.DataAccess
{
    public static class DatabaseHelper
    {
        private static string connectionString;
        private static object home_address;
        private static object gender;
        private static object birthday;
        private static object lastname;
        private static object firstname;

        static DatabaseHelper()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                connectionString = appSettings["DbConnetionString"];
            }
            catch (ConfigurationErrorsException)
            {
                
            }
        }

        public static void EnsureDatabaseExists()
        {
            if (CheckDatabaseExists("Therapist") == false)
            {
                CreateDatabase("Therapist");
            }
        }

        private static void CreateDatabase(string databaseName)
        {
            try
            {
                if (File.Exists("CreateDatabase.sql"))
                {
                    string sqlCreateDBQuery =  File.ReadAllText("CreateDatabase.sql");

                    sqlCreateDBQuery = sqlCreateDBQuery.Replace("[Therapist]", string.Format("[{0}]", databaseName));
                    sqlCreateDBQuery = sqlCreateDBQuery.Replace("Терапевт.mdf", string.Format("{0}.mdf", databaseName));
                    sqlCreateDBQuery = sqlCreateDBQuery.Replace("Терапевт_log.ldf", string.Format("{0}_log.ldf", databaseName));

                    using (SqlConnection tmpConn = new SqlConnection("server=(local);Trusted_Connection=yes"))
                    {
                        using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                        {
                            tmpConn.Open();

                            string sqlBatch = string.Empty;

                            foreach (string line in sqlCreateDBQuery.Split(new string[2] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (line.ToUpperInvariant().Trim() == "GO")
                                {
                                    sqlCmd.CommandText = sqlBatch;
                                    sqlCmd.ExecuteNonQuery();
                                    sqlBatch = string.Empty;
                                }
                                else
                                {
                                    sqlBatch += line + "\n";
                                }
                            }
                            sqlCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
           
            }
        }

        private static bool CheckDatabaseExists(string databaseName)
        {
            bool result = false;

            try
            {
                using (SqlConnection tmpConn = new SqlConnection("server=(local);Trusted_Connection=yes"))
                {
                    string sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);

                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }
                        
                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public static List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();

            try
            {
                using (var connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = string.Format("SELECT [PatientId], [LastName], [FirstName], [Birthday], [Gender], [Home_address] FROM [Patients]");
                    command.Connection = connection;

                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var patient = new Patient()
                            {
                                PatientId = (int)reader.GetValue(0),
                                LastName = (string)reader.GetValue(1),
                                FirstName = (string)reader.GetValue(2),
                                Birthday = (string)reader.GetValue(3),
                                Gender = (string)reader.GetValue(4),
                                Home_address = (string)reader.GetValue(5)
                            };
                            patients.Add(patient);
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }

            return patients;
        }

        public static Patient CreatePatient(string firstname, string lastname, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                using (var connection = GetConnection())
                {
                    SqlTransaction sqlTransaction = connection.BeginTransaction();

                    try
                    {
                        SqlCommand command = new SqlCommand();
                        command.CommandText = string.Format("INSERT INTO Patients (LastName, FirstName, Birthday, Gender, Home_address) VALUES (@LastName, @FirstName, @Birthday, @Gender, @Home_address); select scope_identity()");
                        command.Connection = connection;
                        command.Transaction = sqlTransaction;

                        command.Parameters.AddWithValue("@LastName", lastname);
                        command.Parameters.AddWithValue("@FirstName", firstname);
                        command.Parameters.AddWithValue("@Birthday",birthday);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Home_address", home_address);

                        object result = command.ExecuteScalar();
                        int patientId = (int)((decimal)result);

                        sqlTransaction.Commit();

                        return new Patient()
                        {
                            PatientId = patientId,
                            LastName = lastname,
                            FirstName = firstname,
                            Birthday = (string)birthday,
                            Gender = (string)gender,
                            Home_address = (string)home_address
                        };
                    }
                    catch (Exception)
                    {
                        sqlTransaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool UpdatePatient(int patientId, string firstName, string lastName, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                using (var connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = string.Format("UPDATE Patients SET LastName = @LastName, FirstName = @FirstName, Birthday = @Birthday, Gender = @Gender, Home_address = @Home_address WHERE PatientId = @PatientId");
                    command.Connection = connection;

                    command.Parameters.AddWithValue("@LastName", lastname);
                    command.Parameters.AddWithValue("@FirstName", firstname);
                    command.Parameters.AddWithValue("@Birthday", birthday);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Home_address", home_address);

                    int total = command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static bool Login(string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            using (var connection = GetConnection())
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = string.Format("SELECT Username FROM [Accounts] WHERE Username='{0}' AND Password = '{1}'", username, password);
                command.Connection = connection;

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //object user = reader.GetValue(0);

                            return true;
                        }
                    }
                    else
                    {
                        errorMessage = "Ошибка, пользователь с таким паролем не найден";
                        return false;
                    }
                }
                catch (Exception)
                {
                    
                }
            }

            return false;
        }

        public static bool Register(string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                using (var connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("RegisterProcedure", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@username",
                        Value = username,
                        Size = 50
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@password",
                        Value = password,
                        Size = 50
                    });
                    command.Parameters.Add("@errorMessage", SqlDbType.NVarChar).Direction = ParameterDirection.Output;
                    command.Parameters["@errorMessage"].Size = 500;
                    var result = command.ExecuteNonQuery();

                    errorMessage = (string)(command.Parameters["@errorMessage"].Value);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
