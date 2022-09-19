using LanguageLearningApp.Models;

namespace LanguageLearningApp.Services.Interfaces
{
    public interface IExamService
    {
        string GetExamScore(string examName);
        #region Methods

        Task<List<QuestionAnswerObj>> GetQuestions(string name);

        #endregion Methods
    }
}