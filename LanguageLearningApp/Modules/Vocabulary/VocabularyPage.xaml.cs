using LanguageLearningApp.Pages;

namespace LanguageLearningApp;

public partial class VocabularyPage : ContentPage
{
    #region Fields

    private VocabularyViewModel VocabularyViewModel;

    #endregion

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
        VocabularyViewModel.VocabularyUnits = await VocabularyViewModel.VocabularyService.GetUnits();
        VocabularyViewModel.IsLoading = false;
        // ... never getting called
    }

    #endregion Methods

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var unit = e.Item as Unit;
        await Shell.Current.GoToAsync($"{nameof(ExamPage)}?Name={unit.Name}");
    }
}