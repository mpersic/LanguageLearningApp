using CommunityToolkit.Maui;
using LanguageLearningApp.Pages;
using LanguageLearningApp.Services;
using LanguageLearningApp.Services.Interfaces;

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
        builder.Services.AddSingleton<IGrammarExampleService, GrammarExampleService>();
        builder.Services.AddSingleton<IVocabularyService, VocabularyService>();
        builder.Services.AddSingleton<IExamService, ExamService>();

        //viewmodels
        builder.Services.AddSingleton<GrammarViewModel>();
        builder.Services.AddSingleton<GrammarUnitSelectionViewModel>();
        builder.Services.AddSingleton<GrammarExampleViewModel>();
        builder.Services.AddSingleton<VocabularyViewModel>();
        builder.Services.AddSingleton<ExamViewModel>();

        //pages
        builder.Services.AddSingleton<GrammarPage>();
        builder.Services.AddSingleton<GrammarUnitSelectionPage>();
        builder.Services.AddSingleton<GrammarExamplePage>();
        builder.Services.AddSingleton<VocabularyPage>();
        builder.Services.AddSingleton<ExamPage>();

        return builder.Build();
    }

    #endregion Methods
}