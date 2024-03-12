using System.ComponentModel.DataAnnotations;

namespace EduBridge.API.Models.User
{
    public class GetStudentsDto : BaseUserDto
    {
        [Required]
        public string? Level { get; set; }
    }
}

