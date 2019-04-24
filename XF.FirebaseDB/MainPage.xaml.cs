using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF.FirebaseDB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            fun();
        }

        private async void ButAdd_Clicked(object sender, EventArgs e)
        {
            for (int i=0; i<500;i++)
            {
                Model.Persona persona = new Model.Persona();
                persona.ID = Convert.ToInt32(entID.Text)+i;
                persona.Nombre = entNombre.Text;
                await new Firebase.PersonaFB().AddPerson(persona);
                
            }
            await DisplayAlert("Mensaje", "Grabado", "OK");
            fun();
        }
        private async void fun()
        {
            List<Model.Persona> ls = new List<Model.Persona>();
            ls = await new Firebase.PersonaFB().GetAllPersons();
            lblTotal.Text = ls.Count.ToString();
            lvDatos.ItemsSource = ls;
        }
    }
}
