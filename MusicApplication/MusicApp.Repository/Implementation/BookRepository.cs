using Microsoft.EntityFrameworkCore;
using MusicApp.Domain;
using MusicApp.Domain.BookApp;
using MusicApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repository.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly SecondDbContext _context;
        private DbSet<Book> entities;
        public BookRepository(SecondDbContext context)
        {
            _context = context;
            entities = context.Set<Book>();
        }

        public List<Book> GetAllBooks()
        {

            return entities
             .Include(z => z.Publisher)
             .Include(z => z.Author)
             .ToList();
        }

    }
}
