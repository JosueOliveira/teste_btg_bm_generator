using BMGeneratorTest.Models.DAO;
using BMGeneratorTest.Models.Entities;
using BMGeneratorTest.Models.Interfaces;
using BMGeneratorTest.Repository;
using BMGeneratorTest.Services;
using BMGeneratorTest.ViewModels;
using BMGeneratorTest.Views;
using Microsoft.Extensions.Logging;

namespace BMGeneratorTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddSingleton<IDataStore<GraphicConfigModel>>(sp =>
            new DataStore<GraphicConfigModel>(GraphicConfigModel.tableName));
            builder.Services.AddTransient<IBMGenerator, BMGeneratorService>();
            builder.Services.AddTransient<IGraficConfigRepository, GraficConfigRepository>();
            builder.Services.AddTransient<IGraphicConfigService, GraphicConfigService>();
            builder.Services.AddTransient<IColorService, ColorService>();

            builder.Services.AddSingleton<ChartDrawable>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if WINDOWS
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping("FullscreenWindow", (handler, view) =>
            {
                var window = handler.VirtualView;

                Platforms.Windows.Services.WindowService.CenterAndResize(window, 1200, 800);

            });
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
