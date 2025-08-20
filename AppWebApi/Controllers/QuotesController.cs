using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

using Seido.Utilities.SeedGenerator;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]   
    public class QuoteController : Controller
    {
        readonly ILogger<QuoteController> _logger;
        readonly IWebHostEnvironment _environment;
        readonly SeedGenerator _seeder = new SeedGenerator();
        string filter = "love";
    


        [HttpGet()]
        [ActionName("AllQuotes")]
        [ProducesResponseType(200)]
        public IActionResult AllQuotes()
        {
            try
            {  
                return Ok(_seeder.AllQuotes); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [ActionName("RndQuotes")]
        [ProducesResponseType(200)]
        public IActionResult RndQuotes()
        {
            try
            {  
                return Ok(_seeder.Quote); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [ActionName("SearchQuotes")]
        [ProducesResponseType(200)]
        public IActionResult SearchQuotes(string qtWord, int nr, byte bytes)
        {
            var filteredList = new List<SeededQuote>();
            try
            {
                foreach (var qt in _seeder.AllQuotes)
                {
                    if (qt.Quote.Contains(qtWord))
                    {
                        filteredList.Add(qt);
                    }
                }
                return Ok(filteredList);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public QuoteController(ILogger<QuoteController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }
    }
}

