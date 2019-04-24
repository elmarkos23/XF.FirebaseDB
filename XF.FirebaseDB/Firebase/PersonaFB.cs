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
        public async Task Reset()
        {
            await firebase.Child("Persona").DeleteAsync();
        }

        public async Task<List<Model.Persona>> GetAllPersons()
        {
           return (await firebase.Child("Persona").OnceAsync<Model.Persona>()).Select(item => new Model.Persona
              {
                  Nombre= item.Object.Nombre,
                  Identificacion = item.Object.Identificacion
              }).ToList();
        }
        public async Task AddPerson(Model.Persona persona)
        {
            var item = await GetPerson(persona.Identificacion);
            if (item == null)
            {
                await firebase.Child("Persona").PostAsync(persona);
            }
        }
        public async Task<Model.Persona> GetPerson(string personId)
        {
            var allPersons = await GetAllPersons();
            await firebase.Child("Persona").OnceAsync<Model.Persona>();
            return allPersons.Where(a => a.Identificacion == personId).FirstOrDefault();
        }
        public async Task UpdatePerson(string personId, string name)
        {
            var toUpdatePerson = (await firebase.Child("Persona").OnceAsync<Model.Persona>()).Where(a => a.Object.Identificacion == personId).FirstOrDefault();
            await firebase.Child("Persona").Child(toUpdatePerson.Key).PutAsync(new Model.Persona() { Identificacion = personId, Nombre = name });
        }
        public async Task DeletePerson(string personId)
        {
            var toDeletePerson = (await firebase.Child("Persona").OnceAsync<Model.Persona>()).Where(a => a.Object.Identificacion == personId).FirstOrDefault();
            await firebase.Child("Persona").Child(toDeletePerson.Key).DeleteAsync();
        }
    }
}
