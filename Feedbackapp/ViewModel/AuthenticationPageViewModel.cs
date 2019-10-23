using System;
using Feedbackapp.Functions;
using Feedbackapp.Model;
using Feedbackapp.View;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class AuthenticationPageViewModel : BaseViewModel
    {
        private String email;
        public String Email { get { return email; } set { SetProperty(ref email, value); } }
        private String password;
        public String Password { get { return password; } set { SetProperty(ref password, value); } }
        public Command ForgotPwdCommand { get; set; }
        public Command LoginCommand { get; set; }
        public Command SignUpCommand { get; set; }

        public AuthenticationPageViewModel()
        {
            LoginCommand = new Command(LoginTapped);
            ForgotPwdCommand = new Command(ForgotPwdTapped);
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
                Navigation.PushAsync(new MainPage());
            else
                DisplayAlert("Erro", "Usuário não cadastrado", "Ok!");
        }

        private async void ForgotPwdTapped()
        {
            Navigation.PushAsync(new ForgotPwdPage());
        }

        private async void SignUpTapped()
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
