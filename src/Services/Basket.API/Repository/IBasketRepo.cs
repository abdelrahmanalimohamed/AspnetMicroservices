using System.Threading.Tasks;
using Basket.API.Entities;

namespace Basket.API.Repository
{
    public interface IBasketRepo
    {
        Task<ShoppingCart> GetShoppingCart(string username);

        Task<ShoppingCart> UpdateShoppingCart(ShoppingCart cart);

        Task DeleteBasket (string username);
    }
}
