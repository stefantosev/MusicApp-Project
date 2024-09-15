using MusicApp.Domain.BookApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Repository.Interface
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
    }
}
