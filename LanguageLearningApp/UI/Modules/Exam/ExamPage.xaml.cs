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
        BindingContext = ExamViewModel = vm;
    }

    #endregion Constructors



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

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //ExamViewModel.IsLoading = true;
        //ExamViewModel.VocabularyUnits = await VocabularyViewModel.VocabularyService.GetUnits();
        //ExamViewModel.IsLoading = false;
        // ... never getting called
    }

    private void LoadExam(string name)
    {
        try
        {
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