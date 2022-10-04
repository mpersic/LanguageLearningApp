using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using LanguageLearningApp.Services.Interfaces;

namespace LanguageLearningApp
{
    public class GrammarService : IGrammarService
    {
        #region Methods

        public async Task<List<Unit>> GetSelectedUnits(string selectedUnitName)
        {
            try
            {
                var processedName = selectedUnitName.ToLower();
                if (processedName.Contains("č"))
                {
                    processedName = processedName.Replace("č", "c");
                }
                using var stream = await FileSystem.OpenAppPackageFileAsync($"grammarunits-{processedName}.json");
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

        public async Task<List<Unit>> GetUnits()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("grammarunits.json");
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