using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KleineZelfstandige.Models;
using KleineZelfstandige.SqlLite;
using KleineZelfstandige.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KleineZelfstandige.ViewModel
{
   public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private string password;

        LoginDb database;
        public LoginViewModel(LoginDb loginDb)
        {
            database = loginDb;
        }

        [RelayCommand]
        public async void LoginAsync()
        {
            Login result = new Login();
            if (database == null)
            {
                database = new LoginDb();
            }
            try
            {
                result = await database.GetLoginAsync(Username, Password);
                if (result != null)
                {
                    await Shell.Current.GoToAsync($"/{nameof(HomeView)}");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        [RelayCommand]
        public async void RegisterAsync()
        {
            Login result = new Login();
            result.Username = username;
            result.Password = password;
            var succes = await database.SaveLoginAsync(result);
            if (succes == 0)
            {
                throw new Exception("Failed to save login");
            }
        }
       
    }
}
