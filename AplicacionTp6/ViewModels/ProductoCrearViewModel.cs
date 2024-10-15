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
    public partial class ProductoCrearViewModel:BaseViewModel
    {
        public ObservableCollection<Producto> Productos { get; } = new();


        
        [ObservableProperty]
        Producto nuevoProducto = new Producto();  

        IProductoService _productoService;

        public ProductoCrearViewModel(IProductoService productoService)
        {
            Title = "Crear Producto";
            _productoService = productoService;
            NuevoProducto = new Producto();
        }

        
        [RelayCommand]
        private async Task CrearProductoAsync()
        {
            if (string.IsNullOrWhiteSpace(nuevoProducto?.nombreProducto) || nuevoProducto?.precioProducto <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Advertencia", "Complete todos los campos correctamente.", "Ok");
                return;
            }

            try
            {
                var productoCreado = await _productoService.CreateProductAsync(nuevoProducto);

                if (productoCreado != null)
                {
                    Productos.Add(productoCreado);
                    await App.Current.MainPage.DisplayAlert("Éxito", "Producto creado correctamente.", "Ok");
                    NuevoProducto = new Producto();
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
