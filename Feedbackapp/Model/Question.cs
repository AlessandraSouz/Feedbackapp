using System.Collections.Generic;
using Newtonsoft.Json;

namespace Feedbackapp.Model
{
    public class Question
    {
        private int id;
        private string pergunta;
        private List<string> feedbacks;
        private int badCount;
        private int regularCount;
        private int goodCount;
        private int excellentCount;
        private string pin;

        public int Id { get => id; set => id = value; }
        public string Pergunta { get => pergunta; set => pergunta = value; }
        public List<string> Feedbacks { get => feedbacks; set => feedbacks = value; }
        public string PIN { get => pin; set => pin = value; }

        private bool _badColored;
        [JsonIgnore] public bool BadColored { get { return _badColored; } set { _badColored = value; } }
        private bool _regularColored;
        [JsonIgnore] public bool RegularColored { get { return _regularColored; } set { _regularColored = value; } }
        private bool _goodColored;
        [JsonIgnore] public bool GoodColored { get { return _goodColored; } set { _goodColored = value; } }
        private bool _excellentColored;
        [JsonIgnore] public bool ExcellentColored { get { return _excellentColored; } set { _excellentColored = value; } }

        private bool _badgrey;
        [JsonIgnore] public bool BadGrey { get { return _badgrey; } set { _badgrey = value; } }
        private bool _regulargrey;
        [JsonIgnore] public bool RegularGrey { get { return _regulargrey; } set { _regulargrey = value; } }
        private bool _goodgrey;
        [JsonIgnore] public bool GoodGrey { get { return _goodgrey; } set { _goodgrey = value; } }
        private bool _excellentgrey;
        [JsonIgnore] public bool ExcellentGrey { get { return _excellentgrey; } set { _excellentgrey = value; } }

        public int BadCount { get => badCount; set => badCount = value; }
        public int RegularCount { get => regularCount; set => regularCount = value; }
        public int GoodCount { get => goodCount; set => goodCount = value; }
        public int ExcellentCount { get => excellentCount; set => excellentCount = value; }

        public Question(int id, string pergunta, List<string> feedbacks, string pin)
        {
            Id = id;
            Pergunta = pergunta;
            Feedbacks = feedbacks;
            PIN = pin;

            BadColored = true;
            RegularColored = true;
            GoodColored = true;
            ExcellentColored = true;

            BadGrey = false;
            RegularGrey = false;
            GoodGrey = false;
            ExcellentGrey = false;
        }

        public Question() : this(0, "", null, "")
        {
        }
    }
}