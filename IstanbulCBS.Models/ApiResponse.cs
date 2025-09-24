using System;

namespace IstanbulCBS.Models
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Error { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool success, string? message = null, string? error = null)
        {
            Success = success;
            Message = message;
            Error = error;
        }

        public static ApiResponse Ok(string? message = null)
            => new ApiResponse(true, message);

        public static ApiResponse Fail(string? message = null, string? error = null)
            => new ApiResponse(false, message, error);
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool success, T? data = default, string? message = null, string? error = null)
            : base(success, message, error)
        {
            Data = data;
        }

        public static ApiResponse<T> Ok(T data, string? message = null)
            => new ApiResponse<T>(true, data, message);

        public static ApiResponse<T> Fail(string? message = null, string? error = null)
            => new ApiResponse<T>(false, default, message, error);
    }
}
