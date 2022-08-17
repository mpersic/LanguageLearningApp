using CommunityToolkit.Mvvm.ComponentModel;

namespace LanguageLearningApp
{
    public partial class VocabularyViewModel : ObservableObject
    {
        #region Fields

        [ObservableProperty]
        private List<Unit> vocabularyUnits;

        #endregion Fields

        #region Constructors

        public VocabularyViewModel()
        {
            VocabularyUnits = new List<Unit>()
            {
                new Unit
                {
                    UnitName = "Greetings"
                }
            };
        }

        #endregion Constructors
    }
}