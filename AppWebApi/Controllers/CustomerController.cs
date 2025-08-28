using Microsoft.AspNetCore.Mvc;
using Services;
using Configuration;
using Models;

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : Controller
    {
        readonly ICustomerService _service;
        readonly Encryptions _encryption;

        [HttpGet()]
        [ActionName("Clear")]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        public IActionResult Clear(int nrItems)
        {
            try
            {
                return Ok(_service.GetCustomers(nrItems));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [ActionName("Encrypted")]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        public IActionResult CustomerWithEncryptedCards(int nrItems)
        {
            try
            {
                var cc = _service.GetCustomers(nrItems);

                foreach (var item in cc)
                {
                    item.Token = _encryption.AesEncryptToBase64(item.CreditCard);
                    item.CreditCard = null;
                }
                
                return Ok(cc);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public CustomerController(ICustomerService service, Encryptions encryptions)
        {
            _service = service;
            _encryption = encryptions;
        }
    }
}