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
    public class GrammarService : IGrammarService
    {
        public async Task<ObservableCollection<Unit>> GetSelectedUnits(string selectedUnitName)
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync($"grammarunits-{selectedUnitName}.json");
                using var reader = new StreamReader(stream);

                var contents = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<ObservableCollection<Unit>>(contents);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Oops", "Something went wrong", "OK");
                return new ObservableCollection<Unit>();
            }
        }
        #region Methods

        public async Task<ObservableCollection<Unit>> GetUnits()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("grammarunits.json");
                using var reader = new StreamReader(stream);

                var contents = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<ObservableCollection<Unit>>(contents);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Oops", "Something went wrong", "OK");
                return new ObservableCollection<Unit>();
            }
        }

        #endregion Methods
    }
}