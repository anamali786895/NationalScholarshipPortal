using System.ComponentModel.DataAnnotations;

namespace InstituteScholarshipPortal.Models
{
    public class InstituteLoginViewModel
    {
        [Required(ErrorMessage = "Institute Code is required")]
        public string? InstituteCode { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
