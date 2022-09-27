using System.Collections.ObjectModel;
using static LanguageLearningApp.VocabularyPage;

namespace LanguageLearningApp;

public partial class GrammarPage : ContentPage
{
    #region Fields
    private GrammarViewModel GrammarViewModel;

    #endregion Fields

    #region Constructors

    public GrammarPage(GrammarViewModel vm)
    {
        InitializeComponent();
        BindingContext = GrammarViewModel = vm;
    }

    #endregion Constructors

    #region Methods

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        GrammarViewModel.IsLoading = true;
        var grammarUnits = await GrammarViewModel.GrammarService.GetUnits();
        var gradedUnits =
            new ObservableCollection<GradedUnit>
            (grammarUnits.Select(
                unit => new GradedUnit(unit)).ToList());
        var sorted = from unit in gradedUnits
                     orderby unit.Name
                     group unit by unit.NameSort into unitGroup
                     select new Grouping<string, GradedUnit>(unitGroup.Key, unitGroup);
        foreach (var list in sorted)
        {
            GrammarViewModel.GroupedUnits
                    .Add(new UnitGroup(list.FirstOrDefault().Name, list.ToList()));
        }
        GrammarViewModel.IsLoading = false;
        // ... never getting called
    }

    #endregion Methods
}