using System;
using System.Collections.Generic;
using Feedbackapp.ViewModel;
using Xamarin.Forms;

namespace Feedbackapp.View
{
    public partial class EvaluationHistoryPage : ContentPage
    {
        public EvaluationHistoryPage()
        {
            InitializeComponent();
            BindingContext = new EvaluationHistoryPageViewModel();
        }
    }
}
