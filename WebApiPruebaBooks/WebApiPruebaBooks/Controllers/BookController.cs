using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaBooks.Models;
using PruebaBooks.Models.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPruebaBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;

        public BookController(IBookManager bookManager ) 
        {
            _bookManager = bookManager;
        }

        // GET: /<controller>/
        [HttpGet]
        [Route("getbooks")]
        public async Task<IActionResult> GetBooks()
        {
           var lista = await _bookManager.GetBooks();

            return Json(lista);
        }

        [HttpGet]
        [Route("getbook/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookManager.GetBook(id);

            return Json(book);
        }

        [HttpPost]
        [Route("postbook")]
        public async Task<IActionResult> PostBook(Book book)
        {
            var respuesta = await _bookManager.AddBook(book);

            return Json(respuesta);
        }

        [HttpPut]
        [Route("putbook")]
        public async Task<IActionResult> PutBook(Book book)
        {
            var respuesta = await _bookManager.UpdateBook(book);

            return Json(respuesta);
        }

        [HttpDelete]
        [Route("deletebook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var respuesta = await _bookManager.DeleteBook(id);

            return Json(respuesta);
        }


    }
}
