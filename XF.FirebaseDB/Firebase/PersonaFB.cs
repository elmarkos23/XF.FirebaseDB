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
           return (await firebase.Child("Persona").OnceAsync<Model.Persona>()).Select(item => new Model.Persona
              {
                  Nombre= item.Object.Nombre,
                  ID = item.Object.ID
              }).ToList();
        }
        public async Task AddPerson(Model.Persona persona)
        {
            await firebase.Child("Persona").PostAsync(new Model.Persona() { ID= persona.ID, Nombre= persona.Nombre });
        }
        public async Task<Model.Persona> GetPerson(int personId)
        {
            var allPersons = await GetAllPersons();
            await firebase.Child("Persona").OnceAsync<Model.Persona>();
            return allPersons.Where(a => a.ID == personId).FirstOrDefault();
        }
        public async Task UpdatePerson(int personId, string name)
        {
            var toUpdatePerson = (await firebase.Child("Persona").OnceAsync<Model.Persona>()).Where(a => a.Object.ID == personId).FirstOrDefault();
            await firebase.Child("Persona").Child(toUpdatePerson.Key).PutAsync(new Model.Persona() { ID = personId, Nombre = name });
        }
        public async Task DeletePerson(int personId)
        {
            var toDeletePerson = (await firebase.Child("Persona").OnceAsync<Model.Persona>()).Where(a => a.Object.ID == personId).FirstOrDefault();
            await firebase.Child("Persona").Child(toDeletePerson.Key).DeleteAsync();
        }
    }
}
