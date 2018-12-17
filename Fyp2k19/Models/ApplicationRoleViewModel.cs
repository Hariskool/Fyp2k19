using System.ComponentModel.DataAnnotations;

namespace Fyp2k19.Models
{
    public class ApplicationRoleViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
