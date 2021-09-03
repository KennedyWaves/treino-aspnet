using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestMethods.Data.DTO;
using RestMethods.Hypermedia.Filters;
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
    public class BookController : Controller
    {

        private readonly ILogger<BookController> _logger;
        private IBookService bookService;
        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            this.bookService = bookService;
        }
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<BookDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        /// <summary>
        /// Retorna todas as <see cref="Model.Book"/>
        /// </summary>
        /// <returns></returns>
        public IActionResult Get()
        {
            return Ok(bookService.ListAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(BookDTO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        /// <summary>
        /// Retorna um objeto a partir do Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Get(long id)
        {
            var book = bookService.FindById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        /// <summary>
        /// Persiste um objeto.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public IActionResult Post([FromBody] BookDTO book)
        {
            var result = bookService.Create(book);
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
        [ProducesResponseType((200), Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        /// <summary>
        /// Substitui um objeto.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public IActionResult Put([FromBody] BookDTO book)
        {
            var result = bookService.Update(book);
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
        [ProducesResponseType((200), Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HypermediaFilter))]
        /// <summary>
        /// Atualiza um objeto.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public IActionResult Patch([FromBody] BookDTO book)
        {
            var result = bookService.Update(book);
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
            bookService.Delete(id);
            return NoContent();
        }
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }
    }
}
