using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using xmapirest1.Model;

namespace xmapirest1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemPage : ContentPage
    {
        bool isNewItem;

        public TodoItemPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }

        private async void save_Clicked(object sender, EventArgs e)
        {
            var todo = (TodoItem)BindingContext;
            await App.TodoManger.SaveTask(todo, isNewItem);
            await Navigation.PopAsync();
        }

        private void del_Clicked(object sender, EventArgs e)
        {

        }
    }
}