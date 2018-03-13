using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Collections.ObjectModel;
using MenuHamburguesa.Models;
using Newtonsoft.Json;
using System.Diagnostics;

using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Internals;

namespace MenuHamburguesa.View
{
    public partial class ListaPage : ContentPage
    {
        HttpClient client = new HttpClient();
        private const string URL = "https://dl.dropbox.com/s/i8idhfiry89somx/posts.json?dl=0";
       
        private ObservableCollection<Personaje> _post;


        public ListaPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {

            if (CheckConnectivity() != true)
            {
                DisplayAlert("Alerta", "Parece que no hay internet, Revisa tu configuración", "ACEPTAR");
            }
            else
            {
                ConsultarYllenarLista();

            }
            base.OnAppearing();
        }


        public async void ConsultarYllenarLista()
        {
            var content = await client.GetStringAsync(URL); //obtener datos del string
            Debug.WriteLine("Consultado" + content);
            List<Personaje> posts = JsonConvert.DeserializeObject<List<Personaje>>(content); // deserializamos el contenido y lo guardamos en la variable posts
            Debug.WriteLine("Convirtiendo json" + posts);
            _post = new ObservableCollection<Personaje>(posts); //mandamos a post en un ObservableCollection y su contenido estará en _post para llenar el modelo

            foreach (var item in _post)
            {
                
                if (item.image == "")
                {
                     
                    if(Device.iOS == TargetPlatform.iOS.ToString())
                    {
                        item.image = "/Users/Johnny/Projects/AprendiendoXamarinForms/MenuHamburguesa/MenuHamburguesa/Imagenes/businessman2.png";
                        MyListView.ItemsSource = _post;
                    }
                    else
                    {
                        item.image = "businessman2.png";
                        MyListView.ItemsSource = _post;
                    }

                }
                else
                {
                    MyListView.ItemsSource = _post;
                }
            }
           

        }

        private Boolean CheckConnectivity()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
               // DisplayAlert("Alerta", "Si hay Internet", "ACEPTAR");
                return true;
            }
            else
            {
               // DisplayAlert("Alerta", "Parece que no hay internet, Revisa tu configuración", "ACEPTAR");
                return false;
            }
        }
        }
    }

