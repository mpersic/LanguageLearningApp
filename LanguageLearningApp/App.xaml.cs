using LanguageLearningApp.Pages;

namespace LanguageLearningApp;

public partial class App : Application
{
    #region Constructors

    public App()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ExamPage), typeof(ExamPage));
    }

    #endregion Constructors
}