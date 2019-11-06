using System.Collections.Generic;
using Feedbackapp.Model;

namespace Feedbackapp.ViewModel
{
    public class EvaluationHistoryPageViewModel : BaseViewModel
    {
        private List<Evaluation> _evaluations;
        public List<Evaluation> Evaluations { get { return _evaluations; } set { SetProperty(ref _evaluations, value); } }

        public EvaluationHistoryPageViewModel()
        {
            Evaluations = new List<Evaluation>
            {
                new Evaluation
                {
                    Perguntas = new List<Question>{ new Question { Pergunta = "Como foi a aula de hoje?" } },
                    Percentual = 70
                },
            };
        }
    }
}