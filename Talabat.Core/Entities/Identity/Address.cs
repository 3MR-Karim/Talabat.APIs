using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Identity
{
    internal class Address
    {
        // can inhiert id from baseIdentiy Bro i creaee sperate database from securiyModuel Ok
        // this better can sotre things with sequrity point
        // scalibaltiy 
        // baseEntity is has dbcontent ugly bro 
        public int Id { get; set; }
        // why address have firstName and lastName and street 
        // bedcuase The human can take 20 address Ok Home house OK 
        public required string FirstName { get; set; }    
        public required string LastName { get; set; }    
        public required string Street { get; set; }    
        public required string City { get; set; }    
        public required string Country { get; set; }    
   
        public required  string  UserId { get; set; }
         public virtual required ApplicationUser User { get; set; }
    }

}
