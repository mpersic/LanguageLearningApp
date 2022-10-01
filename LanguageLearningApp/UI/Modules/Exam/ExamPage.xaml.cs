using LanguageLearningApp.Models;
using System.Text.Json;

namespace LanguageLearningApp.Pages;

[QueryProperty(nameof(Name), nameof(Name))]
public partial class ExamPage : ContentPage
{
    #region Fields
    private ExamViewModel ExamViewModel;

    #endregion Fields

    #region Constructors

    public ExamPage(ExamViewModel vm)
    {
        InitializeComponent();
        vm.InitializeQuestionEvent += InitializeQuestion;
        BindingContext = ExamViewModel = vm;
    }

    #endregion Constructors

    #region Enums

    public enum CurrentStackLayout
    {
        First,
        Second,
        Third
    }

    #endregion Enums

    #region Properties

    public string Name
    {
        set
        {
            LoadExam(value);
        }
    }

    #endregion Properties

    #region Methods

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //ExamViewModel.IsLoading = true;
        //ExamViewModel.VocabularyUnits = await VocabularyViewModel.VocabularyService.GetUnits();
        //ExamViewModel.IsLoading = false;
        // ... never getting called
    }

    private void InitializeQuestion()
    {
        //var strings = ExamViewModel.VisibleQuestion.Split(" ");
        //QuestionHorizontalLayout1.Children.Clear();
        //QuestionHorizontalLayout2.Children.Clear();
        //QuestionHorizontalLayout3.Children.Clear();
        //var currentLayout = "s1";
        //var currentStackLayout = CurrentStackLayout.First;
        //foreach (string str in strings)
        //{
        //    var tapGestureRecognizer = new TapGestureRecognizer();
        //    tapGestureRecognizer.Tapped += async (s, e) =>
        //    {
        //        await Shell.Current.DisplayAlert(str, "explaination", "OK");
        //    };
        //    var label = new Label() { Text = $"{str} " };
        //    label.GestureRecognizers.Add(tapGestureRecognizer);
        //    switch (currentStackLayout)
        //    {
        //        case CurrentStackLayout.First:
        //            if (QuestionHorizontalLayout1.Width >= (ExamPageName.Width - 40))
        //            {
        //                currentStackLayout = CurrentStackLayout.Second;
        //                QuestionHorizontalLayout2.Children.Add(label);
        //            }
        //            else
        //            {
        //                QuestionHorizontalLayout1.Children.Add(label);
        //                if (QuestionHorizontalLayout1.Width >= (ExamPageName.Width - 40))
        //                {
        //                    QuestionHorizontalLayout1.Children.Remove(label);
        //                    currentStackLayout = CurrentStackLayout.Second;
        //                    QuestionHorizontalLayout2.Children.Add(label);
        //                }
        //            }
        //            break;

        //        case CurrentStackLayout.Second:
        //            if (QuestionHorizontalLayout2.Width >= ExamPageName.Width)
        //            {
        //                currentStackLayout = CurrentStackLayout.Second;
        //                QuestionHorizontalLayout3.Children.Add(label);
        //            }
        //            else
        //            {
        //                QuestionHorizontalLayout2.Children.Add(label);
        //            }
        //            break;

        //        case CurrentStackLayout.Third:
        //            if (QuestionHorizontalLayout3.Width >= ExamPageName.Width)
        //            {
        //                currentStackLayout = CurrentStackLayout.Second;
        //                QuestionHorizontalLayout3.Children.Add(label);
        //            }
        //            else
        //            {
        //                QuestionHorizontalLayout3.Children.Add(label);
        //            }
        //            break;
        //    }

        //    //if (currentLayout == "s1")
        //    //{
        //    //    if (QuestionHorizontalLayout1.Width >= ExamPageName.Width)
        //    //    {
        //    //        currentLayout = "s2";
        //    //        QuestionHorizontalLayout2.Children.Add(label);
        //    //    }
        //    //    else
        //    //    {
        //    //        QuestionHorizontalLayout1.Children.Add(label);
        //    //    }
        //    //}
        //    //if (currentLayout == "s2")
        //    //{
        //    //    QuestionHorizontalLayout2.Children.Add(label);
        //    //    if (QuestionHorizontalLayout2.Width >= ExamPageName.Width)
        //    //    {
        //    //        QuestionHorizontalLayout2.Children.Remove(label);
        //    //        currentLayout = "s3";
        //    //        QuestionHorizontalLayout3.Children.Add(label);
        //    //    }
        //    //}
        //    //if (currentLayout == "s3")
        //    //{
        //    //    QuestionHorizontalLayout3.Children.Add(label);
        //    //    if (QuestionHorizontalLayout2.Width >= ExamPageName.Width)
        //    //    {
        //    //        QuestionHorizontalLayout2.Children.Remove(label);
        //    //        currentLayout = "s3";
        //    //        QuestionHorizontalLayout3.Children.Add(label);
        //    //    }
        //    //}
        //}
    }

    private void LoadExam(string name)
    {
        try
        {
            var substringAfterNumber = name.Split(".").Last();
            ExamViewModel.Name = substringAfterNumber.Split("-").First();
            ExamViewModel.IsLoading = true;

            ExamViewModel.ExamState = ExamState.Prompt;
            ExamViewModel.ProcessExamState();

            //get questions
            ExamViewModel.ExamName = name.Split(" ").Last();
            ExamViewModel.IsLoading = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load animal.");
            ExamViewModel.IsLoading = false;
        }
    }

    #endregion Methods
}