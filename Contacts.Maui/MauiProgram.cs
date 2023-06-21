using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Contacts.Maui.Data;
using Contacts.Maui.Resources;

namespace Contacts.Maui;

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

        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        string dbPath = FileAccessHelper.GetLocalFilePath("ContactsDB.db");
        
		//string dbPath = Path.Combine(FileSystem.AppDataDirectory, "db");
		builder.Services.AddSingleton<ContactRepository>(s => ActivatorUtilities.CreateInstance<ContactRepository>(s, dbPath));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
