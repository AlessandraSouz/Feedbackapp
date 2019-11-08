using System.Linq;
using Feedbackapp.Functions;
using Feedbackapp.Model;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class ClassEvaluationPageViewModel : BaseViewModel
    {
        private Evaluation _evaluation;
        public Evaluation Evaluation { get { return _evaluation; } set { SetProperty(ref _evaluation, value); } }

        public Command<Question> BadCommand { get; private set; }
        public Command<Question> RegularCommand { get; private set; }
        public Command<Question> GoodCommand { get; private set; }
        public Command<Question> ExcellentCommand { get; private set; }

        public Command EvaluateCommand { get; private set; }

        public ClassEvaluationPageViewModel(Evaluation evaluation)
        {
            Evaluation = evaluation;

            BadCommand = new Command<Question>(BadCommandTapped);
            RegularCommand = new Command<Question>(RegularCommandTapped);
            GoodCommand = new Command<Question>(GoodCommandTapped);
            ExcellentCommand = new Command<Question>(ExcellentCommandTapped);

            EvaluateCommand = new Command(EvaluateCommandTapped);
        }

        public async void BadCommandTapped(Question pergunta)
        {
            //Remove da avaliação a pergunta sendo avaliada
            Evaluation.Perguntas.Remove(pergunta);
            //Adiciona a estrutura com o feedback novamente na avaliação
            pergunta.Feedback = "Ruim";
            Evaluation.Perguntas.Add(pergunta);
        }

        public async void RegularCommandTapped(Question pergunta)
        {
            //Remove da avaliação a pergunta sendo avaliada
            Evaluation.Perguntas.Remove(pergunta);
            //Adiciona a estrutura com o feedback novamente na avaliação
            pergunta.Feedback = "Regular";
            Evaluation.Perguntas.Add(pergunta);
        }

        public async void GoodCommandTapped(Question pergunta)
        {
            //Remove da avaliação a pergunta sendo avaliada
            Evaluation.Perguntas.Remove(pergunta);
            //Adiciona a estrutura com o feedback novamente na avaliação
            pergunta.Feedback = "Bom";
            Evaluation.Perguntas.Add(pergunta);
        }

        public async void ExcellentCommandTapped(Question pergunta)
        {
            //Remove da avaliação a pergunta sendo avaliada
            Evaluation.Perguntas.Remove(pergunta);
            //Adiciona a estrutura com o feedback novamente na avaliação
            pergunta.Feedback = "Excelente";
            Evaluation.Perguntas.Add(pergunta);
        }

        public async void EvaluateCommandTapped()
        {
            //TODO: publicar WebAPI para utilizar funções de comunicação Http
            //await WebClientFunctions.PostEvaluation(Evaluation);
            DisplayAlert("Sucesso!", "Sua avaliação foi entregue com sucesso!", "Ok");
            await NavigationFunctions.PopAsync();
        }
    }
}