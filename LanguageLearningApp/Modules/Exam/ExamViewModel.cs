using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Models;
using LanguageLearningApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

    public partial class ExamViewModel : ObservableObject
    {
        #region Fields

        private readonly IExamService examService;

        [ObservableProperty]
        private string correctAnswer;

        [ObservableProperty]
        private int correctAnswers;

        [ObservableProperty]
        private int currentQuestion;

        [ObservableProperty]
        private string currentScore;

        [ObservableProperty]
        private bool examIsCompleted;

        [ObservableProperty]
        private bool examIsVisible;

        [ObservableProperty]
        private string examName;

        [ObservableProperty]
        private ExamState examState;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private bool promptForExamIsVisible;

        [ObservableProperty]
        private string question;

        [ObservableProperty]
        private List<QuestionAnswerObj> questions;

        [ObservableProperty]
        private bool revisionIsVisible;

        [ObservableProperty]
        private string userAnswer;

        #endregion Fields

        #region Constructors

        public ExamViewModel()
        {
            CheckAnswerCommand = new Command(CheckAnwser);
            GoToTestCommand = new Command(GoToTest);
            GoToRevisionCommand = new Command(GoToRevision);
            GoToHomePageCommand = new Command(GoToHomePage);
            //this.examService = examService;
        }

        #endregion Constructors



        #region Properties

        public Command CheckAnswerCommand { get; }
        public Command GoToHomePageCommand { get; }
        public Command GoToRevisionCommand { get; }
        public Command GoToTestCommand { get; }

        #endregion Properties



        #region Methods

        public async void ProcessExamState()
        {
            switch (ExamState)
            {
                case ExamState.Prompt:
                    PromptForExamIsVisible = true;
                    ExamIsVisible = false;
                    RevisionIsVisible = false;
                    ExamIsCompleted = false;
                    break;

                case ExamState.Enter:
                    PromptForExamIsVisible = false;
                    ExamIsVisible = true;
                    RevisionIsVisible = false;
                    ExamIsCompleted = false;
                    await LoadAndInitializeExam();
                    break;

                case ExamState.Revise:
                    PromptForExamIsVisible = false;
                    ExamIsVisible = false;
                    RevisionIsVisible = true;
                    ExamIsCompleted = false;
                    //await LoadAndInitializeExam();
                    break;

                case ExamState.Final:
                    PromptForExamIsVisible = false;
                    ExamIsVisible = false;
                    RevisionIsVisible = false;
                    ExamIsCompleted = true;
                    break;

                default:
                    PromptForExamIsVisible = false;
                    ExamIsVisible = false;
                    ExamIsCompleted = false;
                    RevisionIsVisible = true;
                    break;
            }
        }

        private bool CanGoToNextQuestion()
        {
            return (CurrentQuestion) < Questions.Count - 1;
        }

        private async void CheckAnwser()
        {
            if (userAnswer == correctAnswer)
            {
                CorrectAnswers++;
                CurrentScore = $"Score: {CorrectAnswers}/{Questions.Count}";
                await Shell.Current.DisplayAlert("Bravo", "Točan odgovor!", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Ups", "Netočan odgovor.", "OK");
            }
            UserAnswer = string.Empty;
            NextQuestion();
        }

        private async void GoToHomePage()
        {
            await Shell.Current.GoToAsync("..");
        }

        private void GoToRevision()
        {
            ExamState = ExamState.Revise;
            ProcessExamState();
        }

        private void GoToTest()
        {
            ExamState = ExamState.Enter;
            ProcessExamState();
        }

        private async Task LoadAndInitializeExam()
        {
            try
            {
                IsLoading = true;
                Questions = new List<QuestionAnswerObj>();
                using var stream = await FileSystem.OpenAppPackageFileAsync($"{ExamName}.json");
                using var reader = new StreamReader(stream);
                var contents = await reader.ReadToEndAsync();
                Questions = JsonSerializer.Deserialize<List<QuestionAnswerObj>>(contents);
                Questions.Shuffle();

                //Set initial data
                CorrectAnswers = 0;
                CurrentScore = $"Score: {CorrectAnswers}/{Questions.Count}";
                CurrentQuestion = 0;
                Question = Questions[CurrentQuestion].Question;
                CorrectAnswer = Questions[CurrentQuestion].Answer;
            }
            catch (Exception ex)
            {
                IsLoading = false;
            }
        }

        private void NextQuestion()
        {
            if (CanGoToNextQuestion())
            {
                SetUpQuestion();
            }
            else
            {
                ShowFinalScore();
            }
        }

        private void SetUpQuestion()
        {
            try
            {
                CurrentQuestion++;
                Question = Questions[CurrentQuestion].Question;
                CorrectAnswer = Questions[CurrentQuestion].Answer;
            }
            catch (Exception ex)
            {
                ShowFinalScore();
            }
        }

        private void ShowFinalScore()
        {
            ExamState = ExamState.Final;
            ProcessExamState();
        }

        #endregion Methods
    }
}