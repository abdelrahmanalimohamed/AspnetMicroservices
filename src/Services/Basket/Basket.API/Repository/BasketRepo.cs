using System;
using System.Threading.Tasks;
using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repository
{
    public class BasketRepo : IBasketRepo
    {
        private readonly IDistributedCache distributedCache;

        public BasketRepo(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }
        public async Task DeleteBasket(string username)
        {
            await distributedCache.RemoveAsync(username);
        }
        public async Task<ShoppingCart> GetShoppingCart(string username)
        {
            var basket = await distributedCache.GetStringAsync(username);
            if (String.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }
        public async Task<ShoppingCart> UpdateShoppingCart(ShoppingCart cart)
        {
            await distributedCache.SetStringAsync(cart.UserName , JsonConvert.SerializeObject(cart));

            return await GetShoppingCart(cart.UserName);
        }
    }
}