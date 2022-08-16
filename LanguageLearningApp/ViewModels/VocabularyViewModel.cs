using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Java.Util.Jar.Attributes;

namespace LanguageLearningApp
{
    public partial class VocabularyViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Unit> vocabularyUnits;

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
    }
}