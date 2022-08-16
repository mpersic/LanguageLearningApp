using LanguageLearningApp.Pages;

namespace LanguageLearningApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ExamPage), typeof(ExamPage));
    }
}