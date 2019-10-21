using System;
namespace Feedbackapp.Model
{
    public class Evaluation
    {
        private int id;
        private string turma;
        private string ies;
        private string curso;
        private string pergunta;
        private decimal percentual;

        public int Id { get => id; set => id = value; }
        public string Turma { get => turma; set => turma = value; }
        public string Ies { get => ies; set => ies = value; }
        public string Curso { get => curso; set => curso = value; }
        public string Pergunta { get => pergunta; set => pergunta = value; }
        public decimal Percentual { get => percentual; set => percentual = value; }

        public Evaluation(int id, string turma, string ies, string curso, string pergunta, decimal percentual)
        {
            Id = id;
            Turma = turma;
            Ies = ies;
            Curso = curso;
            Pergunta = pergunta;
            Percentual = percentual;
        }

        public Evaluation(): this(0,"","","","",0)
        {
        }
    }
}
