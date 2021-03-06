﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BDSQLite1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddStudent : ContentPage
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            var stdNew = (Student)BindingContext;
            await App.Database.SaveStudentAsync(stdNew);
            await Navigation.PopAsync();
        }
    }
}