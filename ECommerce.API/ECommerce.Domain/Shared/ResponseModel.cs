using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Shared
{
    public class ResponseModel
    {
        public bool Status { get; set; }
        public object Message { get; set; }
        public object? Data { get; set; }

        public ResponseModel(bool status = true, object message = default, object data = default)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }

        public static ResponseModel Success(object msg, object dt) => new(status: true, message: msg, data: dt);

        public static ResponseModel Failure(object msg) => new(status: false, message: msg, data: null);
    }
}
