using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Contracts.Infrastructure;
using Talabat.Core.Entities.Basket;

namespace Talabat.Repository.contract.Infrastructure
{
    internal class Basket_Repository : IBasketRepository
    {
        private readonly IDatabase _database;
        public Basket_Repository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }


        public async Task<CustomerBasket?> GetAsync(string id)
        {
            var basket = await _database.StringGetAsync(id);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket!); // reduis valuse i need resautrn a cusomerBaskent 

        }
        public async Task<bool> DeleteAsynce(string id)
        {
            var deleted = await _database.KeyDeleteAsync(id);
            return deleted;
        }

        public async Task<CustomerBasket?> UpdateAsync(CustomerBasket basket, TimeSpan timeTolive)
        {
            var value = JsonSerializer.Serialize(basket);
            var updated = await _database.StringSetAsync(basket.Id, value, timeTolive);
            if (updated) return basket;
            return null;
        }
    }




}
