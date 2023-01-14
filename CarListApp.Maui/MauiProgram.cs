using CarListApp.Maui.Services;
using CarListApp.Maui.ViewModels;
using CarListApp.Maui.Views;

namespace CarListApp.Maui;

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

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "cars.db3");
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<CarDatabaseService>(s, dbPath));

		builder.Services.AddTransient<CarApiService>();

		//singleton is single instance throughout life of application run.
		builder.Services.AddSingleton<CarListViewModel>();
		//transient gets new instance of page everytime.
		builder.Services.AddTransient<CarDetailsViewModel>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<CarDetailsPage>();

		return builder.Build();
	}
}
