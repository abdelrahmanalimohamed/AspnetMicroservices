using Basket.API.Entities;
using System.Threading.Tasks;

namespace Basket.API.Repository
{
	public interface IBasketRepo
	{
		Task<ShoppingCart> GetShoppingCart(string username);

		Task<ShoppingCart> UpdateShoppingCart(ShoppingCart cart);

		Task DeleteBasket(string username);
	}
}
