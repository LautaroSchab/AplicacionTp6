using AplicacionTp6.Views;

namespace AplicacionTp6
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //MainPage = new ProductoListaPage();
            //MainPage = new LoginPage();
            //MainPage = new Mainpage();
            MainPage = new NavigationPage(new LoginPage());

            //MainPage = new UsuarioListaPage();
        }
    }
}
