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

    public GrammarUnitSelectionPage(GrammarUnitSelectionViewModel vm)
    {
        InitializeComponent();
        BindingContext = GrammarUnitSelectionViewModel = vm;
    }

    public string Name
    {
        set
        {
            LoadExam(value);
        }
    }

    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    GrammarUnitSelectionViewModel.IsLoading = true;
    //    var grammarUnits = await GrammarUnitSelectionViewModel._grammarService.GetSelectedUnits();
    //    var gradedUnits =
    //        new ObservableCollection<GradedUnit>
    //        (grammarUnits.Select(
    //            unit => new GradedUnit(unit)).ToList());
    //    var sorted = from unit in gradedUnits
    //                 orderby unit.Name
    //                 group unit by unit.NameSort into unitGroup
    //                 select new Grouping<string, GradedUnit>(unitGroup.Key, unitGroup);
    //    foreach (var list in sorted)
    //    {
    //        GrammarViewModel.GroupedUnits
    //                .Add(new UnitGroup(list.FirstOrDefault().Name, list.ToList()));
    //    }
    //    GrammarViewModel.IsLoading = false;
    //}

    private async void LoadExam(string name)
    {
        //try
        //{
        //    GrammarUnitSelectionViewModel.IsLoading = true;
        //    var grammarUnits = await GrammarUnitSelectionViewModel._grammarService.GetSelectedUnits(name);
        //    var gradedUnits = new ObservableCollection<GradedUnit>(
        //        grammarUnits.Select(unit => new GradedUnit(unit)).ToList());
        //    var sorted = from unit in gradedUnits
        //                 orderby unit.Name
        //                 group unit by unit.NameSort into unitGroup
        //                 select new Grouping<string, GradedUnit>(unitGroup.Key, unitGroup);
        //    foreach (var list in sorted)
        //    {
        //        GrammarUnitSelectionViewModel.GroupedGrammarUnits
        //                .Add(new UnitGroup(list.FirstOrDefault().Name, list.ToList()));
        //    }
        //    GrammarUnitSelectionViewModel.IsLoading = false;
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Failed to load animal.");
        //    GrammarUnitSelectionViewModel.IsLoading = false;
        //}
    }

}