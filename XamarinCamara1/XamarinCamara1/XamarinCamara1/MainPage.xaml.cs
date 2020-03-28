using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Plugin.Media;
using Plugin.Media.Abstractions;

namespace XamarinCamara1
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

        private async void BtnTomaFotos_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Camara no habilitada", "Revise sus dispositivo", "Cerrar");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    { 
                        SaveToAlbum = true,
                        //PhotoSize = PhotoSize.Medium,
                        PhotoSize = PhotoSize.Custom,
                        CustomPhotoSize = 80
                    }                    
                    );

                if (file == null)
                {
                    await DisplayAlert("Camara","No realizo captura de foto.","Cerrar");
                    return;
                }

                this.PathLabel.Text = "la ruta de la foto es: " + file.AlbumPath;

                this.MainImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                }
                );

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }

        private async void BtnGrabaVideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
                {
                    await DisplayAlert("Camara no habilitada", "Revisar su dispositivo.", "Cerrar");
                    return;
                }

                var file = await CrossMedia.Current.TakeVideoAsync(
                    new StoreVideoOptions
                    {
                        SaveToAlbum = true
                    });

                if (file == null)
                {
                    await DisplayAlert("Camara", "No grabo video.", "Cerrar");
                    return;
                }

                this.PathLabel.Text = "la ruta del video es: " + file.AlbumPath;

            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }

        private async void BtnSubeFoto_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Camara no habilitada", "No tiene permisos.", "Cerrar");
                    return;
                }

                //Seleccion de un elemento de la galeria

                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null)
                {
                    await DisplayAlert("Camara", "No selecciono foto.", "Cerrar");
                    return;
                }

                this.PathLabel.Text = "Ruta de la foto: " + file.Path;

                this.MainImage.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });



            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }

        private async void BtnSubeVideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsTakeVideoSupported)
                {
                    await DisplayAlert("Video no habilitado", "No tiene permisos.", "Cerrar");
                    return;
                }

                //Seleccion de un elemento de la galeria

                var file = await CrossMedia.Current.PickVideoAsync();

                if (file == null)
                {
                    await DisplayAlert("Camara", "No selecciono video.", "Cerrar");
                    return;
                }

                this.PathLabel.Text = "Ruta del video: " + file.Path;


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }
        }
    }
}
