using Lab1Bychko.Lab3.DomainModel.Services;
using Lab1Bychko.Lab3.View;
using Lab1Bychko.Lab3.ViewModel;
using Lab1Bychko.Lab4.DomainModel.Services;
using Lab1Bychko.Lab4.View;
using Lab1Bychko.Lab4.ViewModel;

namespace Lab1Bychko;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.Services.AddTransient<IDbService, SQLiteService>();
        builder.Services.AddTransient<SetViewModel>();
        builder.Services.AddSingleton<SushiSetView>();

        builder.Services.AddHttpClient<IRateService, RateService>(opt =>
                opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));

        builder.Services.AddTransient<CurrencyConverterVM>();
        builder.Services.AddSingleton<ConverterView>();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}