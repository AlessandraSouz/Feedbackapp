using Feedbackapp.Functions;
using Feedbackapp.Model;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class SignUpPageViewModel : BaseViewModel
    {
        private string _name;
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }
        private string _email;
        public string Email { get { return _email; } set { SetProperty(ref _email, value); } }
        private string _pass;
        public string Pass { get { return _pass; } set { SetProperty(ref _pass, value); } }

        public Command SignUpCommand { get; private set; }

        public SignUpPageViewModel()
        {
            SignUpCommand = new Command(SignUpTapped);
        }

        private void SignUpTapped()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Pass))
                Application.Current.MainPage.DisplayAlert("Erro!", "Você precisa informar todos os seus dados", "Ok!");
            else
            {
                User usr = new User
                {
                    Email = Email,
                    Name = Name,
                    Password = Pass
                };

                SQLiteFunctions.InsertUser(usr);
            }
        }
    }
}