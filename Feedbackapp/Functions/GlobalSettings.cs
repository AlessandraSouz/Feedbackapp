using Feedbackapp.Model;

namespace Feedbackapp.Functions
{
    public static class GlobalSettings
    {
        public static User LoggedUser { get; private set; }

        static GlobalSettings()
        {
            LoggedUser = new User();
        }

        public static void LoggedIn(User user)
        {
            LoggedUser = user;
        }

        public static void LoggedOut()
        {
            LoggedUser = new User();
        }
    }
}
