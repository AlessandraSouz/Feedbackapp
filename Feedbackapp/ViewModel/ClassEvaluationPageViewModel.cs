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

        private bool _badColored;
        public bool BadColored { get { return _badColored; } set { SetProperty(ref _badColored, value); } }
        private bool _regularColored;
        public bool RegularColored { get { return _regularColored; } set { SetProperty(ref _regularColored, value); } }
        private bool _goodColored;
        public bool GoodColored { get { return _goodColored; } set { SetProperty(ref _goodColored, value); } }
        private bool _excellentColored;
        public bool ExcellentColored { get { return _excellentColored; } set { SetProperty(ref _excellentColored, value); } }

        private bool _badgrey;
        public bool BadGrey { get { return _badgrey; } set { SetProperty(ref _badgrey, value); } }
        private bool _regulargrey;
        public bool RegularGrey { get { return _regulargrey; } set { SetProperty(ref _regulargrey, value); } }
        private bool _goodgrey;
        public bool GoodGrey { get { return _goodgrey; } set { SetProperty(ref _goodgrey, value); } }
        private bool _excellentgrey;
        public bool ExcellentGrey { get { return _excellentgrey; } set { SetProperty(ref _excellentgrey, value); } }

        public Command EvaluateCommand { get; private set; }

        public ClassEvaluationPageViewModel(Evaluation evaluation)
        {
            Evaluation = evaluation;

            BadColored = true;
            RegularColored = true;
            GoodColored = true;
            ExcellentColored = true;

            BadGrey = false;
            RegularGrey = false;
            GoodGrey = false;
            ExcellentGrey = false;

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

            BadColored = true;
            RegularColored = false;
            GoodColored = false;
            ExcellentColored = false;

            BadGrey = false;
            RegularGrey = true;
            GoodGrey = true;
            ExcellentGrey = true;
        }

        public async void RegularCommandTapped(Question pergunta)
        {
            //Remove da avaliação a pergunta sendo avaliada
            Evaluation.Perguntas.Remove(pergunta);
            //Adiciona a estrutura com o feedback novamente na avaliação
            pergunta.Feedback = "Regular";
            Evaluation.Perguntas.Add(pergunta);

            BadColored = false;
            RegularColored = true;
            GoodColored = false;
            ExcellentColored = false;

            BadGrey = true;
            RegularGrey = false;
            GoodGrey = true;
            ExcellentGrey = true;
        }

        public async void GoodCommandTapped(Question pergunta)
        {
            //Remove da avaliação a pergunta sendo avaliada
            Evaluation.Perguntas.Remove(pergunta);
            //Adiciona a estrutura com o feedback novamente na avaliação
            pergunta.Feedback = "Bom";
            Evaluation.Perguntas.Add(pergunta);

            BadColored = false;
            RegularColored = false;
            GoodColored = true;
            ExcellentColored = false;

            BadGrey = true;
            RegularGrey = true;
            GoodGrey = false;
            ExcellentGrey = true;
        }

        public async void ExcellentCommandTapped(Question pergunta)
        {
            //Remove da avaliação a pergunta sendo avaliada
            Evaluation.Perguntas.Remove(pergunta);
            //Adiciona a estrutura com o feedback novamente na avaliação
            pergunta.Feedback = "Excelente";
            Evaluation.Perguntas.Add(pergunta);

            BadColored = false;
            RegularColored = false;
            GoodColored = false;
            ExcellentColored = true;

            BadGrey = true;
            RegularGrey = true;
            GoodGrey = true;
            ExcellentGrey = false;
        }

        public async void EvaluateCommandTapped()
        {
            try
            {
                await WebClientFunctions.PutEvaluation(Evaluation);
                DisplayAlert("Sucesso!", "Sua avaliação foi entregue com sucesso!", "Ok");
                await NavigationFunctions.PopAsync();
            }
            catch (System.Exception ex)
            {
                DisplayAlert("Erro", "Não foi possível conectar com o servidor", "Ok");
            }
        }
    }
}