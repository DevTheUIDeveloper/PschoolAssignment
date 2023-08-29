using System.ComponentModel.DataAnnotations;

namespace Pschool.Model
{
    public class ParentModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Incorrect Email Address provided")]
        public string Email { get; set; } = string.Empty;
    }
}
