using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LanguageLearningApp.Services.Interfaces;

namespace LanguageLearningApp
{
    public class ExamService : IExamService
    {
        #region Methods

        public async Task<List<Unit>> GetQuestions(string name)
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync($"{name}.json");
                using var reader = new StreamReader(stream);

                var contents = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<List<Unit>>(contents);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Oops", "Something went wrong", "OK");
                return new List<Unit>();
            }
        }

        #endregion Methods
    }
}