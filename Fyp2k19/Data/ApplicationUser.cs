using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fyp2k19.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
    }
}
