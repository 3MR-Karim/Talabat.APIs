using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Basket;

namespace Talabat.Core.Contracts.Infrastructure
{
    public interface IBasketRepository
    {

        Task<CustomerBasket?> GetAsync(string id);
        Task<CustomerBasket?> UpdateAsync(CustomerBasket basket,TimeSpan timeTolive);
        Task<bool> DeleteAsynce(string id);




    }
}
