namespace EduBridge.API.Models.User
{
    public class GetStudentDetailsDto : GetStudentsDto
    {
        public string? UserName { get; set; }

        public string? OtherNames { get; set; }

        public string? PhoneNumber { get; set; }
    }
}

