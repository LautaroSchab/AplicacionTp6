using AplicacionTp6.Services;
using AplicacionTp6.ViewModels;

namespace AplicacionTp6.Views;

public partial class UsuarioListaPage : ContentPage
{
	public UsuarioListaPage()
	{
        UsuarioService service = new UsuarioService();
        UsuarioListaViewModel vm = new UsuarioListaViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as UsuarioListaViewModel;

        if (vm != null)
        {
            await vm.GetUsuariosCommand.ExecuteAsync(null);
        }
    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PopAsync();
    }
}