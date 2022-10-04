using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using LanguageLearningApp.Models;
using LanguageLearningApp.Pages;
using LanguageLearningApp.Services.Interfaces;

namespace LanguageLearningApp
{
    public static class Extensions
    {
        #region Fields
        private static Random rng = new Random();

        #endregion Fields

        #region Methods

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        #endregion Methods
    }

    public class ExamService : IExamService
    {
        #region Methods

        public string GetExamScore(string examName)
        {
            return Preferences.Default.Get(examName, "");
        }

        public async Task<List<QuestionAnswerObj>> GetQuestions(string name)
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync($"{name}.json");
                using var reader = new StreamReader(stream);

                var contents = await reader.ReadToEndAsync();
                var exams = JsonSerializer.Deserialize<List<QuestionAnswerObj>>(contents);
                if (!name.Contains("revise"))
                {
                    exams.Shuffle();
                }
                if (exams.Count < 10)
                {
                    throw new Exception("Not enough items in this unit!");
                }
                var tenExams = exams.Take(10).ToList();
                return tenExams;
            }
            catch (Exception ex)
            {
                var toast = Toast.Make(
                ex.Message,
                ToastDuration.Long,
                14);
                await toast.Show();
                return new List<QuestionAnswerObj>();
            }
        }

        #endregion Methods
    }
}