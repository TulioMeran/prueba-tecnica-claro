using PruebaBooks.Models;
using PruebaBooks.Models.ApiService;
using PruebaBooks.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppClienteBooks.Models
{
    public class BookRepository : IBookManager
    {
        private ApiService apiService = new ApiService();
        private List<Book> _bookList;
        private Book _book;

        public BookRepository()
        {
            _bookList = new List<Book>();
            _book = new Book();
        }


        public async Task<bool> AddBook(Book book)
        {
            var respuesta = await apiService.PostData("https://localhost:44396", "/api/book", "/postbook", book);

            if (!respuesta.IsSuccess)
            {
                throw new Exception("OCURRIO ALGUN PROBLEMA CONSUMIENDO AGREGAR LIBRO");
            }

            return respuesta.IsSuccess;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var respuesta = await apiService.DeleteData("https://localhost:44396", "/api/book", "/deletebook/", id);

            if (!respuesta.IsSuccess)
            {
                throw new Exception("OCURRIO ALGUN PROBLEMA CONSUMIENDO ELIMINAR LIBRO");
            }

            return respuesta.IsSuccess;

        }

        public async Task<Book> GetBook(int id)
        {
            var respuesta = await apiService.GetDataById<Book>("https://localhost:44396", "/api/book", "/getbook/",id);

            if (!respuesta.IsSuccess)
            {
                throw new Exception("OCURRIO ALGUN PROBLEMA CONSUMIENDO EL LIBRO");
            }

            _book = (Book)respuesta.Result;


            return _book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var respuesta = await apiService.GetLista<Book>("https://localhost:44396", "/api/book", "/getbooks");

            if (!respuesta.IsSuccess)
            {
                throw new Exception("OCURRIO ALGUN PROBLEMA CONSUMIENDO LISTA DE LIBROS");
            }

            _bookList = (List<Book>)respuesta.Result;


            return _bookList;

        }

        public async Task<bool> UpdateBook(Book book)
        {
            var respuesta = await apiService.PutData("https://localhost:44396", "/api/book", "/putbook", book);

            if (!respuesta.IsSuccess)
            {
                throw new Exception("OCURRIO ALGUN PROBLEMA CONSUMIENDO ACTUALIZAR LIBROS");
            }

            return respuesta.IsSuccess;
            
        }
    }
}
