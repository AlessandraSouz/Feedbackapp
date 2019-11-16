using System.Collections.Generic;
using Feedbackapp.Functions;
using Feedbackapp.Model;
using Feedbackapp.View;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class EvaluationHistoryPageViewModel : BaseViewModel
    {
        private List<Evaluation> _evaluations;
        public List<Evaluation> Evaluations { get { return _evaluations; } set { SetProperty(ref _evaluations, value); } }

        public Command EvaluationDetailsCommand { get; private set; }

        public EvaluationHistoryPageViewModel()
        {
            GetEvaluations();
            EvaluationDetailsCommand = new Command<Evaluation>(EvaluationDetailsTapped);
        }

        public async void GetEvaluations()
        {
            try
            {
                Evaluations = await WebClientFunctions.GetEvaluations();
                if (Evaluations == null || Evaluations.Count == 0)
                {
                    if (await DisplayAlert("Erro", "Sem avaliações no momento", "Criar avaliação", "Ok"))
                        await NavigationFunctions.PushAsync(new EvaluationPage());
                }
            }
            catch (System.Exception ex)
            {
                DisplayAlert("Erro", "Não foi possível conectar com o servidor", "Ok");
            }
        }

        public async void EvaluationDetailsTapped(Evaluation evaluation)
        {
            await NavigationFunctions.PushAsync(new EvaluationDetailPage(evaluation));
        }
    }
}