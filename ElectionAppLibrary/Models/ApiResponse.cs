using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionAppLibrary.Models
{
    public interface IRepAPIRequests
    {
        Task<ApiResponse<RepresentativeModel?>> RepOnGet(string ocdId);
    }
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public ApiResponse(T data, bool success = true, string errorMessage = "")
        {
            Success = success;
            Data = data;
            ErrorMessage = errorMessage;
        }
    }
}
