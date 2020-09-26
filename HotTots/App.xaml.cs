using HotTots.Droid;
using Xamarin.Forms;

namespace HotTots
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new StudentPage());
        }
        //public static Page GetMainPage()
       
        //    var database = new thsNamesDb();

        //    return new NavigationPage(new StudentNames(database));
        //}
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
