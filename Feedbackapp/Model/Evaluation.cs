using System.Collections.ObjectModel;

namespace Feedbackapp.Model
{
    public class Evaluation
    {
        private int id;
        private string pin;
        private string turma;
        private string ies;
        private string curso;
        private ObservableCollection<Question> pergunta;
        private string prof_email;
        private ObservableCollection<string> nomesAlunos;

        public int Id { get => id; set => id = value; }
        public string PIN { get => pin; set => pin = value; }
        public string Turma { get => turma; set => turma = value; }
        public string Ies { get => ies; set => ies = value; }
        public string Curso { get => curso; set => curso = value; }
        public ObservableCollection<Question> Perguntas { get => pergunta; set => pergunta = value; }
        public string Prof_Email { get => prof_email; set => prof_email = value; }
        public ObservableCollection<string> NomesAlunos { get => nomesAlunos; set => nomesAlunos = value; }

        public Evaluation(int id, string pin, string turma, string ies, string curso, ObservableCollection<Question> pergunta, string prof_email, ObservableCollection<string> nomesAlunos)
        {
            Id = id;
            PIN = pin;
            Turma = turma;
            Ies = ies;
            Curso = curso;
            Perguntas = pergunta;
            Prof_Email = prof_email;
            NomesAlunos = nomesAlunos;
        }

        public Evaluation() : this(0, "", "", "", "", null, "", null)
        {
        }
    }
}