using System;
using System.Windows.Input;

namespace DoctorApp
{
    public class MainDataContext : DataContextBase
    {
        public MainDataContext()
        {
            OpenPatientsCommand = new MyCommand(OpenPatientsCommandExecute);
        }


        public INavigation Navigation { get; set; }

        public ICommand OpenPatientsCommand { get; set; }

        private void OpenPatientsCommandExecute()
        {
            Navigation.NavigateTo("PatientsPage");
        }
    }
}
