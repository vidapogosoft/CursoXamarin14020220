using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SplashNotificaciones.Droid
{
    [Activity(Label = "Splash - Notificiaciones", MainLauncher = true, NoHistory = true, Icon = "@mipmap/icon", Theme = "@style/Theme.Splash")]
    public class SplashActivity1 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            StartActivity(typeof(MainActivity));
        }
    }
}