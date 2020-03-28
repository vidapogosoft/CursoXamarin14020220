using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;


namespace TabbedPageMenu1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitialPluginLocator();
        }

        public void MostrarPosMapa(double Latitud, double Longitud)
        {
            base.OnAppearing();

            //Posicion en el mapa
            this.MapaGeoLocal.MoveToRegion(

                MapSpan.FromCenterAndRadius
                (
                    new Xamarin.Forms.Maps.Position(Latitud, Longitud),
                    Distance.FromKilometers(0.5)
                 )
                );

            var pos = new Xamarin.Forms.Maps.Position(Latitud, Longitud);

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = pos,
                Label = "Curso - Xamarin - SIPECOM ONLINE"
            };

            this.MapaGeoLocal.Pins.Add(pin);

        }

        private async void InitialPluginLocator()
        {
            try
            {
                //Validar el GPS si esta habilitado
                if (!CrossGeolocator.IsSupported)
                {
                    await DisplayAlert("Advertencia","GPS no habilitado.","Cerrar");
                    return;
                }

                //Servicios de ubicacion activados
                if (!CrossGeolocator.Current.IsGeolocationAvailable || !CrossGeolocator.Current.IsGeolocationEnabled)
                {
                    await DisplayAlert("Advertencia", "Servicios de ubicacion no habilitados.", "Cerrar");
                    return;
                }

                //Realizo la geolacalizacion
                CrossGeolocator.Current.PositionChanged += Current_PositionChanged;

                await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0,0,5), 0.5);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
            
        }

        private void Current_PositionChanged(object sender, PositionEventArgs e)
        {
            //metodo que obtiene las coordenadas
            if (!CrossGeolocator.Current.IsListening)
            {
                DisplayAlert("Advertencia", "No se visualiza coordenadas.", "Cerrar");
                return;
            }

            //Muestro las coordenadas en pantalla
            var coordenadas = CrossGeolocator.Current.GetPositionAsync();
            this.altimetria.Text = coordenadas.Result.Altitude.ToString();
            this.latitud.Text = coordenadas.Result.Latitude.ToString();
            this.longitud.Text = coordenadas.Result.Longitude.ToString();

            //Muestro en mapa las corrdenadas geolocalizadas
            MostrarPosMapa(coordenadas.Result.Latitude, coordenadas.Result.Longitude);
        }
    }
}
