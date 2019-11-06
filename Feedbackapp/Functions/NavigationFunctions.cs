using System.Threading.Tasks;
using Xamarin.Forms;

namespace Feedbackapp.Functions
{
    public class NavigationFunctions
    {
        private static INavigation Navigation = Application.Current.MainPage.Navigation;

        public static async Task PushAsync(Page page) => await Navigation.PushAsync(page);
        public static async Task PopAsync() => await Navigation.PopAsync();
        public static void RemovePage(Page page) => Navigation.RemovePage(page);
        public static void InsertPageBefore(Page page, Page before) => Navigation.InsertPageBefore(page, before);
    }
}