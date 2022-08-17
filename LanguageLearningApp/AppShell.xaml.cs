using LanguageLearningApp.Pages;

namespace LanguageLearningApp;

public partial class AppShell : Shell
{
    #region Constructors

    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ExamPage), typeof(ExamPage));
    }

    #endregion Constructors
}