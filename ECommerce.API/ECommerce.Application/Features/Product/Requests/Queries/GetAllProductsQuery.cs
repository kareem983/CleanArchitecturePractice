using ECommerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public record class GetAllProductsQuery() : IQuery<List<GetProductResponseDTO>>;
}
