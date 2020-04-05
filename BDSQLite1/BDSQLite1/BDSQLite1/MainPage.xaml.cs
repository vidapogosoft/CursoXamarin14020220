using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BDSQLite1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var toolbaritem = new ToolbarItem
            {

                Text = "Agregar (+)"
            };

            toolbaritem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new AddStudent()
                { 
                     BindingContext = new Student()
                });

            };

            ToolbarItems.Add(toolbaritem);

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            this.StdList.ItemsSource = await App.Database.GetStudentsAsync();

        }

        private async void StdList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EditStudent()
                {
                    BindingContext = e.SelectedItem as Student
                }); ;
            }
        }
    }
}
