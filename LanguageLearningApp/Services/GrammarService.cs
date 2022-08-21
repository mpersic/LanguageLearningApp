using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LanguageLearningApp
{
    public class GrammarService : IGrammarService
    {
        #region Methods

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