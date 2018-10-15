using Healthcare.DataAccess;
using System.Windows.Input;

namespace DoctorApp
{
    public class RegisterContext : DataContextBase
    {
        private string password;
        private string login;
        private string confirmPassword;
        private bool? dialogResult;

        public string Login
        {
            get { return login; }
            set
            {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged("Login");
                }
            }
        }
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                if (confirmPassword != value)
                {
                    confirmPassword = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

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

        public ICommand RegisterCommand { get; set; }

        public RegisterContext()
        {
            RegisterCommand = new MyCommand(RegisterCommandExecute, RegisterCommandCanExecute);
        }

        private bool RegisterCommandCanExecute()
        {
            return !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(login)
                && !string.IsNullOrEmpty(confirmPassword) && Password == confirmPassword;
        }

        private void RegisterCommandExecute()
        {
            string errorMessage;
            if (DatabaseHelper.Register(Login, Password, out errorMessage))
            {
                DialogResult = true;
            }
            else
            {
                // вывести текст ошибки errorMessage
            }
        }
    }
}
