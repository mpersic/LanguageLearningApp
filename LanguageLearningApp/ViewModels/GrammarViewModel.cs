using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace LanguageLearningApp
{
    public partial class GrammarViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        public GrammarViewModel()
        {
            Name = "Klara";
        }

        private ICommand testCommand;

        public ICommand TestCommand => testCommand ??= new Command(Test);

        private void Test()
        {
            Console.WriteLine("Hello");
        }
    }
}