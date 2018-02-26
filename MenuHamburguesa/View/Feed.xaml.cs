using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using MenuHamburguesa.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace MenuHamburguesa
{
    public partial class Feed : TabbedPage
    {
        private const string URL = "http://jsonplaceholder.typicode.com/posts";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Model_Post> _post;

        Models.Model_Post modelo = new Models.Model_Post();
        public Feed()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            if(CheckConnectivity()!=true)
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
                List<Model_Post> posts = JsonConvert.DeserializeObject<List<Model_Post>>(content); // deserializamos el contenido y lo guardamos en la variable posts
                _post = new ObservableCollection<Model_Post>(posts); //mandamos a post en un ObservableCollection y su contenido estará en _post para llenar el modelo

                /* foreach (var item in _post)
                 {
                     modelo.Id= item.Id;
                     modelo.Title = item.Title;
                 }*/

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

