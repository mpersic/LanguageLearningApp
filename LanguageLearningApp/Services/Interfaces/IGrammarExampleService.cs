using LanguageLearningApp.Models;
using LanguageLearningApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLearningApp.Services.Interfaces
{
    public interface IGrammarExampleService
    {
        Task<List<GrammarExample>> GetGrammarExamples(string name);
    }
}
