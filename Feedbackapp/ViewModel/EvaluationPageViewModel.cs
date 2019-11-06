using System;
using System.Collections.ObjectModel;
using Feedbackapp.Functions;
using Feedbackapp.Model;
using Feedbackapp.View;
using Xamarin.Forms;

namespace Feedbackapp.ViewModel
{
    public class EvaluationPageViewModel : BaseViewModel
    {
        private string _turma;
        public string Turma { get { return _turma; } set { SetProperty(ref _turma, value); } }
        private string _ies;
        public string IES { get { return _ies; } set { SetProperty(ref _ies, value); } }
        private string _turno;
        public string Turno { get { return _turno; } set { SetProperty(ref _turno, value); } }
        private string _curso;
        public string Curso { get { return _curso; } set { SetProperty(ref _curso, value); } }
        private string _pergunta;
        public string Pergunta { get { return _pergunta; } set { SetProperty(ref _pergunta, value); } }

        private ObservableCollection<Question> _lsPerguntas;
        public ObservableCollection<Question> LsPerguntas { get { return _lsPerguntas; } set { SetProperty(ref _lsPerguntas, value); } }

        public Command AddQuestion { get; private set; }
        public Command ShareQuestion { get; private set; }

        public EvaluationPageViewModel()
        {
            AddQuestion = new Command(AddQuestionTapped);
            ShareQuestion = new Command(ShareQuestionTapped);
            LsPerguntas = new ObservableCollection<Question>();
        }

        private void AddQuestionTapped()
        {
            var pergunta = new Question { Pergunta = Pergunta };

            LsPerguntas.Add(pergunta);
            Pergunta = String.Empty;
        }

        private async void ShareQuestionTapped()
        {
            Evaluation evaluation = new Evaluation
            {
                Curso = Curso,
                Ies = IES,
                Perguntas = LsPerguntas,
                PIN = GerarPIN(),
                Turma = Turma
            };

            await WebClientFunctions.PostEvaluation(evaluation);
            await NavigationFunctions.PushAsync(new ShareQuestionPage(evaluation.PIN));
        }

        private string GerarPIN()
        {
            Random rd = new Random();
            int pin = rd.Next(0, 999999);
            var result = pin.ToString().PadLeft(6, '0');
            return result;
        }
    }
}