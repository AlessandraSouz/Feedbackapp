using Feedbackapp.ViewModel;
using Xamarin.Forms;

namespace Feedbackapp.View
{
    public partial class PasswordRecoveryPage : ContentPage
    {
        public PasswordRecoveryPage()
        {
            InitializeComponent();
            BindingContext = new PasswordRecoveryPageViewModel();
        }
    }
}
