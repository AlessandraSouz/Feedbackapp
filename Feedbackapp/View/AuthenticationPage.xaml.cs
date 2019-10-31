using System;
using System.Collections.Generic;
using Feedbackapp.ViewModel;
using Xamarin.Forms;

namespace Feedbackapp.View
{
    public partial class AuthenticationPage : ContentPage
    {
        public AuthenticationPage()
        {
            InitializeComponent();
            BindingContext = new AuthenticationPageViewModel();
        }
    }
}
