using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Diagnostics;

namespace Grocery.App.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly GlobalViewModel _global;

        [ObservableProperty]
        private string email = "example@example.com";

        [ObservableProperty]
        private string password = "new";

        [ObservableProperty]
        private string loginMessage;
        public RegisterViewModel(IAuthService authService, GlobalViewModel global)
        {
            _authService = authService;
            _global = global;
        }

        [RelayCommand]
        private async Task Register()
        {
            Client? newClient = _authService.Register(Email, Password);

            if (newClient != null)
            {
                LoginMessage = $"Welkom {newClient.Name}!";
                _global.Client = newClient;
                await Shell.Current.GoToAsync("//Home");
            }
        }
    }
}
