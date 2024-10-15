using AplicacionTp6.Models;
using AplicacionTp6.Services;
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
    public partial class UsuarioCrearViewModel: BaseViewModel
    {
        public ObservableCollection<Usuario> Usuarios{ get; } = new();

        [ObservableProperty]
        Usuario nuevoUsuario = new Usuario();

        IUsuarioService _usuarioService;

        public UsuarioCrearViewModel(IUsuarioService usuarioService)
        {
            Title = "Crear Producto";
            _usuarioService = usuarioService;
            NuevoUsuario = new Usuario();
        }

        [RelayCommand]
        private async Task CrearUsuarioAsync()
        {
            if (string.IsNullOrWhiteSpace(nuevoUsuario?.nombreUsuario) || nuevoUsuario?.numTelefono <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Complete todos los campos correctamente.", "Ok");
                return;
            }

            try
            {
                var productoCreado = await _usuarioService.CreateUserAsync(nuevoUsuario);

                if (productoCreado != null)
                {
                    Usuarios.Add(productoCreado);
                    await App.Current.MainPage.DisplayAlert("Éxito", "Producto creado correctamente.", "Ok");
                    NuevoUsuario = new Usuario();
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No se pudo crear el producto", "Ok");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }
        }


    }
}
