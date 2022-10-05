using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using LanguageLearningApp.Pages;
using System.Collections.ObjectModel;
using static LanguageLearningApp.VocabularyPage;

namespace LanguageLearningApp;

public partial class GrammarExamplePage : ContentPage
{
    #region Fields
    private GrammarExampleViewModel GrammarExampleViewModel;

    #endregion Fields

    #region Constructors

    public GrammarExamplePage(GrammarExampleViewModel vm)
    {
        InitializeComponent();
        BindingContext = GrammarExampleViewModel = vm;
    }

    #endregion Constructors

    #region Methods

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        GrammarExampleViewModel.IsLoading = true;
        var units = await GrammarExampleViewModel._grammarExampleService.GetGrammarExamples("");
        GrammarExampleViewModel.GrammarExamples = units;
        GrammarExampleViewModel.IsLoading = false;
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var unit = e.Item as Unit;
        if (unit.Name.Equals("Dolazi uskoro"))
        {
            var toast = Toast.Make(
                "Dodajemo uskoro :)",
                ToastDuration.Long,
                14);
            await toast.Show();
        }
        else
        {
            await Shell.Current.GoToAsync($"{nameof(GrammarUnitSelectionPage)}?Name={unit.Name}");
        }
    }

    #endregion Methods
}