using MusicApp.Domain;
using MusicApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Service.Interface
{
    public interface IShoppingCartService
    {
        UserPlaylist AddProductToShoppingCart(string userId, AddToCart model);
        ShoppingCartDto getShoppingCartInfo(Guid? userId);
        bool deleteProductFromShoppingCart(string userId, Guid productId);
        bool order(string userId);
        bool AddToShoppingConfirmed(TrackInPlaylist model, string userId);
        AddToCart getProductInfo(Guid Id);
    }
}
