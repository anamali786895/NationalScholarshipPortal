using System.ComponentModel.DataAnnotations;

namespace InstituteScholarshipPortal.Models
{
    public class InstituteRegistration
    {
        [Key]
        public int InstituteId { get; set; }

        // ===================== INSTITUTE DETAILS =====================

        [Required(ErrorMessage = "Institute Name is required")]
        public string InstituteName { get; set; }

        [Required(ErrorMessage = "Institute Code is required")]
        public string InstituteCode { get; set; }

        public string? DISECode { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string? State { get; set; }

        [Required(ErrorMessage = "District is required")]
        public string? District { get; set; }

        public string? Location { get; set; }

        public string? InstituteType { get; set; }

        public string? YearAdmissionStarted { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }


        // ===================== AFFILIATION DETAILS =====================

        public string? AffiliatedUniversityState { get; set; }

        public string? UniversityBoardName { get; set; }

        public string? EstablishmentCertificate { get; set; }

        public string? AffiliationCertificate { get; set; }


        // ===================== PRINCIPAL & CONTACT =====================

        [Required(ErrorMessage = "Principal name is required")]
        public string? PrincipalName { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        public string? MobileNumber { get; set; }

        public string? Telephone { get; set; }


        // ===================== LOGIN & SECURITY =====================

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public string? SecurityQuestion { get; set; }

        public string? SecurityAnswer { get; set; }
    }
}
