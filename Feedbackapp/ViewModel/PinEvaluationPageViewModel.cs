using System.Collections.Generic;
using Feedbackapp.Functions;
using Feedbackapp.Model;
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
            //TODO: publicar WebAPI para utilizar funções de comunicação Http
            //var evaluation = await WebClientFunctions.GetEvaluation(PIN);
            var evaluation = new Evaluation
            {
                Perguntas = new List<Question> { new Question { Pergunta = "Como foi a aula de hoje?" } },
            };
            await NavigationFunctions.PushAsync(new ClassEvaluationPage(evaluation));
        }
    }
}