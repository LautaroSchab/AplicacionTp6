using AplicacionTp6.Models;
using AplicacionTp6.Services;
using AplicacionTp6.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;


namespace AplicacionTp6.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    [ObservableProperty] private string username = string.Empty;
    [ObservableProperty] private string contrasena = string.Empty;
    [ObservableProperty] private string message = string.Empty;

    
    [RelayCommand]
    public async Task LoginAsync()
    {
        if (!IsBusy)
        {
            IsBusy = true;

            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Contrasena))
            {
                var apiClient = new ApiService();

                try
                {
                    var login = await apiClient.ValidarLogin(Username, Contrasena);

                    
                    Transport.IdUsuario = login.IdUsuario;
                    Transport.NombreUsuario = login.NombreUsuario;
                    Transport.Mail = login.Mail;

                    
                    await Application.Current.MainPage.DisplayAlert("Exito", "ha ingresado correctamente", "Aceptar");

                    
                    await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Atención", "Las credenciales son incorrectas", "Aceptar");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Atención", "Las credenciales son obligatorias. Verifique!", "Aceptar");
            }

            IsBusy = false;
        }
    }

}

