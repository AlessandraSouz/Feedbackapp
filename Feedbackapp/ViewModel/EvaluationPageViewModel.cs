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
        private string turma;
        public string Turma { get { return turma; } set { SetProperty(ref turma, value); } }
        private string ies;
        public string IES { get { return ies; } set { SetProperty(ref ies, value); } }
        private string turno;
        public string Turno { get { return turno; } set { SetProperty(ref turno, value); } }
        private string curso;
        public string Curso { get { return curso; } set { SetProperty(ref curso, value); } }
        private string pergunta;
        public string Pergunta { get { return pergunta; } set { SetProperty(ref pergunta, value); } }
        private string alternativaA;
        public string AlternativaA { get { return alternativaA; } set { SetProperty(ref alternativaA, value); } }
        private string alternativaB;
        public string AlternativaB { get { return alternativaB; } set { SetProperty(ref alternativaB, value); } }
        private string alternativaC;
        public string AlternativaC { get { return alternativaC; } set { SetProperty(ref alternativaC, value); } }
        private string alternativaD;
        public string AlternativaD { get { return alternativaD; } set { SetProperty(ref alternativaD, value); } }
        private ObservableCollection<string> listaPerguntas;
        public ObservableCollection<string> ListaPerguntas { get { return listaPerguntas; } set { SetProperty(ref listaPerguntas, value); } }

        private ObservableCollection<Question> LsPerguntas { get; set; }

        public Command AddQuestion { get; private set; }
        public Command ShareQuestion { get; private set; }

        public EvaluationPageViewModel()
        {
            AddQuestion = new Command(AddQuestionTapped);
            ShareQuestion = new Command(ShareQuestionTapped);
        }

        private void AddQuestionTapped()
        {
            var pergunta = new Question
            {
                Pergunta = Pergunta,
                AlternativaA = AlternativaA,
                AlternativaB = AlternativaB,
                AlternativaC = AlternativaC,
                AlternativaD = AlternativaD,
            };

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

            await WebClientFunctions.Post(evaluation);
            await Navigation.PushAsync(new ShareQuestionPage(evaluation.PIN));
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