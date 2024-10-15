using AplicacionTp6.Services;
using AplicacionTp6.ViewModels;
using AplicacionTp6.Views;
using Microsoft.Extensions.Logging;

namespace AplicacionTp6
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IProductoService, ProductoService>();

            builder.Services.AddTransient<ProductoListaViewModel>();
            builder.Services.AddTransient<ProductoListaPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
