using MusicApp.Domain;
using MusicApp.Domain.BookApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Service.Interface
{
    public interface IBookService
    {
        List<TransformedBook> GetAllBooks();
    }
}
