using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.UI.Models
{
    public class GrammarExample 
    {
        public string Intro { get; set; }

        public ObservableCollection<string> GlagolPoLicima { get; set; }

        public ObservableCollection<string> Deklinacija { get; set; }

    }
}
