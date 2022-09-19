using LanguageLearningApp.Pages;
using System.Collections.ObjectModel;

namespace LanguageLearningApp;

public partial class VocabularyPage : ContentPage
{
    #region Fields

    private VocabularyViewModel VocabularyViewModel;

    #endregion Fields

    #region Constructors

    public VocabularyPage(VocabularyViewModel vm)
    {
        InitializeComponent();
        BindingContext = VocabularyViewModel = vm;
    }

    #endregion Constructors



    #region Methods

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        VocabularyViewModel.IsLoading = true;
        var vocabularyUnits = await VocabularyViewModel.VocabularyService.GetUnits();
        VocabularyViewModel.VocabularyUnits = new ObservableCollection<GradedUnit>
            (vocabularyUnits.Select(unit => new GradedUnit(unit)).ToList());
        //VocabularyViewModel.VocabularyUnits = await VocabularyViewModel.VocabularyService.GetUnits();
        VocabularyViewModel.IsLoading = false;
        // ... never getting called
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var unit = e.Item as GradedUnit;
        await Shell.Current.GoToAsync($"{nameof(ExamPage)}?Name={unit.Name}");
    }

    #endregion Methods
}