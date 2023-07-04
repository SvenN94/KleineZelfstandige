
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KleineZelfstandige.Models;
using KleineZelfstandige.Repository;
using KleineZelfstandige.Views.Klant;
using System.Collections.ObjectModel;
using System.Linq;

namespace KleineZelfstandige.ViewModel
{
    
    public partial class KlantListViewModel : ObservableObject
    {
        public ObservableCollection<Klant> Klanten { get; set; } = new();
        private List<Klant> _KlantList = new();

        [ObservableProperty]
        private string zoekQuery;

        KlantRepo kr;
        public KlantListViewModel(KlantRepo klantRepo)
        {
            kr = klantRepo;

        }

        [RelayCommand]
        public async Task AddKlant()
        {
            Klant clickedKlant = new();
            await Shell.Current.GoToAsync(nameof(KlantProfielView), true, new Dictionary<string, object>
            {
                {"selectedKlant",clickedKlant}
            });
        }

        [RelayCommand]
        public Task Zoek()
        {
            Klanten.Clear();
            Klanten =  _KlantList.FindAll(x => x.BedrijfNaam == ZoekQuery).ToObservableCollection();
            return Task.CompletedTask;
        }
        
        [RelayCommand]
        public async Task LoadKlantenAsync()
        {
            try
            {
                var klanten = await kr.GetKlantLijstAsync();
                if (Klanten.Count != 0)
                {
                    Klanten.Clear();
                }
                foreach (var klant in klanten)
                {
                    Klanten.Add(klant);
                    _KlantList.Add(klant);
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        [RelayCommand]
        public async void GoToDetail(Klant clickedKlant)
        {
            await Shell.Current.GoToAsync(nameof(KlantProfielView), true, new Dictionary<string, object>
            {
                {"selectedKlant",clickedKlant}
            });
        }
        
        
            
    }
}

