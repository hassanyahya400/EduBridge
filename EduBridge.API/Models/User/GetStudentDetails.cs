namespace EduBridge.API.Models.User
{
    public class GetStudentDetails : GetStudentsDto
    {
        public string? UserName { get; set; }

        public string? OtherNames { get; set; }

        public string? PhoneNumber { get; set; }
    }
}

