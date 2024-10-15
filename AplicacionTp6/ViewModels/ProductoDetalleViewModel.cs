using AplicacionTp6.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTp6.ViewModels
{
    public partial class ProductoDetalleViewModel:BaseViewModel
    {
        [ObservableProperty]
        Producto producto;

        public ProductoDetalleViewModel()
        {
            Title = "Detalle de Producto";
        }

        [RelayCommand]
        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
