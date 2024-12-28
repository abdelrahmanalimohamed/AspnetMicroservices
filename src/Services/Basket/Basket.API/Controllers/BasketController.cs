using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketController : ControllerBase
	{
		private readonly IBasketRepo basketRepo;
		private readonly DiscountGrpcService _discountGrpcService;
		public BasketController(IBasketRepo basketRepo,
			DiscountGrpcService _discountGrpcService)
		{
			this.basketRepo = basketRepo;
			this._discountGrpcService = _discountGrpcService;
		}

		[HttpGet("{username}", Name = "GetBasket")]
		[ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetBasket(string username)
		{
			var basket = await basketRepo.GetShoppingCart(username);
			return Ok(basket ?? new ShoppingCart(username));
		}

		[HttpPost]
		[ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart shoppingCart)
		{
			foreach (var item in shoppingCart.Items)
			{
				var coupon = await _discountGrpcService.GetDiscount(item.ProductName);
				item.Price -= coupon.Amount;
			}
			return Ok(await basketRepo.UpdateShoppingCart(shoppingCart));
		}

		[HttpDelete("{username}", Name = "DeleteBasket")]
		[ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> DeleteBasket(string username)
		{
			await basketRepo.DeleteBasket(username);
			return Ok();
		}
	}
}
