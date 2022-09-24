using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using LanguageLearningApp.Pages;
using Microsoft.Maui;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

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
        if (VocabularyViewModel.GroupedUnits.Any())
        {
            return;
        }
        base.OnAppearing();
        VocabularyViewModel.IsLoading = true;
        var vocabularyUnits = await VocabularyViewModel.VocabularyService.GetUnits();
        var gradedUnits =
            new ObservableCollection<GradedUnit>
            (vocabularyUnits.Select(
                unit => new GradedUnit(unit)).ToList());

        var sorted = from unit in gradedUnits
                     orderby unit.Name
                     group unit by unit.NameSort into unitGroup
                     select new Grouping<string, GradedUnit>(unitGroup.Key, unitGroup);

        foreach (var list in sorted)
        {
            VocabularyViewModel.GroupedUnits
                    .Add(new UnitGroup(list.FirstOrDefault().Name, list.ToList()));
        }
        VocabularyViewModel.IsLoading = false;
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var unit = e.Item as GradedUnit;
        if (unit.Lesson.Equals("Dolazi uskoro"))
        {
            var toast = Toast.Make(
                "Dodajemo uskoro :)",
                ToastDuration.Long,
                14);
            await toast.Show();
        }
        else
        {
            await Shell.Current.GoToAsync($"{nameof(ExamPage)}?Name={unit.Lesson}");
        }
    }

    #endregion Methods



    #region Classes

    public class Grouping<K, T> : ObservableCollection<T>
    {
        #region Constructors

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }

        #endregion Constructors



        #region Properties

        public K Key { get; private set; }

        #endregion Properties
    }

    #endregion Classes
}