using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Pages;
using System.Windows.Input;
using static Android.Content.ClipData;

namespace LanguageLearningApp
{
    public partial class GrammarViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private List<Unit> grammarUnits;

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

        private ICommand testCommand;

        public ICommand TestCommand => testCommand ??= new Command(Test);

        private ICommand goToExamCommand;

        public ICommand GoToExamCommand => goToExamCommand ??= new Command(GoToExam);

        private async void GoToExam()
        {
            await Shell.Current.GoToAsync($"{nameof(ExamPage)}");
        }

        private void Test()
        {
            Console.WriteLine("Hello");
        }
    }
}