using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Identity
{
    internal class ApplicationUser:IdentityUser<string>
    {


        public required string DisplayName { get; set; }
        public virtual Address? Address { get; set; }
    }
}
