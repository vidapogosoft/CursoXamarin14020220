using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDSQLite1
{
    public partial class App : Application
    {
        static StudDB database;

        public static StudDB Database
        {
            get {
                if (database == null)
                {
                    database = new StudDB(DependencyService.Get<IStdLocHelper>().GetLocalFilePath("studentdata.db"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            MainPage = new  NavigationPage(new MainPage());
        }

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
