using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DoctorApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var dataContext = new MainDataContext();
            DataContext = dataContext;

            dataContext.Navigation = mainFrame;
        }
    }

    public interface INavigation
    {
        void NavigateTo(string page);
    }

    public class MyFrame : Frame, INavigation
    {
        public void NavigateTo(string page)
        {
            switch (page)
            {
                case "PatientsPage":
                    Navigate(new PatientsUserControl());
                    break;

                default:
                    break;
            }
        }
    }
}
