using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObligatoriskOpgave1;

namespace ObligatoriskOpgave4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BogController : ControllerBase
    {
        private static List<Bog> books = new List<Bog>()
        {
            new Bog("God bog", "Alexander", 150, "detherer13bog"),
            new Bog("Mindre god bog", "Carsten", 100, "0123456789123"),
            new Bog("Bedste bog i verden", "Henrik", 350, "enstrengder13")
        };

        // GET: api/Bog
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return books;
        }

        // GET: api/Bog/5
        [HttpGet("{Isbn13ID}", Name = "Get")]
        public Bog Get(string Isbn13ID)
        {
            return books.Find(c => c.Isbn13 == Isbn13ID);
        }

        // POST: api/Bog
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            books.Add(value);
        }

        // PUT: api/Bog/5
        [HttpPut("{Isbn13ID}")]
        public void Put(string Isbn13ID, [FromBody] Bog value)
        {
            Bog bog = Get(Isbn13ID);

            if (bog != null)
            {
                bog.Isbn13 = value.Isbn13;
                bog.Forfatter = value.Forfatter;
                bog.Sidetal = value.Sidetal;
                bog.Titel = value.Titel;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{Isbn13ID}")]
        public void Delete(string Isbn13ID)
        {
            Bog bog = Get(Isbn13ID);
            if(bog != null) books.Remove(bog);
        }
    }
}
