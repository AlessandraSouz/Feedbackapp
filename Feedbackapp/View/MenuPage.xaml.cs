using System;
using System.Collections.Generic;
using Feedbackapp.ViewModel;

using Xamarin.Forms;

namespace Feedbackapp.View
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = new MenuPageViewModel();
        }
    }
}
