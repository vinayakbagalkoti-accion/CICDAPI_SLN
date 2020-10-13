using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CICDAPI.Controllers
{
    public class LanguageController : ApiController
    {

        static List<string> languages = new List<string>() {
            "C#","ASP.NET","MVC"
        };

        // GET: api/Language
        // GET api/values  
        public IEnumerable<string> Get()
        {
            return languages;
        }


        // GET: api/Language/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(languages[id]);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
                       
        }

        // POST: api/Language
        public IHttpActionResult Post(string value)
        {
            try
            {
                languages.Add(value);
            }
            catch 
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return Ok("Record Added successfully");

        }

        // PUT: api/Language/5
        public IHttpActionResult Put(int id, string value)
        {
            try
            {
                languages[id] = value;
            }
            catch 
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return Ok("Record updated successfully");
        }

        // DELETE: api/Language/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                languages.RemoveAt(id);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }

            return Ok("Record deleted successfully");
        }
    }
}
