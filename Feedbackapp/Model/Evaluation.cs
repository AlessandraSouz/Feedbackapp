using System.Collections.Generic;

namespace Feedbackapp.Model
{
    public class Evaluation
    {
        private int id;
        private string pin;
        private string turma;
        private string ies;
        private string curso;
        private IEnumerable<Question> pergunta;
        private decimal percentual;

        public int Id { get => id; set => id = value; }
        public string PIN { get => pin; set => pin = value; }
        public string Turma { get => turma; set => turma = value; }
        public string Ies { get => ies; set => ies = value; }
        public string Curso { get => curso; set => curso = value; }
        public IEnumerable<Question> Perguntas { get => pergunta; set => pergunta = value; }
        public decimal Percentual { get => percentual; set => percentual = value; }

        public Evaluation(int id, string pin, string turma, string ies, string curso, IEnumerable<Question> pergunta, decimal percentual)
        {
            Id = id;
            PIN = pin;
            Turma = turma;
            Ies = ies;
            Curso = curso;
            Perguntas = pergunta;
            Percentual = percentual;
        }

        public Evaluation() : this(0, "", "", "", "", null, 0)
        {
        }
    }
}