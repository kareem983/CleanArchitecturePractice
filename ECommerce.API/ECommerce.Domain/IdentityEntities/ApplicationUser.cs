﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser
    {
        public int AddressPostalCode { get; set; }
    }
}
