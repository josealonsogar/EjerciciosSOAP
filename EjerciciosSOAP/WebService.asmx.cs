using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EjerciciosSOAP
{
    /// <summary>
    /// Descripción breve de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        private EjercicioSOAPEntities db = new EjercicioSOAPEntities();

        [WebMethod]
        public List<Persona> getPersonas()
        {
            var personas = db.Persona;

            return personas.ToList();
        }

        [WebMethod]
        public Persona getPersona(int id)
        {
            var persona = db.Persona.FirstOrDefault(s => s.id == id);

            return persona;
        }

        [WebMethod]
        public List<Persona> createPersona(Persona persona)
        {
            var personas = db.Persona;

            personas.Add(persona);

            db.SaveChanges();

            return personas.ToList();
        }

        [WebMethod]
        public List<Persona> updatePersona(Persona persona)
        {

            var personas = db.Persona;

            var personaUpdate = personas.Where(p => p.nif == persona.nif).First();
            
            personaUpdate.nombre = persona.nombre;
            personaUpdate.apellidos = persona.apellidos;
            personaUpdate.nif = persona.nif;
            personaUpdate.direccion = persona.direccion;
            personaUpdate.ciudad = persona.ciudad;
            personaUpdate.estadocivil = persona.estadocivil;
            personaUpdate.sexo = persona.sexo;
            personaUpdate.codigopostal = persona.codigopostal;
            personaUpdate.provincia = persona.provincia;

            db.SaveChanges();

            return personas.ToList();
        }

        [WebMethod]
        public List<Persona> deletePersona(Persona persona)
        {
            var personas = db.Persona;

            var personaDelete = personas.Where(p => p.nif == persona.nif).First();

            personas.Remove(personaDelete);

            db.SaveChanges();

            return personas.ToList();
        }
    }
}
