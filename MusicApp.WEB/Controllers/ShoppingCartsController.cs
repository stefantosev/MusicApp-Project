using Microsoft.AspNetCore.Mvc;
using MusicApp.Service.Interface;
using System.Security.Claims;

namespace MusicApp.Web.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartsController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;
           
            Guid? parsedUserId = string.IsNullOrEmpty(userId) ? (Guid?)null : Guid.Parse(userId);

            return View(_shoppingCartService.getShoppingCartInfo(parsedUserId));

        }

        // GET: ShoppingCarts/Details/5

        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> DeleteProductFromShoppingCart(Guid productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

            var result = _shoppingCartService.deleteProductFromShoppingCart(userId.ToString(), productId);

            return RedirectToAction("Index", "ShoppingCarts");
        }

        //public async Task<IActionResult> Order()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? null;

        //    var result = _shoppingCartService.order(userId ?? "");

        //    return RedirectToAction("Index", "ShoppingCarts");
        //}

        public IActionResult DeleteFromShoppingCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.deleteProductFromShoppingCart(userId, id);

            return RedirectToAction("Index");

        }

        public IActionResult order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _shoppingCartService.order(userId);
            //if (result == true)
            return RedirectToAction("Index", "ShoppingCarts");


        }

    }
}
