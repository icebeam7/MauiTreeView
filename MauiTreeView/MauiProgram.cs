using MauiTreeView.Sample.Helpers;
using MauiTreeView.Sample.Services;
using MauiTreeView.Sample.Views;

namespace MauiTreeView;

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

        builder.Services.AddSingleton<DataService>();
        builder.Services.AddSingleton<CompanyTreeViewBuilder>();
        builder.Services.AddTransient<CompanyPage>();

        return builder.Build();
	}
}
