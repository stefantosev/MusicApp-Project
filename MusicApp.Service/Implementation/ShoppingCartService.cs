using MusicApp.Domain;
using MusicApp.Domain.DTO;
using MusicApp.Repository.Interface;
using MusicApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<UserPlaylist> _shoppingCartRepository;
        private readonly IRepository<TrackInPlaylist> _productInShoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<TrackInOrder> _productInOrderRepository;
        private readonly IRepository<Track> _trackRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<UserPlaylist> shoppingCartRepository, IRepository<TrackInPlaylist> productInShoppingCartRepository, IRepository<Order> orderRepository, IRepository<TrackInOrder> productInOrderRepository, IUserRepository userRepository, IRepository<Track> trackRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _orderRepository = orderRepository;
            _productInOrderRepository = productInOrderRepository;
            _userRepository = userRepository;
            _trackRepository = trackRepository;
        }

        public UserPlaylist AddProductToShoppingCart(string userId, AddToCart model)
        {
            if (userId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userCart = loggedInUser?.Playlists;

                var selectedProduct = _trackRepository.Get(model.SelectedTrackId);

                if (selectedProduct != null && userCart != null)
                {
                    userCart?.TracksInPlaylist?.Add(new TrackInPlaylist
                    {
                        Track = selectedProduct,
                        TrackId = selectedProduct.Id,
                        Playlist = userCart,
                        UserPlaylistId = userCart.Id,
                        //Quantity = model.Quantity
                    });

                    return _shoppingCartRepository.Update(userCart);
                }
            }
            return null;
        }

        public bool AddToShoppingConfirmed(TrackInPlaylist model, string userId)
        {
            // Retrieve the logged-in user
            var loggedInUser = _userRepository.Get(userId);

            // Check if the logged-in user is null
            if (loggedInUser == null)
            {
                throw new InvalidOperationException("User not found."); // You might want to handle this differently
            }

            // Ensure Playlists is initialized
            if (loggedInUser.Playlists == null)
            {
                loggedInUser.Playlists = new UserPlaylist(); // Ensure Playlists is not null
            }

            // Ensure TracksInPlaylist is initialized
            if (loggedInUser.Playlists.TracksInPlaylist == null)
            {
                loggedInUser.Playlists.TracksInPlaylist = new List<TrackInPlaylist>();
            }

            // Add the model to the TracksInPlaylist
            loggedInUser.Playlists.TracksInPlaylist.Add(model);

            // Update the shopping cart
            _shoppingCartRepository.Update(loggedInUser.Playlists);

            return true;
        }

        public bool deleteProductFromShoppingCart(string userId, Guid productId)
        {
            if (productId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userShoppingCart = loggedInUser.Playlists;
                var product = userShoppingCart.TracksInPlaylist.Where(x => x.TrackId == productId).FirstOrDefault();

                userShoppingCart.TracksInPlaylist.Remove(product);

                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            return false;
        }

        public AddToCart getProductInfo(Guid Id)
        {
            var selectedProduct = _trackRepository.Get(Id);
            if (selectedProduct != null)
            {
                var model = new AddToCart
                {
                    SelectedTrackId = selectedProduct.Id,
                    SelectedTrackName = selectedProduct.Title,
                    Quantity = 1
                };
                return model;
            }
            return null;
        }

        public ShoppingCartDto getShoppingCartInfo(Guid? userId)
        {
            if (userId != null)
            {
                var loggedInUser = _userRepository.Get(userId.ToString());

                var allProducts = loggedInUser?.Playlists?.TracksInPlaylist?.ToList();

                var totalPrice = 0.0;

                if (allProducts == null)
                {
                    return new ShoppingCartDto
                    {
                        Products = new List<TrackInPlaylist>(), // Assuming Product is the type for tracks
                        TotalPrice = 0.0
                    };
                }
                foreach (var item in allProducts)
                {
                    totalPrice += Double.Round((item.Track.Price * 1), 2);
                }

                var model = new ShoppingCartDto
                {
                    Products = allProducts,
                    TotalPrice = totalPrice
                };

                return model;

            }
            return new ShoppingCartDto
            {
                Products = new List<TrackInPlaylist>(), // Assuming Product is the type for tracks
                TotalPrice = 0.0
            };

        }

        public bool order(string userId)
        { 
       
                if (userId != null)
                {
                    var loggedInUser = _userRepository.Get(userId);

                    var userShoppingCart = loggedInUser.Playlists;


                    Order order = new Order
                    {
                        Id = Guid.NewGuid(),
                        userId = new Guid(userId),
                        Owner = loggedInUser
                    };

                    _orderRepository.Insert(order);

                    List<TrackInOrder> productInOrder = new List<TrackInOrder>();

                    var lista = userShoppingCart.TracksInPlaylist.Select(
                        x => new TrackInOrder
                        {
                            Id = Guid.NewGuid(),
                            TrackId = x.TrackId,
                            Track = x.Track,
                            OrderId = order.Id,
                            Order = order,
                            Quantity = 1 //todo maybe
                        }
                        ).ToList();


                    StringBuilder sb = new StringBuilder();

                    var totalPrice = 0.0;

                    sb.AppendLine("Your order is completed. The order conatins: ");

                    for (int i = 1; i <= lista.Count(); i++)
                    {
                        var currentItem = lista[i - 1];
                        totalPrice += 1 * currentItem.Track.Price; // currentItem.Track.Price // todo;
                        sb.AppendLine(i.ToString() + ". " + currentItem.Track.Title + " with quantity of: " + currentItem.Quantity + " and price of: $" + currentItem.Track.Price);  // todocurrentItem.Product.Price);
                    }

                    sb.AppendLine("Total price for your order: " + totalPrice.ToString());

                    productInOrder.AddRange(lista);

                    foreach (var product in productInOrder)
                    {
                        _productInOrderRepository.Insert(product);
                    }

                    loggedInUser.Playlists.TracksInPlaylist.Clear();
                    _userRepository.Update(loggedInUser);

                    return true;
                }
                return false;
            }

        
    }
}
