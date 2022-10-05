using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using LanguageLearningApp.Models;
using LanguageLearningApp.Services.Interfaces;
using LanguageLearningApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LanguageLearningApp.Services
{
    public class GrammarExampleService : IGrammarExampleService
    {
        public async Task<List<GrammarExample>> GetGrammarExamples(string name)
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync($"prezent-aktiv.json");
                using var reader = new StreamReader(stream);

                var contents = await reader.ReadToEndAsync();
                var exams = JsonSerializer.Deserialize<List<GrammarExample>>(contents);
                //if (!name.Contains("revise"))
                //{
                //    exams.Shuffle();
                //}
                //if (exams.Count < 10)
                //{
                //    throw new Exception("Not enough items in this unit!");
                //}
                //var tenExams = exams.Take(10).ToList();
                return exams;
            }
            catch (Exception ex)
            {
                var toast = Toast.Make(
                ex.Message,
                ToastDuration.Long,
                14);
                await toast.Show();
                return new List<GrammarExample>();
            }
        }
    }
}
