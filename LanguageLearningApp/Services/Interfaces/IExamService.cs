namespace LanguageLearningApp.Services.Interfaces
{
    public interface IExamService
    {
        #region Methods

        Task<List<Unit>> GetQuestions(string name);

        #endregion Methods
    }
}