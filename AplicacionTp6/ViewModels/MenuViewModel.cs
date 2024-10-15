using AplicacionTp6.Models;
using AplicacionTp6.Services;
using AplicacionTp6.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;

namespace AplicacionTp6.ViewModels;
public partial class MenuViewModel: BaseViewModel
{
    [RelayCommand]
    public async Task GoToUsuarioLista()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new UsuarioListaPage());
    }

    [RelayCommand]
    public async Task GoToProductoLista()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new ProductoListaPage());
    }

    [RelayCommand]
    public async Task GoToAcerca()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new AcercaDePage());
    }

    [RelayCommand]
    public async Task Exit()
    {
        await OnSalirButtonClicked();
    }

    private async Task OnSalirButtonClicked()
    {
        bool respuesta = await Application.Current.MainPage.DisplayAlert("Salir", "¿Desea terminar la sesión y salir?", "Aceptar", "Cancelar");

        if (respuesta)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }

}

