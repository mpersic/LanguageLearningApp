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

        private readonly IExamService examService;

        [ObservableProperty]
        private string highScore;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private bool scoreIsVisible;

        #endregion Fields

        #region Constructors

        //, IExamService examService
        public GradedUnit(Unit baseUnit)
        {
            //this.examService = examService;
            Name = baseUnit.Name;
            HighScore = Preferences.Default.Get($"{baseUnit.Name.Split(" ").Last()}", "");
            //examService.GetExamScore($"revise-{Name}");
            if (HighScore.Length > 0)
            {
                ScoreIsVisible = true;
            }
        }

        #endregion Constructors
    }
}