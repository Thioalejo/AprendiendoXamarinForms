using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MenuHamburguesa
{
    public partial class HamburgerMenu : MasterDetailPage
    {
        

        public HamburgerMenu()
        {
            /* MainPage = new NavigationPage(new HamburgerMenu())
             {
                 BarBackgroundColor = Color.FromHex("#ff5300"),
                 BarTextColor = Color.White,
             };*/

            InitializeComponent();
            MyMenu();
        }

        public void MyMenu()
        {
            Detail = new NavigationPage(new Feed());

            List<Menu> menu = new List<Menu>
            {
                new Menu {Page  = new Feed(), MenuTitle="My Profile", MenuDatail="Mi Perfil", icon="user.png"},
                new Menu {Page  = new Feed(), MenuTitle="Messages", MenuDatail="Mensajes", icon="message.png"},
                new Menu {Page  = new Feed(), MenuTitle="Contacts", MenuDatail="Contactos", icon="contacts.png"},
                new Menu {Page  = new Feed(), MenuTitle="Settings", MenuDatail="Configuración", icon="settings.png"},
            };

            ListMenu.ItemsSource = menu;

            /*Device.OnPlatform(iOS: () =>
            {
                ListMenu.Margin = new Thickness(0, 0, 0, 0);
            }, Android: () =>
              {
                ListMenu.Margin = new Thickness(0, 0, 0, 0);

              });

            Detail = new NavigationPage(new Feed());*/
        }


        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                if (menu.MenuTitle.Equals("My Profile"))
                {
                    IsPresented = false;
                    //Device.OpenUri(new Uri("http://example.com"));
                    Detail = new NavigationPage(new Feed());
                }
                else if (menu.MenuTitle.Equals("Messages"))
                {
                    IsPresented = false;
                    Detail = new NavigationPage(new HamburgerMenuPage2());
                }
                else
                {
                    DisplayAlert("Alerta", "En mantenimiento", "ACEPTAR");
                }
            }
        }


        public class Menu
        {
            public string MenuTitle
            {
                get;
                set;
            }

            public String MenuDatail
            {
                get;
                set;
            }

            public ImageSource icon
            {
                get;
                set;
            }

            public Page Page
            {
                get;
                set;
            }
        }


    }
}
