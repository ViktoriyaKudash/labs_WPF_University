using Healthcare.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DoctorApp
{
    public class PatientsDataContext : DataContextBase
    {
        private Patient selectedPatient;

        public PatientsDataContext()
        {
            AddPatientCommand = new MyCommand(AddPatient);
            EditPatientCommand = new MyCommand(EditPatient, CanEditPatient);

            Patients = new ObservableCollection<Patient>(DatabaseHelper.GetPatients());
        }

        public ICommand AddPatientCommand { get; set; }
        public ICommand EditPatientCommand { get; set; }

        public Patient SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                if (selectedPatient != value)
                {
                    selectedPatient = value;
                    OnPropertyChanged("SelectedPatient");
                }
            }
        }

        public ObservableCollection<Patient> Patients { get; set; }

        private void AddPatient()
        {
            var window = new PatientWindow();
            var dataContext = new PatientDataContext();
            window.DataContext = dataContext;
            if (window.ShowDialog() == true)
            {
                Patients.Add(dataContext.Patient);
            }
        }

        private bool CanEditPatient()
        {
            return SelectedPatient != null;
        }

        private void EditPatient()
        {
            var window = new PatientWindow();
            var dataContext = new PatientDataContext(SelectedPatient);
            window.DataContext = dataContext;
            window.ShowDialog();
        }
    }
}
