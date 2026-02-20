

using EasyClothing.Api.Http.StatusCodes;

namespace EasyClothing.Api.Http.Responses
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; } = string.Empty;

        public ApiResponse(StatusCodesEnum statusCode, T? data, bool success, string? message)
        {
            StatusCode = (int)statusCode;
            Data = data;
            Success = success;
            Message = message;
        }
    }
}
