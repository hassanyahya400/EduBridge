using System.ComponentModel.DataAnnotations;

namespace EduBridge.API.Models.User
{
    public class GetStudentsDto : BaseUserDto
    {
        public string? Id { get; set; }

        public string? Level { get; set; }
    }
}

