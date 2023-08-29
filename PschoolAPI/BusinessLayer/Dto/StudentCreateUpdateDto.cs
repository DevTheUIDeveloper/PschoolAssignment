using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pschool.Business.Dto
{
    public class StudentCreateUpdateDto
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Parent is required")]
        public int ParentId { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(10, int.MaxValue, ErrorMessage = "Age must be greater than or equals to 10")]
        public int Age { get; set; }
    }
}
