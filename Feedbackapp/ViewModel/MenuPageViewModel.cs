using Feedbackapp.Functions;
using Feedbackapp.View;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class MenuPageViewModel : BaseViewModel
    {
        public Command SeeHistoryCommand { get; private set; }
        public Command PublishEvaluationCommand { get; private set; }

        public MenuPageViewModel()
        {
            SeeHistoryCommand = new Command(SeeHistoryTapped);
            PublishEvaluationCommand = new Command(PublishEvaluationTapped);
        }

        private async void SeeHistoryTapped()
        {
            await NavigationFunctions.PushAsync(new EvaluationHistoryPage());
        }

        private async void PublishEvaluationTapped()
        {
            await NavigationFunctions.PushAsync(new EvaluationPage());
        }
    }
}
