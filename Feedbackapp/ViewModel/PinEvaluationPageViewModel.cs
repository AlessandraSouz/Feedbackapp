using Feedbackapp.Functions;
using Feedbackapp.View;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class PinEvaluationPageViewModel : BaseViewModel
    {
        private int _pin;
        public int PIN { get { return _pin; } set { SetProperty(ref _pin, value); } }

        public Command EvaluateCommand { get; private set; }

        public PinEvaluationPageViewModel()
        {
            EvaluateCommand = new Command(EvaluateCommandTapped);
        }

        public async void EvaluateCommandTapped()
        {
            var evaluation = await WebClientFunctions.GetEvaluation(PIN);
            await Navigation.PushAsync(new ClassEvaluationPage(evaluation));
        }
    }
}