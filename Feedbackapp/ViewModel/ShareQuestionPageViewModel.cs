using System;
namespace Feedbackapp.ViewModel
{
    public class ShareQuestionPageViewModel : BaseViewModel
    {
        private string _pin;
        public string PIN { get { return _pin; } set { SetProperty(ref _pin, value); } }

        public ShareQuestionPageViewModel(string sharePin)
        {
            PIN = sharePin;
        }
    }
}