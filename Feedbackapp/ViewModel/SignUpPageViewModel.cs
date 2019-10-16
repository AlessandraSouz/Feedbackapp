using Feedbackapp.Functions;
using Feedbackapp.Model;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class SignUpPageViewModel : BaseViewModel
    {
        private string name;
        public string Name { get { return name; } set { SetProperty(ref name, value); } }
        private string email;
        public string Email { get { return email; } set { SetProperty(ref email, value); } }
        private string pass;
        public string Pass { get { return pass; } set { SetProperty(ref pass, value); } }

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