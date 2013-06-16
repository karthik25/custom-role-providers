using System.ComponentModel.DataAnnotations;

namespace CustomMembershipEF.Entities
{
    public class Role
    {
        [Key]
        public short RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    }
}