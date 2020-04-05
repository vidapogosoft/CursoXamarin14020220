using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDSQLite1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditStudent : ContentPage
    {
        public EditStudent()
        {
            InitializeComponent();
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            var updStud = (Student)BindingContext;

            await App.Database.UpdateStudentAsync(updStud);
            await Navigation.PopAsync();
        }

        private async void BtnDel_Clicked(object sender, EventArgs e)
        {
           bool aceptar =  await DisplayAlert("Confirmar","Seguro desea eliminar el registro.?","Si","No");

            if (aceptar)
            {
                var delStud = (Student)BindingContext;
                await App.Database.DelStudentAsync(delStud);
                await Navigation.PopAsync();
            }

            await Navigation.PushAsync(new AddStudent());

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}