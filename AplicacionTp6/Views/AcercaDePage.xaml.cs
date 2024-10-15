namespace AplicacionTp6.Views;

public partial class AcercaDePage : ContentPage
{
	public AcercaDePage()
	{
		InitializeComponent();
	}
    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PopAsync();
    }
}