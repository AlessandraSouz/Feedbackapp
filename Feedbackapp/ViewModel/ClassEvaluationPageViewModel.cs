using Feedbackapp.Functions;
using Feedbackapp.Model;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class ClassEvaluationPageViewModel : BaseViewModel
    {
        private string _name;
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }

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
            Name = string.Empty;

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
            pergunta.Feedbacks = new System.Collections.Generic.List<string>();
            pergunta.Feedbacks.Clear();
            pergunta.Feedbacks.Add("Ruim");

            pergunta.BadColored = true;
            pergunta.RegularColored = false;
            pergunta.GoodColored = false;
            pergunta.ExcellentColored = false;

            pergunta.BadGrey = false;
            pergunta.RegularGrey = true;
            pergunta.GoodGrey = true;
            pergunta.ExcellentGrey = true;

            Evaluation.Perguntas.Add(pergunta);
        }

        public async void RegularCommandTapped(Question pergunta)
        {
            //Remove da avaliação a pergunta sendo avaliada
            Evaluation.Perguntas.Remove(pergunta);
            //Adiciona a estrutura com o feedback novamente na avaliação
            pergunta.Feedbacks = new System.Collections.Generic.List<string>();
            pergunta.Feedbacks.Clear();
            pergunta.Feedbacks.Add("Regular");

            pergunta.BadColored = false;
            pergunta.RegularColored = true;
            pergunta.GoodColored = false;
            pergunta.ExcellentColored = false;

            pergunta.BadGrey = true;
            pergunta.RegularGrey = false;
            pergunta.GoodGrey = true;
            pergunta.ExcellentGrey = true;

            Evaluation.Perguntas.Add(pergunta);
        }

        public async void GoodCommandTapped(Question pergunta)
        {
            //Remove da avaliação a pergunta sendo avaliada
            Evaluation.Perguntas.Remove(pergunta);
            //Adiciona a estrutura com o feedback novamente na avaliação
            pergunta.Feedbacks = new System.Collections.Generic.List<string>();
            pergunta.Feedbacks.Clear();
            pergunta.Feedbacks.Add("Bom");

            pergunta.BadColored = false;
            pergunta.RegularColored = false;
            pergunta.GoodColored = true;
            pergunta.ExcellentColored = false;

            pergunta.BadGrey = true;
            pergunta.RegularGrey = true;
            pergunta.GoodGrey = false;
            pergunta.ExcellentGrey = true;

            Evaluation.Perguntas.Add(pergunta);
        }

        public async void ExcellentCommandTapped(Question pergunta)
        {
            //Remove da avaliação a pergunta sendo avaliada
            Evaluation.Perguntas.Remove(pergunta);
            //Adiciona a estrutura com o feedback novamente na avaliação
            pergunta.Feedbacks = new System.Collections.Generic.List<string>();
            pergunta.Feedbacks.Clear();
            pergunta.Feedbacks.Add("Excelente");

            pergunta.BadColored = false;
            pergunta.RegularColored = false;
            pergunta.GoodColored = false;
            pergunta.ExcellentColored = true;

            pergunta.BadGrey = true;
            pergunta.RegularGrey = true;
            pergunta.GoodGrey = true;
            pergunta.ExcellentGrey = false;

            Evaluation.Perguntas.Add(pergunta);
        }

        public async void EvaluateCommandTapped()
        {
            try
            {
                Evaluation.NomesAlunos = new System.Collections.ObjectModel.ObservableCollection<string> { Name };
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