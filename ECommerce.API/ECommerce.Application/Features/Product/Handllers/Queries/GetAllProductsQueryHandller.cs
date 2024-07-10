using AutoMapper;
using E_commerce.Domian;
using ECommerce.Application.DTOs.Product;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public class GetAllProductsQueryHandller : IQueryHandller<GetAllProductsQuery, List<GetProductResponseDTO>>
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<Product> _logger;
        
        public GetAllProductsQueryHandller(IGenericRepository<Product> productRepo, IMapper mapper, ILogger<Product> logger)
        {
            this._productRepo = productRepo;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<ResponseModel<List<GetProductResponseDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepo.GetAllByExpression(c => c.Id > 0);
                var result = _mapper.Map<IEnumerable<GetProductResponseDTO>>(products);

                return new ResponseModel<List<GetProductResponseDTO>>(status: true, data: result.ToList());
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
            }

            return new ResponseModel<List<GetProductResponseDTO>>(false);

        }
    }
}
