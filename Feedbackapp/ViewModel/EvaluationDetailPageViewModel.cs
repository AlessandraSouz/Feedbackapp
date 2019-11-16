using Feedbackapp.Model;

namespace Feedbackapp.ViewModel
{
    public class EvaluationDetailPageViewModel : BaseViewModel
    {
        private Evaluation _evaluation;
        public Evaluation Evaluation { get { return _evaluation; } set { SetProperty(ref _evaluation, value); } }

        public EvaluationDetailPageViewModel(Evaluation evaluation)
        {
            Evaluation = evaluation;
        }
    }
}