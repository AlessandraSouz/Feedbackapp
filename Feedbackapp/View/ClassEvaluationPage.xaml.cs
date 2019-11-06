using Feedbackapp.Model;
using Feedbackapp.ViewModel;

using Xamarin.Forms;

namespace Feedbackapp.View
{
    public partial class ClassEvaluationPage : ContentPage
    {
        public ClassEvaluationPage(Evaluation evaluation)
        {
            InitializeComponent();
            BindingContext = new ClassEvaluationPageViewModel(evaluation);
        }
    }
}
