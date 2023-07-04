using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KleineZelfstandige.ViewModel
{
    public partial class SettingsViewModel: ObservableObject
    {        

        [RelayCommand]
        void ToggleTheme() 
        {
            if (Application.Current.UserAppTheme == AppTheme.Light)
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }

        }
    }
}
