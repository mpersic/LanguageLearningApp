using CommunityToolkit.Maui;

namespace LanguageLearningApp;

public static class MauiProgram
{
    #region Methods

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        // Initialise the toolkit
        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        //services
        builder.Services.AddSingleton<IGrammarService, GrammarService>();

        //viewmodels
        builder.Services.AddSingleton<GrammarViewModel>();
        builder.Services.AddSingleton<VocabularyViewModel>();

        //pages
        builder.Services.AddSingleton<GrammarPage>();
        builder.Services.AddSingleton<VocabularyPage>();

        return builder.Build();
    }

    #endregion Methods
}