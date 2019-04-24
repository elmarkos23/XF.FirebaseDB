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
        }

        private async void ButAdd_Clicked(object sender, EventArgs e)
        {
            Model.Persona persona = new Model.Persona();
            persona.ID = Convert.ToInt32(entID.Text);
            persona.Nombre = entNombre.Text;
            await new Firebase.PersonaFB().AddPerson(persona);

        }
    }
}
