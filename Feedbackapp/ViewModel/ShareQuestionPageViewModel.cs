using System;
namespace Feedbackapp.ViewModel
{
    public class ShareQuestionPageViewModel : BaseViewModel
    {
        private string pin;
        public string PIN { get { return pin; } set { SetProperty(ref pin, value); } }

        public ShareQuestionPageViewModel(string sharePin)
        {
            PIN = sharePin;
        }
    }
}