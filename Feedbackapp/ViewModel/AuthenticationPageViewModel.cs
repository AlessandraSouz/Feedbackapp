using System;
using Feedbackapp.Functions;
using Feedbackapp.Model;
using Feedbackapp.View;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class AuthenticationPageViewModel : BaseViewModel
    {
        private String _email;
        public String Email { get { return _email; } set { SetProperty(ref _email, value); } }
        private String _password;
        public String Password { get { return _password; } set { SetProperty(ref _password, value); } }
        public Command LoginCommand { get; set; }
        public Command SignUpCommand { get; set; }

        public AuthenticationPageViewModel()
        {
            LoginCommand = new Command(LoginTapped);
            SignUpCommand = new Command(SignUpTapped);
        }

        private async void LoginTapped()
        {
            var usr = new User
            {
                Email = Email,
                Name = string.Empty,
                Password = Password
            };

            var user = await SQLiteFunctions.SelectUser(usr);
            if (user != null)
                await Navigation.PushAsync(new AuthenticationPage());
            else
                DisplayAlert("Erro", "Usuário não cadastrado", "Ok!");
        }

        private async void SignUpTapped()
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
