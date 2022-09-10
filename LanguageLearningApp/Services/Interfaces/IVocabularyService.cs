using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Services.Interfaces
{
    public interface IVocabularyService
    {
        #region Methods

        Task<ObservableCollection<Unit>> GetUnits();

        #endregion Methods
    }
}