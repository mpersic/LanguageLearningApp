using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.UI.Models
{
    public class BindableGrammarExample : INotifyPropertyChanged
    {
        //private string intro;

        //private List<string> glagolPoLicima;

        //private List<string> deklinacija;

        public List<string> GlagolPoLicima { get; set; }

        public List<string> Deklinacija { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
