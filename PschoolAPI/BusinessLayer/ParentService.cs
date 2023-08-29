using AutoMapper;
using Pschool.Business.Dto;
using Pschool.DAL;
using Pschool.DAL.Entities;

namespace Pschool.Business
{
    public class ParentService : IParentService
    {
        private readonly IRepositoryBase<Parent> _parentRepository;
        private readonly IMapper _mapper;
        public ParentService(IRepositoryBase<Parent> parentRepository, IMapper mapper)
        {
            _parentRepository = parentRepository;
            _mapper = mapper;
        }

        public async Task<ParentDto> CreateParentAsync(ParentDto dto)
        {
            var parentEntity = _mapper.Map<Parent>(dto);
            await _parentRepository.AddAsync(parentEntity);
            return _mapper.Map<ParentDto>(parentEntity);            
        }

        public async Task<bool> DeleteParentAsync(int id)
        {
            return await _parentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ParentDto>> GetAllAsync()
        {
            var parents = await _parentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ParentDto>>(parents);
        }

        public async Task<ParentDto> GetParentByIdAsync(int id)
        {
            var parent = await _parentRepository.GetByIdAsync(id);
            if(parent == null)
            {
                return null;
            }
            return _mapper.Map<ParentDto>(parent);
        }

        public async Task<ParentDto> UpdateParentAsync(int parentId, ParentDto dto)
        {
            var existingParent = await _parentRepository.GetByIdAsync(parentId);
            if (existingParent == null)
            {
                return null;
            }
            _mapper.Map(dto, existingParent);
            await _parentRepository.UpdateAsync(existingParent);
            return _mapper.Map<ParentDto>(existingParent);
        }
    }
}