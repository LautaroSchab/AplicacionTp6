using AplicacionTp6.Models;
using AplicacionTp6.ViewModels;

namespace AplicacionTp6.Views;

public partial class UsuarioDetallePage : ContentPage
{
	public UsuarioDetallePage(Usuario param)
	{
		InitializeComponent();
		UsuarioDetalleViewModel vm = new UsuarioDetalleViewModel();
        this.BindingContext = vm;
        vm.Usuario = param;
    }
}