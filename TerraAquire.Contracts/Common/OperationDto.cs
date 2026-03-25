using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraAcquire.Contracts.Common
{
    public class OperationDto<T>
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static OperationDto<T> Success(T data, string? message = null)
        {
            return new OperationDto<T>
            {
                Succeeded = true,
                Data = data,
                Message = message
            };
        }

        public static OperationDto<T> Failure(string message)
        {
            return new OperationDto<T>
            {
                Succeeded = false,
                Message = message
            };
        }
    }
}
