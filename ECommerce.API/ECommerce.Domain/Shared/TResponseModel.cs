using E_commerce.Domian;
using ECommerce.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Domian
{
    public class ResponseModel<T> : ResponseModel
    {
        public new T Data { get; set; }

        public ResponseModel(bool status = true, object message = default, T data = default)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }

        public static ResponseModel<T> Success(T data) => new(status: true, data: data, message: null);
    }
}
