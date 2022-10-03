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
        public readonly IGrammarService _grammarService;

        [ObservableProperty]
        private bool isLoading;

        public GrammarUnitSelectionViewModel(IGrammarService grammarService)
        {
            _grammarService = grammarService;
        }

        public ObservableCollection<UnitGroup> GroupedGrammarUnits { get; set; } = new ObservableCollection<UnitGroup>();

    }
}
