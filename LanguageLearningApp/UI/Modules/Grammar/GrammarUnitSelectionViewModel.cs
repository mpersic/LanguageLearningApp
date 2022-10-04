using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp
{
    public partial class GrammarUnitSelectionViewModel : ObservableObject
    {
        #region Fields
        public readonly IGrammarService _grammarService;

        [ObservableProperty]
        private List<GradedUnit> grammarUnits;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string name;

        #endregion Fields

        #region Constructors

        public GrammarUnitSelectionViewModel(IGrammarService grammarService)
        {
            _grammarService = grammarService;
        }

        #endregion Constructors
    }
}