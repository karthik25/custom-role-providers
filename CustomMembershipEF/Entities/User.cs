using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomMembershipEF.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserEmailAddress { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}