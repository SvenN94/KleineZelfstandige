using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KleineZelfstandige.Models;
using KleineZelfstandige.Repository;
using KleineZelfstandige.Views;
using KleineZelfstandige.Views.Klant;
using System.Collections.ObjectModel;

namespace KleineZelfstandige.ViewModel
{
    public partial class HomeViewViewModel : ObservableObject
    {
        public ObservableCollection<Klant> klants { get; set; } = new();
        public ObservableCollection<Doodle> doodles { get; set; } = new();

        KlantRepo kr;
        DoodleRepo dr;
        public HomeViewViewModel(DoodleRepo drepo,KlantRepo krepo)
        {
            dr = drepo;
            kr = krepo;
        }

        [RelayCommand]
        public async Task LoadAsync()
        {
            try
            {
                var klanten = await kr.GetKlantLijstAsync();
                if (klants.Count != 0)
                {
                    klants.Clear();
                }
                foreach (var klant in klanten)
                {
                    klants.Add(klant);                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            try
            {
                var doodlelijst = await dr.GetDoodlesAsync();
                if (doodles.Count != 0)
                {
                    doodles.Clear();
                }
                foreach (var doodle in doodlelijst)
                {
                    doodles.Add(doodle);                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        [RelayCommand]
        public async Task GoToDetailKlant(Klant clickedKlant)
        {
            await Shell.Current.GoToAsync(nameof(KlantProfielView), true, new Dictionary<string, object>
            {
                {"selectedKlant",clickedKlant}
            });
        }
        [RelayCommand]
        public async Task GoToDetailDoodle(Doodle clickedDoodle)
        {
            await Shell.Current.GoToAsync(nameof(DoodleInfoView), true, new Dictionary<string, object>
            {
                {"selectedDoodle", clickedDoodle}
            });
        }

    }
}
