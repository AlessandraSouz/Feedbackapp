using System;
using Feedbackapp.View;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        public Command ProfLogin { get; private set; }
        public Command AlunoEvaluation { get; private set; }

        public MainPageViewModel()
        {
            ProfLogin = new Command(ProfLoginTapped);
            AlunoEvaluation = new Command(AlunoEvaluationTapped);
        }

        private async void AlunoEvaluationTapped()
        {
            await Navigation.PushAsync(new PinEvaluationPage());
        }

        private async void ProfLoginTapped()
        {
            await Navigation.PushAsync(new AuthenticationPage());
        }
    }
}
