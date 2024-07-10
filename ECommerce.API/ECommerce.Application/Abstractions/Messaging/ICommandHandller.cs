using ECommerce.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public interface ICommandHandller<TCommand> : IRequestHandler<TCommand, ResponseModel> where TCommand : ICommand
    {
    }
}
