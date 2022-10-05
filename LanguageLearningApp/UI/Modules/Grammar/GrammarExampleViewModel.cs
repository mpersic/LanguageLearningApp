using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Services.Interfaces;
using LanguageLearningApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp
{
    public partial class GrammarExampleViewModel : ObservableObject
    {
        #region Fields
        public IGrammarService GrammarService;
        public IGrammarExampleService _grammarExampleService;
        [ObservableProperty]
        private List<GrammarExample> grammarExamples;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string name;

        #endregion Fields

        public GrammarExampleViewModel(IGrammarService grammarService, IGrammarExampleService grammarExampleService)
        {
            GrammarService = grammarService;
            _grammarExampleService = grammarExampleService;
            GrammarExamples = new List<GrammarExample>();
        }

    }
}
