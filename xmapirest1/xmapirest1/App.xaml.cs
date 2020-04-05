using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using xmapirest1.Data;
using xmapirest1.Views;

namespace xmapirest1
{
    public partial class App : Application
    {
        public static TodoItemManager TodoManger { get; set; }

        public App()
        {
            InitializeComponent();
            TodoManger = new TodoItemManager(new RestService());
            //MainPage = new MainPage();
            MainPage = new NavigationPage(new TodoListPage());
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
