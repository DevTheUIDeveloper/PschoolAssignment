using Pschool.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pschool.Business
{
    public interface IParentService
    {
        Task<IEnumerable<ParentDto>> GetAllAsync();
        Task<ParentDto> GetParentByIdAsync(int id);
        Task<ParentDto> CreateParentAsync(ParentDto dto);
        Task<ParentDto> UpdateParentAsync(int id, ParentDto dto);
        Task<bool> DeleteParentAsync(int id);

    }
}
