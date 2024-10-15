using AplicacionTp6.ViewModels;
namespace AplicacionTp6.Views;

public partial class LoginPage : ContentPage
{
    private LoginViewModel viewModel;
    public LoginPage()
    {
        BindingContext = viewModel = new LoginViewModel();
        InitializeComponent();
    }
}