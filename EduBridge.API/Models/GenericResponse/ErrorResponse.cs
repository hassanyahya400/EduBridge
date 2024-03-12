namespace EduBridge.API.Models.GenericResponse
{
    public class ErrorResponse
    {
        public bool Success { get; set; } = false;

        public string ErrorMessage { get; set; } = "Operation failed!";

        public object? Data { get; set; } = null;
    }
}