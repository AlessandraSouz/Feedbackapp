using Feedbackapp.Functions;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class PasswordRecoveryPageViewModel : BaseViewModel
    {
        private string _email;
        public string Email { get { return _email; } set { SetProperty(ref _email, value); } }

        private string _pin;
        public string PIN { get { return _pin; } set { SetProperty(ref _pin, value); } }

        private string _newPassword;
        public string NewPassword { get { return _newPassword; } set { SetProperty(ref _newPassword, value); } }

        private string _newPasswordValidation;
        public string NewPasswordValidation { get { return _newPasswordValidation; } set { SetProperty(ref _newPasswordValidation, value); } }

        private bool _validEmail;
        public bool ValidEmail { get { return _validEmail; } set { SetProperty(ref _validEmail, value); } }

        private bool _validPIN;
        public bool ValidPIN { get { return _validPIN; } set { SetProperty(ref _validPIN, value); } }

        public Command RecoverPasswordCommand { get; private set; }
        public Command RedefinePasswordCommand { get; private set; }
        public Command NewPasswordCommand { get; private set; }

        private string ValidationPIN { get; set; }

        public PasswordRecoveryPageViewModel()
        {
            RecoverPasswordCommand = new Command(RecoverPasswordTapped);
            RedefinePasswordCommand = new Command(RedefinePasswordTapped);
            NewPasswordCommand = new Command(NewPasswordTapped);
            ValidPIN = false;
        }

        public async void RecoverPasswordTapped()
        {
            var password_dictionary = await WebClientFunctions.RecoverPassword(Email);
            ValidationPIN = password_dictionary[Email];
            ValidEmail = true;
        }

        public async void RedefinePasswordTapped()
        {
            if (PIN == ValidationPIN)
                ValidPIN = true;
            else
                DisplayAlert("Erro", "PIN inválido para a conta", "Tentar novamente");
        }

        public async void NewPasswordTapped()
        {
            if (NewPassword == NewPasswordValidation)
            {
                try
                {
                    SQLiteFunctions.UpdateUser(Email, NewPassword);
                    DisplayAlert("Sucesso", "Senha atualizada", "Ok");
                    await NavigationFunctions.PopAsync();
                }
                catch
                {
                    DisplayAlert("Erro", "Não foi possível recuperar a senha para este usuário", "Ok");
                }
            }
            else
                DisplayAlert("Erro", "As senhas não coincidem", "Ok");
        }
    }
}