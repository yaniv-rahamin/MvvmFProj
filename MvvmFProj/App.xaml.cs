using MvvmFProj.Views;

namespace MvvmFProj
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new RegistrationPage();
        }
    }
}
