using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KleineZelfstandige.Models;
using KleineZelfstandige.Repository;

namespace KleineZelfstandige.ViewModel
{
    [QueryProperty("Klant", "selectedKlant")]
    public partial class KlantProfielViewModel : ObservableObject
    {
        
        private KlantRepo kr; // init gameservice voor DI
        public KlantProfielViewModel(KlantRepo klantRepo) // DI voor methodes en props aan te kunnen
        {
            kr = klantRepo;
        }

        [ObservableProperty]
        private Klant klant;
        
        [RelayCommand]
        private async void SaveKlant(Klant k)
        {
            k = klant;
            
            if (k.KlantId == null)
            {
                await kr.PostAsync(k);
            }
            else
            {
                await kr.PutAsync(k);
            }
            // repo aanspreken en object klant doorgeven?
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        private async void DeleteKlant(Klant k) 
        {
            await kr.DeleteAsync(k);
        }
    }
}
