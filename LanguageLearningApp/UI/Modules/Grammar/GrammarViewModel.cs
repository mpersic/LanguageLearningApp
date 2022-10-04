using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Pages;
using LanguageLearningApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LanguageLearningApp
{
    public partial class GrammarViewModel : ObservableObject
    {
        #region Fields
        public IGrammarService GrammarService;

        [ObservableProperty]
        private List<Unit> grammarUnits;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string name;

        #endregion Fields

        #region Constructors

        public GrammarViewModel(IGrammarService grammarService)
        {
            GrammarService = grammarService;
            GrammarUnits = new List<Unit>();
        }

        #endregion Constructors
    }
}