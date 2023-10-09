using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthTestUser.Entities
{
    public class User
    {
        [Key]
        public Guid User_ID { get; set; }
        [MaxLength(200)]
        [Required]
        public string User_Code { get; set; }
        [MaxLength(200)]
        [Required]
        public string User_Pass { get; set; }
        [MaxLength(300)]
        [Required]
        public string User_FullName { get; set; }
        public string User_Role { get; set; }

        
    }
}
