using System;
namespace Feedbackapp.Model
{
    public class Question
    {
        private int id;
        private string pergunta;
        private string alternativaA;
        private string alternativaB;
        private string alternativaC;
        private string alternativaD;

        public int Id { get => id; set => id = value; }
        public string Pergunta { get => pergunta; set => pergunta = value; }
        public string AlternativaA { get => alternativaA; set => alternativaA = value; }
        public string AlternativaB { get => alternativaB; set => alternativaB = value; }
        public string AlternativaC { get => alternativaC; set => alternativaC = value; }
        public string AlternativaD { get => alternativaD; set => alternativaD = value; }

        public Question(int id, string pergunta, string alternativaA, string alternativaB, string alternativaC, string alternativaD)
        {
            Id = id;
            Pergunta = pergunta;
            AlternativaA = alternativaA;
            AlternativaB = alternativaB;
            AlternativaC = alternativaC;
            AlternativaD = alternativaD;
        }

        public Question(): this(0,"","","","","")
        {
        }
    }
}
