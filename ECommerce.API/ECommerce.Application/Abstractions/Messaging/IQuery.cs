using E_commerce.Domian;
using ECommerce.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public interface IQuery<TResponse> : IRequest<ResponseModel<TResponse>>
    {
    }
}
