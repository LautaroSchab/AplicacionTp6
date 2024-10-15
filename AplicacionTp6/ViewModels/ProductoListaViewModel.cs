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
    public partial class ProductoListaViewModel : BaseViewModel
    {
        public ObservableCollection<Producto> Productos { get; } = new();

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        Producto productoSeleccionado;

        IProductoService _productoService;


        public ProductoListaViewModel(IProductoService productoService)
        {
            Title = "Lista de Productos";
            _productoService = productoService;
        }

        [RelayCommand]
        private async Task GetProductosAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;

                    
                    var productos = await _productoService.GetProductsAsync();

                    if (productos != null)
                    {
                        if (Productos.Count != 0)
                            Productos.Clear();

                        foreach (var producto in productos)
                            Productos.Add(producto);
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
            if (productoSeleccionado == null)
            {
                return;
            }

            await Application.Current.MainPage.Navigation.PushAsync(new ProductoDetallePage(productoSeleccionado), true);
        }

        [RelayCommand]
        public async Task GoToCrearProducto()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductoCrearPage());
        }
    }
}
