using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Pages;
using System.Windows.Input;

namespace LanguageLearningApp
{
    public partial class GrammarViewModel : ObservableObject
    {
        #region Fields
        private ICommand goToExamCommand;

        [ObservableProperty]
        private List<Unit> grammarUnits;

        [ObservableProperty]
        private string name;

        private ICommand testCommand;

        #endregion Fields

        #region Constructors

        public GrammarViewModel()
        {
            GrammarUnits = new List<Unit>()
            {
                new Unit
                {
                    UnitName = "Present"
                }
            };
            Name = "Klara";
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