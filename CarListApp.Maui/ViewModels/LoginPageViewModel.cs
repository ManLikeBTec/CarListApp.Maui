using CarListApp.Maui.Helpers;
using CarListApp.Maui.Models;
using CarListApp.Maui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarListApp.Maui.ViewModels
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        private CarApiService carApiService;

        public LoginPageViewModel(CarApiService carApiService)
        {
            this.carApiService = carApiService;
        }

        [RelayCommand]
        async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await DisplayLoginMessage("Invalid Login Attempt");
            }
            else
            {
                //Call API to attemp Login
                var loginModel = new LoginModel(Username, Password);

                var response = await carApiService.Login(loginModel);
                await DisplayLoginMessage(carApiService.StatusMessage);
                if (response != null)
                {
                    if (!string.IsNullOrEmpty(response.Token))
                    {
                        await SecureStorage.SetAsync("Token", response.Token);

                        var jsonToken = new JwtSecurityTokenHandler().ReadToken(response.Token) as JwtSecurityToken;

                        var role = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(ClaimTypes.Role))?.Value;

                        App.UserInfo = new UserInfo()
                        {
                            Username = Username,
                            Role = role
                        };

                        MenuBuilder.BuildMenu();
                        await Shell.Current.GoToAsync($"{nameof(MainPage)}");
                    }
                    else
                    {
                        await DisplayLoginMessage("Invalid Login Attempt");
                    }
                }
                else
                {
                    await DisplayLoginMessage("Invalid Login Attempt");
                }
            }
        }

        async Task DisplayLoginMessage(string message)
        {
            await Shell.Current.DisplayAlert("Login Attempt Result", message, "OK");
            Password = string.Empty;
        }
    }
}
