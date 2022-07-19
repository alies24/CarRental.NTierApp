using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dto
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
