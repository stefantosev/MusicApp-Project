using MusicApp.Domain;
using MusicApp.Domain.BookApp;
using MusicApp.Repository.Interface;
using MusicApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<TransformedBook> GetAllBooks()
        {
            // Extract
            var books =  _bookRepository.GetAllBooks();


            // Transform
            var transformedBooks = books
            .Where(b => b.Price < 500 && b.Price>=0) // Filtering based on price
            .Select(b => new TransformedBook 
            {
                Name = b.Name,
                Description = b.Description.Length > 100 ? b.Description.Substring(0, 97) + "..." : b.Description, // Truncate long descriptions
                Image = b.Image,
                Price = b.Price,
                AuthorName = b.Author?.FirstName ?? "Unknown", // Handle null author
                PublisherName = b.Publisher?.Name ?? "Unknown" // Handle null publisher

            })
            .ToList();

            //Load
            return transformedBooks; 
        }
    }
}
