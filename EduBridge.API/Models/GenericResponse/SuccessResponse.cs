using System;
namespace EduBridge.API.Models.GenericResponse
{
    public class SuccessResponse
	{
        public bool Success { get; set; } = true;

        public string Message { get; set; } = "Operation successful!";

        public object? Data { get; set; }
    }
}