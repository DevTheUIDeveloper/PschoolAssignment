using Pschool.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pschool.Business
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task<IEnumerable<StudentDto>> GetStudentByParentIdAsync(int parentId);
        Task<StudentDto> CreateStudentAsync(StudentCreateUpdateDto dto);
        Task<StudentDto> UpdateStudentAsync(int id, StudentCreateUpdateDto dto);
        Task<bool> DeleteStudentAsync(int id);
    }
}
