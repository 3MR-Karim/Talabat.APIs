using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Basket
{
    public class CustomerBasket /*value*/
    {
        public required string Id { get; set; }   // key Reduis  basketID string becuase queid created from client form froentend 
        public IEnumerable<BasketItem> Items { get; set; } = new List<BasketItem>();   //values basketITself
    
    // Icollection is ienumrable but add reomve and i dont need ad and reomve in basketModule
    // bro foucs when enter add to cart and after days can the hidden ok ooh send a new qued 
    // important informant when return items emptylist or null OOOK snapSHopt Importatnn card coloe disable if empty list the cart but number 0 
    // imporant for frontent OKKK
    }
}
