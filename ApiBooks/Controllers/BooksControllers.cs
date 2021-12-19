using ApiBooks.Interfaces;
using ApiBooks.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksControllers : ControllerBase
    {
        private IBook bookServices;
        public BooksControllers(IBook _book)
        { 
            bookServices = _book; 
        }

        /// <summary>
        /// Endpoint to fetch books
        /// </summary>
        /// <returns>Object</returns>
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var response = await bookServices.GetBooks();
            return Ok(response);
        }

        /// <summary>
        /// Endpoint to fetch books by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Object</returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> GetBookById([FromBody] int id)
        {
            var response = await bookServices.GetBookById(id);

            if (response == null)
                return NotFound(new { message = "Book not found " });
            return Ok(response);
        }

        /// <summary>
        /// Endpoint to post book
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Object</returns>
        [HttpPost]
        public  async Task<IActionResult> PostBook([FromBody] Book book)
        {
            var response = await bookServices .CreateBook(book);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint to update books
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Object</returns>
        [HttpPut]
        public async Task<IActionResult> PutBook ([FromBody] Book book)
        {
            var response = await bookServices.UpdateBook(book);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint to delete books
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StatusCode</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await bookServices.DeleteBook(id);
            return Ok(response);
        }
    }
}
