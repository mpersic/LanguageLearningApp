﻿using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Helpers;
using LanguageLearningApp.Models;
using LanguageLearningApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LanguageLearningApp
{
    public partial class ExamViewModel : ObservableObject
    {
        #region Fields

        private readonly IExamService _examService;

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
        private bool showFinalScore;

        [ObservableProperty]
        private string userAnswer;

        #endregion Fields

        #region Constructors

        public ExamViewModel(IExamService examService)
        {
            CheckAnswerCommand = new Command(CheckAnwser);
            GoToTestCommand = new Command(GoToTest);
            GoToRevisionCommand = new Command(GoToRevision);
            GoToHomePageCommand = new Command(GoToHomePage);
            _examService = examService;
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
                    ShowFinalScore = true;
                    PromptForExamIsVisible = false;
                    ExamIsVisible = true;
                    RevisionIsVisible = false;
                    ExamIsCompleted = false;
                    await LoadAndInitializeExam();
                    break;

                case ExamState.Revise:
                    ShowFinalScore = false;
                    PromptForExamIsVisible = false;
                    ExamIsVisible = false;
                    RevisionIsVisible = true;
                    ExamIsCompleted = false;
                    await LoadAndInitializeExam();
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
            if (ExamState.Equals(ExamState.Revise))
            {
                NextQuestion();
                return;
            }

            if (UserAnswer.Length == 0)
            {
                return;
            }
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
                if (ExamState.Equals(ExamState.Revise))
                {
                    ExamName = $"revise-{ExamName}";
                }
                IsLoading = true;
                Questions = new List<QuestionAnswerObj>();
                Questions = await _examService.GetQuestions(ExamName);

                if (ExamState.Equals(ExamState.Enter))
                {
                    UserAnswer = string.Empty;
                    CorrectAnswers = 0;
                    CurrentScore = $"Score: {CorrectAnswers}/{Questions.Count}";
                }

                CurrentQuestion = 0;
                Question = Questions[CurrentQuestion].Question;
                CorrectAnswer = Questions[CurrentQuestion].Answer;
            }
            catch (Exception ex)
            {
                GoToHomePage();
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
                ShowFinalScreen();
            }
        }

        private void SaveFinalScore()
        {
            Preferences.Default.Set(ExamName, $"{CorrectAnswers}/{Questions.Count}");
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
                ShowFinalScreen();
            }
        }

        private void ShowFinalScreen()
        {
            if (ExamState.Equals(ExamState.Enter))
            {
                SaveFinalScore();
            }
            ExamState = ExamState.Final;
            ProcessExamState();
        }

        #endregion Methods
    }
}