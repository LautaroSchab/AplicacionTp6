using AplicacionTp6.Models;
using AplicacionTp6.Services;
using AplicacionTp6.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTp6.ViewModels
{
    public partial class UsuarioListaViewModel:BaseViewModel
    {
        public ObservableCollection<Usuario> Usuarios { get; } = new();

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        Usuario usuarioSeleccionado;

        IUsuarioService _usuarioService;

        public UsuarioListaViewModel(IUsuarioService usuarioService)
        {
            Title = "Lista de Usuarios";
            _usuarioService = usuarioService;
        }


        [RelayCommand]
        private async Task GetUsuariosAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    
                    var usuarios = await _usuarioService.GetUsersAsync();

                    if (usuarios != null)
                    {
                        if (Usuarios.Count != 0)
                            Usuarios.Clear();

                        foreach (var users in usuarios)
                            Usuarios.Add(users);
                    }

                    IsBusy = false;
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
                }
                finally
                {
                    IsBusy = false;
                }

            }
        }

        
        [RelayCommand]
        private async Task GoToDetail()
        {
            if (usuarioSeleccionado == null)
            {
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioDetallePage(usuarioSeleccionado), true);
        }
        
        [RelayCommand]
        public async Task GoToCrearUsuario()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsuarioCrearPage());
        }

       
    }
}
