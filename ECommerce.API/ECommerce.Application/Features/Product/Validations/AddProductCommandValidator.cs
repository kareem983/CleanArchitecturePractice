using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator(IGenericRepository<Product> ProdctRep)
        {
            RuleFor(x => x.ProductDTO.Name).MaximumLength(10).WithMessage("Name must be less than 10 characters!")
                                            .MustAsync(async (Name, _) =>
                                            {
                                                var product = await ProdctRep.GetByExpression(x => x.Name == Name);
                                                if (product != null)
                                                    return false;

                                                return true;

                                            }).WithMessage("The product must have a Name that is unique in the database");
        }
    }
}
