using Healthcare.DataAccess;
using System.Windows;

namespace DoctorApp
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            MainWindow = new MainWindow();

            DatabaseHelper.EnsureDatabaseExists();

            var loginWindow = new LoginWindow();
            var result = loginWindow.ShowDialog();

            if (result.HasValue && result.Value == true)
            {
                MainWindow.Show();
            }
            else
            {
                Shutdown();
            }
        }
    }
}
