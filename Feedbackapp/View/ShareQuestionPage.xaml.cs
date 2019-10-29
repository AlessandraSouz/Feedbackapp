using Feedbackapp.ViewModel;
using Xamarin.Forms;

namespace Feedbackapp.View
{
    public partial class ShareQuestionPage : ContentPage
    {
        public ShareQuestionPage(string PIN)
        {
            InitializeComponent();
            BindingContext = new ShareQuestionPageViewModel(PIN);
        }
    }
}