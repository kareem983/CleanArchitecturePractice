using ECommerce.Domain.Entities;
using ECommerce.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.DataContext
{
    public class ECommerceReadContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ECommerceReadContext(DbContextOptions<ECommerceReadContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }


    }
}
