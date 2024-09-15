using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApp.Domain.BookApp;
using MusicApp.Repository;
using MusicApp.Service.Implementation;
using MusicApp.Service.Interface;

namespace MusicApp.Web.Controllers
{
    public class BooksController : Controller
    {
     
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            return View(_bookService.GetAllBooks());
        }

    }
}
