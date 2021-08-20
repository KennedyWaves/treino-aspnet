using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestMethods.Data.DTO;
using RestMethods.Model;
using RestMethods.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestMethods.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : Controller
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService personService;
        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            this.personService = personService;
        }
        [HttpGet]
        /// <summary>
        /// Retorna todas as <see cref="Model.Person"/>
        /// </summary>
        /// <returns></returns>
        public IActionResult Get()
        {
            return Ok(personService.ListAll());
        }
        [HttpGet("{id}")]
        /// <summary>
        /// Retorna um objeto a partir do Id.
        /// </summary>BookDTO
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Get(long id)
        {
            var person = personService.FindById(id);
            if(person== null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        [HttpPost]
        /// <summary>
        /// Persiste um objeto.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public IActionResult Post([FromBody] PersonDTO person)
        {
            var result = personService.Create(person);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPut]
        /// <summary>
        /// Substitui um objeto.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public IActionResult Put([FromBody] PersonDTO person)
        {
            var result = personService.Update(person);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }


        [HttpPatch]
        /// <summary>
        /// Atualiza um objeto.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public IActionResult Patch([FromBody] PersonDTO person)
        {
            var result = personService.Update(person);
            if (result == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("{id}")]
        /// <summary>
        /// Remove um objeto a partir do id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(long id)
        {
            personService.Delete(id);
            return NoContent();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
