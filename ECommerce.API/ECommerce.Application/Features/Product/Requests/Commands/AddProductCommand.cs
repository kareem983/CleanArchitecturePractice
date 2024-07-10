using ECommerce.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECommerce.Application
{
    public record class AddProductCommand (AddProductDTO ProductDTO) : ICommand;
}
