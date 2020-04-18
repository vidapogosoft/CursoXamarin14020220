using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CollectionView.Model;

using Xamarin.Essentials;

namespace CollectionView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public List<clsTiendas> AllTiendas;
        public List<clsProductos> AllProduct;
        public Home()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            AllTiendas = new List<clsTiendas>()
            { 
                  new clsTiendas
                  { 
                    Name = "Wallmart",
                    ImageUrl = "http://18.218.178.167/imagesemail/walmart.jpg"
                  },

                new clsTiendas
                {
                    Name = "Target",
                    ImageUrl = "http://18.218.178.167/imagesemail/target.jpg"
                },

                new clsTiendas
                {
                    Name = "Tienda",
                    ImageUrl = "http://18.218.178.167/imagesemail/tienda2.jpg"
                },

                new clsTiendas
                {
                    Name = "Ferreteria",
                    ImageUrl = "http://18.218.178.167/imagesemail/ferre1.jpg"
                },

                new clsTiendas
                {
                    Name = "Licorera",
                    ImageUrl = "http://18.218.178.167/imagesemail/cerve1.jpg"
                }
                
            };

            this.CTiendas.ItemsSource = AllTiendas;


            AllProduct = new List<clsProductos>()
            {
                  new clsProductos
                  {
                    NameProducto = "Colas",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/be/Bouteille_de_Coca-Cola_d%27un_litre_cinq_001.jpg/220px-Bouteille_de_Coca-Cola_d%27un_litre_cinq_001.jpg"
                  },

                  new clsProductos
                  {
                    NameProducto = "Snacks",
                    ImageUrl = "https://static.wixstatic.com/media/289d3f_db9d6047d4ca4a41a06d514b845dd428~mv2.png/v1/fill/w_684,h_443,al_c,lg_1,q_85/289d3f_db9d6047d4ca4a41a06d514b845dd428~mv2.webp"
                  },

                  new clsProductos
                  {
                    NameProducto = "Enlatados",
                    ImageUrl = "https://elmundoalinstante.com/wp-content/uploads/2017/07/imagen-sin-titulo-1.jpg"
                  },
            };

            this.CProductos.ItemsSource = AllProduct;

        }

        private void CTiendas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Any())
            {
                //Reset selection
                CTiendas.SelectedItem = null;

                DisplayAlert("Colletion View","Seleccion de Elemento de collection view","Ok");

            }
        }

        private void BtnLlamar_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open("0960574445");
        }

        private async void BtnEmail_Clicked(object sender, EventArgs e)
        {
            List<string> recibenEmail;
            recibenEmail = new List<string>();

            recibenEmail.Add("portugalarellano@hotmail.com");
            recibenEmail.Add("victor.portugal@sinergiass.com");

            var message = new EmailMessage
            {
                Subject = "Xamarin Essential Email",
                Body = "Curso de Xamarin Forms. Enviado desde: " + " " + DeviceInfo.Model + "-" + DeviceInfo.Name + "-" + DeviceInfo.Manufacturer,
                To = recibenEmail,
                //Cc = recibenEmail
            };

            await Email.ComposeAsync(message);
        }
    }
}