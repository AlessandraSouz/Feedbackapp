using System;
using System.Collections.Generic;
using Feedbackapp.ViewModel;
using Xamarin.Forms;

namespace Feedbackapp.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
