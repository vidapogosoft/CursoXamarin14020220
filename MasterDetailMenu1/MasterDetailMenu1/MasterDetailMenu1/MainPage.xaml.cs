using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetailMenu1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyMenu();

        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;

            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }

        public void MyMenu()
        {
            Detail = new NavigationPage(new Home());
            List<Menu> menu = new List<Menu>
            {
                new Menu { Page = new Home(), MenuTitle = "Home" },
                new Menu { Page = new Cupones(), MenuTitle = "Cupones" },
                new Menu { Page = new Perfil(), MenuTitle = "Perfil" },
            };

            this.ListMenu.ItemsSource = menu;

        }

        public class Menu
        { 
            public string MenuTitle
            { get; set;}

            public Page Page
            { get; set; }
        }
    }
}
