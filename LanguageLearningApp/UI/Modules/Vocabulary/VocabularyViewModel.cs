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
        private ObservableCollection<GradedUnit> vocabularyUnits;

        #endregion Fields

        #region Constructors

        public VocabularyViewModel(IVocabularyService vocabularyService)
        {
            VocabularyService = vocabularyService;
        }

        #endregion Constructors

        #region Properties
        public ObservableCollection<UnitGroup> GroupedUnits { get; set; } = new ObservableCollection<UnitGroup>();

        #endregion Properties
    }
}