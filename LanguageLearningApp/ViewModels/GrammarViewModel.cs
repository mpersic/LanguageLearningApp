using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Pages;
using LanguageLearningApp.ViewModels;
using System.Windows.Input;

namespace LanguageLearningApp
{
    public partial class GrammarViewModel : ObservableObject
    {
        #region Fields
        public IGrammarService GrammarService;
        private ICommand goToExamCommand;

        [ObservableProperty]
        private List<Unit> grammarUnits;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string name;

        private ICommand testCommand;

        #endregion Fields

        #region Constructors

        public GrammarViewModel(IGrammarService grammarService)
        {
            GrammarService = grammarService;
        }

        #endregion Constructors

        #region Properties
        public ICommand GoToExamCommand => goToExamCommand ??= new Command(GoToExam);
        public ICommand TestCommand => testCommand ??= new Command(Test);

        #endregion Properties

        #region Methods

        private async void GoToExam()
        {
            await Shell.Current.GoToAsync($"{nameof(ExamPage)}");
        }

        private void Test()
        {
            Console.WriteLine("Hello");
        }

        #endregion Methods
    }
}