using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBooks.Models.Models
{
    public class BookManager : IBookManager
    {
        private ApiService.ApiService apiService = new ApiService.ApiService();
        private List<Book> _bookList;
        private Book _book;

        public BookManager()
        {
            _bookList = new List<Book>();
            _book = new Book();
        }

        public async Task<bool> AddBook(Book book)
        {
            var response = await apiService.PostData("https://fakerestapi.azurewebsites.net/", "/api", "/Books", book);

            if (!response.IsSuccess)
            {
                throw new Exception("ALGO PASO CON LA CONSULTA");
            }

            return response.IsSuccess;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var response = await apiService.DeleteData("https://fakerestapi.azurewebsites.net/", "/api", "/Books/", id);

            if (!response.IsSuccess)
            {
                throw new Exception("ALGO PASO CON LA CONSULTA");
            }

            return response.IsSuccess;
        }

        public async Task<Book> GetBook(int id)
        {
            var response = await apiService.GetDataById<Book>("https://fakerestapi.azurewebsites.net/", "/api", "/Books/",id);

            if (!response.IsSuccess)
            {
                throw new Exception("ALGO PASO CON LA CONSULTA");
            }

            _book = (Book)response.Result;

            return _book;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            var response = await apiService.GetLista<Book>("https://fakerestapi.azurewebsites.net/", "/api", "/Books");

            if (!response.IsSuccess)
            {
                throw new Exception("ALGO PASO CON LA CONSULTA");
            }

            _bookList = (List<Book>)response.Result;

            return _bookList;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var response = await apiService.PutData("https://fakerestapi.azurewebsites.net/", "/api", "/Books/",book.ID, book);

            if (!response.IsSuccess)
            {
                throw new Exception("ALGO PASO CON LA CONSULTA");
            }

            return response.IsSuccess;
        }
    }
}
