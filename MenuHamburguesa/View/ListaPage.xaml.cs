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

namespace MenuHamburguesa.View
{
    public partial class ListaPage : ContentPage
    {
        HttpClient client = new HttpClient();
        private const string URL = "http://dl.dropboxusercontent.com/s/sjhj5zuxfu87vz5/Archivo.json?dl=0";
       
        private List<Personajes> _post;


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
           

            List<Personajes> posts = JsonConvert.DeserializeObject<List<Personajes>>(content); // deserializamos el contenido y lo guardamos en la variable posts
            Debug.WriteLine("Convirtiendo json" + posts);
            _post = new List<Personajes>(posts); //mandamos a post en un ObservableCollection y su contenido estará en _post para llenar el modelo

            MyListView.ItemsSource = _post;
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

