using CommunityToolkit.Mvvm.ComponentModel;
using KleineZelfstandige.Models;
using KleineZelfstandige.Repository;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KleineZelfstandige.ViewModel
{
    [QueryProperty("Doodle","selectedDoodle")]
    public partial class DoodleInfoViewModel : ObservableObject
    {
        private DoodleRepo dr;
        public DoodleInfoViewModel(DoodleRepo repo)
        {
            dr = repo;
        }

        [ObservableProperty]
        private Doodle doodle;



    }
}
