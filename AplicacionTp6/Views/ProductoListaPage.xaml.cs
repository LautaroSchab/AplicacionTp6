using AplicacionTp6.Services;
using AplicacionTp6.ViewModels;

namespace AplicacionTp6.Views;

public partial class ProductoListaPage : ContentPage
{
	public ProductoListaPage()
	{
        ProductoService service = new ProductoService();
        ProductoListaViewModel vm = new ProductoListaViewModel(service);
        InitializeComponent();
        this.BindingContext = vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        var vm = BindingContext as ProductoListaViewModel;

        if (vm != null)
        {
            await vm.GetProductosCommand.ExecuteAsync(null);
        }
    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PopAsync();
    }
}