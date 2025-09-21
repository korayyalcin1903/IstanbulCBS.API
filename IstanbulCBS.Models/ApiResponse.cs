using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IstanbulCBS.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool success, string? message = null)
        {
            Success = success;
            Message = message;
        }

        public static ApiResponse Ok(string? message = null)
            => new ApiResponse(true, message);

        public static ApiResponse Fail(string? message = null)
            => new ApiResponse(false, message);
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool success, T? data = default, string? message = null)
            : base(success, message)
        {
            Data = data;
        }

        public static ApiResponse<T> Ok(T data, string? message = null)
            => new ApiResponse<T>(true, data, message);

        public static ApiResponse<T> Fail(string? message = null)
            => new ApiResponse<T>(false, default, message);
    }

}
