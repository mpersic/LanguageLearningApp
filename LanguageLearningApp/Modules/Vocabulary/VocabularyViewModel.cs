using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Services.Interfaces;
using System.Collections.ObjectModel;

namespace LanguageLearningApp
{
    public partial class VocabularyViewModel : ObservableObject
    {
        #region Fields

        public IVocabularyService VocabularyService;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private ObservableCollection<Unit> vocabularyUnits;

        #endregion Fields

        #region Constructors

        public VocabularyViewModel(IVocabularyService vocabularyService)
        {
            VocabularyService = vocabularyService;
        }

        #endregion Constructors
    }
}