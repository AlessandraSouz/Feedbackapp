using System;
namespace Feedbackapp.Model
{
    public class Question
    {
        private int id;
        private string pergunta;
        private string feedback;

        public int Id { get => id; set => id = value; }
        public string Pergunta { get => pergunta; set => pergunta = value; }
        public string Feedback { get => feedback; set => feedback = value; }

        public Question(int id, string pergunta, string feedback)
        {
            Id = id;
            Pergunta = pergunta;
            Feedback = feedback;
        }

        public Question() : this(0, "", "")
        {
        }
    }
}