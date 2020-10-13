using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CICDAPI.Controllers
{
    public class Language
    {
        public int? Id { get; set; }

        public string Name { get; set; }
    }

    public class LanguageController : ApiController
    {

        static List<Language> languages = new List<Language>() { 

            new Language(){ Id= 1, Name ="C#"},
            new Language(){ Id= 2, Name ="Java"},
            new Language(){ Id= 3, Name ="Python"},
            new Language(){ Id= 4, Name ="Angular"}
        };

        // GET: api/Language
        // GET api/values  
        public IEnumerable<Language> Get()
        {
            return languages;
        }


        // GET: api/Language/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                Language language = languages.FirstOrDefault(l => l.Id == id);

                if (language != null)
                {
                  return Ok(language);
                }

               
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return StatusCode(HttpStatusCode.NotFound);

        }

        // POST: api/Language
        public IHttpActionResult Post(string value)
        {
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int? intIdt = languages.Max(u => (int?)u.Id);

                    languages.Add(new Language() { Id = intIdt + 1, Name = value });

                    return Content(HttpStatusCode.Created, value + " added successfully at index " + (intIdt + 1));
                   
                }
            }
            catch 
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return StatusCode(HttpStatusCode.BadRequest);

        }

        // PUT: api/Language/5
        public IHttpActionResult Put(int id, string value)
        {
            try
            {
                Language language = languages.FirstOrDefault(l => l.Id == id);

                if (language != null)
                {
                    foreach (var l in languages.Where(w => w.Id == id))
                    {
                        l.Name = value;
                    }
                    return Content(HttpStatusCode.Created, value + " updated successfully at index " + id);
                }
            }
            catch 
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return StatusCode(HttpStatusCode.NotFound);
        
        }

        // DELETE: api/Language/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Language language = languages.FirstOrDefault(l => l.Id == id);

                if (language != null)
                {
                    languages.Remove(language);

                    return Content(HttpStatusCode.Accepted, language.Name + " deleted successfully at index " + id);
                }
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return StatusCode(HttpStatusCode.NotFound);

        }
    }
}
