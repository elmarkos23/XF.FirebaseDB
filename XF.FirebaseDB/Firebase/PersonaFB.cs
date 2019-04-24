using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.FirebaseDB.Firebase
{
    public class PersonaFB
    {
        FirebaseClient firebase;
        public PersonaFB()
        {
            firebase = new FirebaseClient("https://xamarinforms-a1b88.firebaseio.com/");
        }
        
        public async Task<List<Model.Persona>> GetAllPersons()
        {
           return (await firebase
              .Child("Persona")
              .OnceAsync<Model.Persona>()).Select(item => new Model.Persona
              {
                  Nombre= item.Object.Nombre,
                  ID = item.Object.ID
              }).ToList();
        }
        public async Task AddPerson(Model.Persona persona)
        {
            await firebase
              .Child("Persona")
              .PostAsync(new Model.Persona() { ID= persona.ID, Nombre= persona.Nombre });
        }
    }
}
