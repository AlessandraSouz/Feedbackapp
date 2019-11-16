using Feedbackapp.Model;
using Feedbackapp.ViewModel;
using Xamarin.Forms;

namespace Feedbackapp.View
{
    public partial class EvaluationDetailPage : ContentPage
    {
        public EvaluationDetailPage(Evaluation evaluation)
        {
            InitializeComponent();
            BindingContext = new EvaluationDetailPageViewModel(evaluation);
        }
    }
}
