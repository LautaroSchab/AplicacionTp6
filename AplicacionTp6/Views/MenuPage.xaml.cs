using AplicacionTp6.ViewModels;
namespace AplicacionTp6.Views;

public partial class MenuPage : ContentPage
{
	private MenuViewModel viewModel;
	public MenuPage()
	{
        BindingContext = viewModel = new MenuViewModel();
        InitializeComponent();
	}
}