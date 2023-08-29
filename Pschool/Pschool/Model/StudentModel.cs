using System.ComponentModel.DataAnnotations;

namespace Pschool.Model
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Parent is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select parent")]
        public int ParentId { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(10, int.MaxValue, ErrorMessage = "Age must be greater than or equals to 10")]
        public int Age { get; set; }
        public ParentModel Parent { get; set; } = new ParentModel();
    }
}
