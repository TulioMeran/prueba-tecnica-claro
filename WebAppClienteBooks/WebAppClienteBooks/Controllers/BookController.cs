using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaBooks;
using PruebaBooks.Models;
using PruebaBooks.Models.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppClienteBooks.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;

        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var lista = await _bookManager.GetBooks();

            return View(lista);
        }

        
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _bookManager.GetBook(id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var respuesta = await _bookManager.AddBook(book);

                if (respuesta)
                {
                    return RedirectToAction("Index");

                }
            }

            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _bookManager.GetBook(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var respuesta = await _bookManager.UpdateBook(book);

                if (respuesta)
                {
                    return RedirectToAction("Index");

                }
            }

            return View(book);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _bookManager.DeleteBook(id);

            if (!response)
            {
                throw new Exception("OCURRIO ALGUN ERROR");
            }

            return RedirectToAction("Index");
        }

    }
}
