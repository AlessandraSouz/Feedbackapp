using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class ShareQuestionPageViewModel : BaseViewModel
    {
        private string _pin;
        public string PIN { get { return _pin; } set { SetProperty(ref _pin, value); } }
        public Command CopyCommand { get; private set; }

        public ShareQuestionPageViewModel(string sharePin)
        {
            PIN = sharePin;
            CopyCommand = new Command(CopyTapped);
        }

        private async void CopyTapped()
        {
            await Xamarin.Essentials.Clipboard.SetTextAsync(PIN);
            DisplayAlert("PIN", "O PIN foi copiado para a área de transferência", "Ok");
        }
    }
}