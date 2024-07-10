using AutoMapper;
using E_commerce.Domian;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Shared;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class AddProductCommandHandller : ICommandHandller<AddProductCommand>
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        private readonly IValidator<AddProductCommand> _validator;
        private readonly ILogger<Product> _logger;

        public AddProductCommandHandller(IGenericRepository<Product> productRepo, IMapper mapper, ILogger<Product> logger, IValidator<AddProductCommand> validator)
        {
            this._productRepo = productRepo;
            this._mapper = mapper;
            this._logger = logger;
            this._validator = validator;
        }

        public async Task<ResponseModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productValidator = await _validator.ValidateAsync(request);
                if(!productValidator.IsValid)
                    return ResponseModel.Failure(productValidator.Errors.Select(e => e.PropertyName + " : " + e.ErrorMessage));
                

                var product  = _mapper.Map<Product>(request.ProductDTO);
                await _productRepo.AddAsync(product);
                await _productRepo.SaveAsync();

                return ResponseModel.Success("Product Added Successfully", product);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
            }

            return ResponseModel.Failure("Error");
        }
    }
}
