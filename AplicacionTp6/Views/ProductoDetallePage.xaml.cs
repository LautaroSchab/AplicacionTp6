using AplicacionTp6.Models;
using AplicacionTp6.ViewModels;

namespace AplicacionTp6.Views;

public partial class ProductoDetallePage : ContentPage
{
	public ProductoDetallePage(Producto param)
	{
		InitializeComponent();
        ProductoDetalleViewModel vm = new ProductoDetalleViewModel();
        this.BindingContext = vm;
        vm.Producto = param;
    }
}