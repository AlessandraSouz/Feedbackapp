using Feedbackapp.ViewModel;

using Xamarin.Forms;

namespace Feedbackapp.View
{
    public partial class PinEvaluationPage : ContentPage
    {
        public PinEvaluationPage()
        {
            InitializeComponent();
            BindingContext = new PinEvaluationPageViewModel();
        }
    }
}
