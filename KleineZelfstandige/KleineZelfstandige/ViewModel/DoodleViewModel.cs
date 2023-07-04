using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KleineZelfstandige.Models;
using KleineZelfstandige.Repository;
using KleineZelfstandige.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KleineZelfstandige.ViewModel
{
    public partial class DoodleViewModel : ObservableObject
    {
        public ObservableCollection<Doodle> Doodles { get; set; } = new();
        private List<Doodle> _DoodleList;

        DoodleRepo repo;
        public DoodleViewModel(DoodleRepo doodleRepo)
        {
            repo= doodleRepo;
        }

        [RelayCommand]
        public async Task LoadDoodlesAsync()
        {
            try
            {
                var doodles = await repo.GetDoodlesAsync();
                if (Doodles.Count != 0)
                {
                    Doodles.Clear();
                }
                foreach (var doodle in doodles)
                {
                    Doodles.Add(doodle);                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        [RelayCommand]
        public async Task AddDoodleView()
        {
            Doodle doodle = new();
            await Shell.Current.GoToAsync(nameof(DoodleInfoView), true, new Dictionary<string, object>
            {
                {"selectedDoodle",doodle}
            });
        }
        [RelayCommand]
        public async Task GoToDetail(Doodle doodle)
        {

            await Shell.Current.GoToAsync(nameof(DoodleInfoView), true, new Dictionary<string, object>
            {
                {"selectedDoodle",doodle}
            });
        }
    }
}
