using Feedbackapp.Functions;
using Feedbackapp.View;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class PinEvaluationPageViewModel : BaseViewModel
    {
        private string _pin;
        public string PIN { get { return _pin; } set { SetProperty(ref _pin, value); } }

        public Command EvaluateCommand { get; private set; }

        public PinEvaluationPageViewModel()
        {
            EvaluateCommand = new Command(EvaluateCommandTapped);
        }

        public async void EvaluateCommandTapped()
        {
            try
            {
                var evaluation = await WebClientFunctions.GetEvaluation(PIN);
                await NavigationFunctions.PushAsync(new ClassEvaluationPage(evaluation));
            }
            catch (System.Exception ex)
            {
                DisplayAlert("Erro", "Não foi possível conectar com o servidor", "Ok");
            }
        }
    }
}