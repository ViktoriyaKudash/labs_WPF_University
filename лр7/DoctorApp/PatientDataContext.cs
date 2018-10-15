using Healthcare.DataAccess;
using System.Windows.Input;

namespace DoctorApp
{
    public class PatientDataContext : DataContextBase
    {
        private bool? dialogResult;
        private string firstName;
        private string lastName;
        private string okButtonText;

        public PatientDataContext()
        {
            AddCommand = new MyCommand(Add, CanAdd);

            OkButtonText = "Add";
        }

        public PatientDataContext(Patient patient)
            : this()
        {
            FirstName = patient.FirstName;
            LastName = patient.LastName;

            Patient = patient;

            OkButtonText = "Save";
        }

        public ICommand AddCommand { get; set; }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string OkButtonText
        {
            get { return okButtonText; }
            set
            {
                if (okButtonText != value)
                {
                    okButtonText = value;
                    OnPropertyChanged("OkButtonText");
                }
            }
        }

        public Patient Patient { get; set; }

        public bool? DialogResult
        {
            get { return dialogResult; }
            set
            {
                if (dialogResult != value)
                {
                    dialogResult = value;
                    OnPropertyChanged("DialogResult");
                }
            }
        }

        private bool CanAdd()
        {
            return string.IsNullOrEmpty(LastName) == false;
        }

        private void Add()
        {
            if (Patient == null)
            {
                Patient = DatabaseHelper.CreatePatient(FirstName, LastName, out string errorMessage);

                if (string.IsNullOrEmpty(errorMessage))
                {
                    DialogResult = true;
                }

                Patient = null;
            }
            else
            {
                if (DatabaseHelper.UpdatePatient(Patient.PatientId, FirstName, LastName, out string errorMessage))
                {
                    Patient.LastName = LastName;
                    Patient.FirstName = FirstName;

                    Patient.OnPropertyChanged();

                    DialogResult = true;
                }
            }
        }
    }
}
