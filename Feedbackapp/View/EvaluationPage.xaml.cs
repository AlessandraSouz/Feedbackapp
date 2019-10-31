using System;
using System.Collections.Generic;
using Feedbackapp.ViewModel;
using Xamarin.Forms;

namespace Feedbackapp.View
{
    public partial class EvaluationPage : ContentPage
    {
        public EvaluationPage()
        {
            InitializeComponent();
            BindingContext = new EvaluationPageViewModel();
        }
    }
}
