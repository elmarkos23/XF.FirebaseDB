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
                Model.Persona persona = new Model.Persona();
                persona.Identificacion = entID.Text;
                persona.Nombre = entNombre.Text;
                persona.FechaCrea = DateTime.Now;
                persona.FechaModifica = DateTime.Now;
                persona.Estado = true;
                persona.Direccion = "Llano Chico";
                persona.Telefono = "098765432";
                await new Firebase.PersonaFB().AddPerson(persona);
            
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

        private async void Reset_Clicked(object sender, EventArgs e)
        {
            await new Firebase.PersonaFB().Reset();
            fun();
        }
    }
}
