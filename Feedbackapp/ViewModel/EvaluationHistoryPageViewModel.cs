using System.Collections.Generic;
using Feedbackapp.Functions;
using Feedbackapp.Model;

namespace Feedbackapp.ViewModel
{
    public class EvaluationHistoryPageViewModel : BaseViewModel
    {
        private List<Evaluation> _evaluations;
        public List<Evaluation> Evaluations { get { return _evaluations; } set { SetProperty(ref _evaluations, value); } }

        public EvaluationHistoryPageViewModel()
        {
            GetEvaluations();
        }

        public async void GetEvaluations()
        {
            try
            {
                Evaluations = await WebClientFunctions.GetEvaluations();
            }
            catch (System.Exception ex)
            {
                DisplayAlert("Erro", "Não foi possível conectar com o servidor", "Ok");
            }
        }
    }
}