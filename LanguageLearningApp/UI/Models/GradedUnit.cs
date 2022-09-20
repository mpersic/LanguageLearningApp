using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Pages;
using LanguageLearningApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp
{
    public partial class GradedUnit : ObservableObject
    {
        #region Fields

        [ObservableProperty]
        private string highScore;

        [ObservableProperty]
        private string lesson;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private bool scoreIsVisible;

        #endregion Fields

        #region Constructors

        public GradedUnit(Unit baseUnit)
        {
            Name = baseUnit.Name;
            Lesson = baseUnit.Lesson;
            HighScore = Preferences.Default.Get($"{baseUnit.Name.Split(" ").Last()}", "");
            if (HighScore.Length > 0)
            {
                ScoreIsVisible = true;
            }
        }

        #endregion Constructors

        #region Properties

        public string NameSort
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Name) || Name.Length == 0)
                    return "?";

                return Name[0].ToString().ToUpper();
            }
        }

        #endregion Properties
    }
}