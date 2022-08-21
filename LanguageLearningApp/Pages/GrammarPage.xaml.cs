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
        GrammarViewModel.GrammarUnits = await GrammarViewModel.GrammarService.GetUnits();
        GrammarViewModel.IsLoading = false;
        // ... never getting called
    }

    #endregion Methods
}