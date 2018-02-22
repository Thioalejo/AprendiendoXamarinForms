using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Collections.ObjectModel;
using MenuHamburguesa.Models;
using Newtonsoft.Json;
using System.Diagnostics;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace MenuHamburguesa.View
{
    public partial class ListaPage : ContentPage
    {
        HttpClient client = new HttpClient();
        private const string URL = "http://jsonplaceholder.typicode.com/posts";
       
        private ObservableCollection<Model_Post> _post;


        public ListaPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            try
            {
                var content = await client.GetStringAsync(URL); //obtener datos del string
                Debug.WriteLine("Consultado"+content);
               
                List<Model_Post> posts = JsonConvert.DeserializeObject<List<Model_Post>>(content); // deserializamos el contenido y lo guardamos en la variable posts
                Debug.WriteLine("Convirtiendo json");
                _post = new ObservableCollection<Model_Post>(posts); //mandamos a post en un ObservableCollection y su contenido estará en _post para llenar el modelo




                MyListView.ItemsSource = _post;


               
               

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error generado" + ex.Message);
            }
           
            base.OnAppearing();
        }

       

    }
}
