using Microsoft.AspNetCore.Mvc;
using MusicApp.Service.Interface;
using Stripe;
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


        public IActionResult SuccessPayment()
        {
            return View();
        }

        public IActionResult PayOrder(string stripeEmail, string stripeToken)
        {
            StripeConfiguration.ApiKey = "sk_test_51Io84IHBiOcGzrvu4sxX66rTHq8r5nxIxRiJPbOHB4NwVJOE1jSlxgYe741ITs024uXhtpBFtxm3RoCZc3kafocC00IhvgxkL0";
            var customerService = new CustomerService();
            var chargeService = new ChargeService();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = this._shoppingCartService.getShoppingCartInfo(new Guid(userId));

            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount = (Convert.ToInt32(order.TotalPrice) * 100),
                Description = "EShop Application Payment",
                Currency = "usd",
                Customer = customer.Id
            });

            if (charge.Status == "succeeded")
            {
                this.order();
                return RedirectToAction("SuccessPayment");

            }
            else
            {
                return RedirectToAction("NotsuccessPayment");
            }
        }


    }
}
