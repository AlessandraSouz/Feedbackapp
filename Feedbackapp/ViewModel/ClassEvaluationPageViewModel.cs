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

        private Evaluation _classEvaluation;
        public Evaluation ClassEvaluation { get { return _classEvaluation; } set { SetProperty(ref _classEvaluation, value); } }

        private string _pergunta;
        public string Pergunta { get { return _pergunta; } set { SetProperty(ref _pergunta, value); } }

        private int _index;
        public int Index { get { return _index; } set { SetProperty(ref _index, value); } }

        public Command BadCommand { get; private set; }
        public Command RegularCommand { get; private set; }
        public Command GoodCommand { get; private set; }
        public Command ExcellentCommand { get; private set; }

        public Command EvaluateCommand { get; private set; }

        public ClassEvaluationPageViewModel(Evaluation evaluation)
        {
            Evaluation = evaluation;
            Index = 0;
            Pergunta = ClassEvaluation.Perguntas.ToList()[Index].Pergunta;

            BadCommand = new Command(BadCommandTapped);
            RegularCommand = new Command(RegularCommandTapped);
            GoodCommand = new Command(GoodCommandTapped);
            ExcellentCommand = new Command(ExcellentCommandTapped);

            EvaluateCommand = new Command(EvaluateCommandTapped);
        }

        public async void BadCommandTapped()
        {
            Evaluation.Perguntas.ToList()[Index].Feedback = "Ruim";
            IndexPlus();
        }

        public async void RegularCommandTapped()
        {
            Evaluation.Perguntas.ToList()[Index].Feedback = "Regular";
            IndexPlus();
        }

        public async void GoodCommandTapped()
        {
            Evaluation.Perguntas.ToList()[Index].Feedback = "Bom";
            IndexPlus();
        }

        public async void ExcellentCommandTapped()
        {
            Evaluation.Perguntas.ToList()[Index].Feedback = "Excelente";
            IndexPlus();
        }

        public void IndexPlus()
        {
            if (Index < ClassEvaluation.Perguntas.Count())
            {
                Index++;
                Pergunta = ClassEvaluation.Perguntas.ToList()[Index].Pergunta;
            }
        }

        public async void EvaluateCommandTapped()
        {
            await WebClientFunctions.PostEvaluation(Evaluation);
            DisplayAlert("Sucesso!", "Sua avaliação foi entregue com sucesso!", "Ok");
            await Navigation.PopAsync();
        }
    }
}