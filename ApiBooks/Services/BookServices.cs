using ApiBooks.Interfaces;
using ApiBooks.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiBooks.Services
{
    public class BookServices : IBook
    {
        private HttpClient client;
        private List<Book> bookList;
        private Book book;

        public BookServices(HttpClient _client)
        {
            client = _client;
        }

        /// <summary>
        /// This to create data in the fakeApi
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Object</returns>
        public async Task<Book> CreateBook(Book book)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("https://fakerestapi.azurewebsites.net/api/v1/Books",book);

            response.EnsureSuccessStatusCode();
            book = await response.Content.ReadAsAsync<Book>();

            return book;

        }

        /// <summary>
        /// Method to delete data from FakeApi
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StatusCode</returns>
        public async Task<HttpStatusCode> DeleteBook(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}");

            return response.StatusCode;
        }

        /// <summary>
        /// Method to get all data from Api
        /// </summary>
        /// <returns>IEnumerable</returns>
        public async Task<List<Book>> GetBooks()
        {
            
            HttpResponseMessage response = await client.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");
             
            if(response.IsSuccessStatusCode)
            { 
                var result = response.Content.ReadAsStringAsync();

                bookList = JsonConvert.DeserializeObject<List<Book>>(result.Result);
            }

            return bookList;
        }

        /// <summary>
        /// Method to get book by id parameter from FakeApi
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        public async Task<Book> GetBookById(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();

                book = JsonConvert.DeserializeObject<Book>(result.Result);
            }

            return book;

        }

        /// <summary>
        /// Method to updata date from FackeApi
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Object</returns>
        public async Task<Book> UpdateBook(Book book)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"https://fakerestapi.azurewebsites.net/api/v1/Books/{book.id}", book);

            response.EnsureSuccessStatusCode();
            book = await response.Content.ReadAsAsync<Book>();

            return book;
        }
    }
}
