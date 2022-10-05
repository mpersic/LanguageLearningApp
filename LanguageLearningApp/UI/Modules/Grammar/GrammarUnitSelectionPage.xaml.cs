using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LanguageLearningApp.ExamViewModel;

namespace LanguageLearningApp;

[QueryProperty(nameof(Name), nameof(Name))]
public partial class GrammarUnitSelectionPage : ContentPage
{
    #region Fields
    private GrammarUnitSelectionViewModel GrammarUnitSelectionViewModel;

    #endregion Fields

    #region Constructors

    public GrammarUnitSelectionPage(GrammarUnitSelectionViewModel vm)
    {
        InitializeComponent();
        BindingContext = GrammarUnitSelectionViewModel = vm;
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

    private async void LoadExam(string name)
    {
        try
        {
            GrammarUnitSelectionViewModel.IsLoading = true;
            var grammarUnits = await GrammarUnitSelectionViewModel._grammarService.GetSelectedUnits(name);
            var gradedUnits = new List<GradedUnit>(
                grammarUnits.Select(unit => new GradedUnit(unit)).ToList());
            var substringAfterNumber = name.Split(".").Last();
            GrammarUnitSelectionViewModel.Name = substringAfterNumber.Split("-").First();
            GrammarUnitSelectionViewModel.GrammarUnits = gradedUnits;
            GrammarUnitSelectionViewModel.IsLoading = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load animal.");
            GrammarUnitSelectionViewModel.IsLoading = false;
        }
    }

    #endregion Methods

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(GrammarExamplePage)}");
    }
}