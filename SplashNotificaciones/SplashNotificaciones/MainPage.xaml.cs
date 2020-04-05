using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Plugin.LocalNotifications;

namespace SplashNotificaciones
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Directo_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("Notificaciones","Ejemplo de Noticiacion directa");
        }


        private void Delay_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("Notificaciones", "Ejemplo de Noticiacion con delay", 0, DateTime.Now.AddSeconds(5));
        }
    }
}
