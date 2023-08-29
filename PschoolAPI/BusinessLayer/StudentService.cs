using AutoMapper;
using Pschool.Business.Dto;
using Pschool.DAL;
using Pschool.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pschool.Business
{
    public class StudentService : IStudentService
    {
        private readonly IRepositoryBase<Student> _studentRepository;
        private readonly IMapper _mapper;
        private readonly PschoolDbContext _context;
        public StudentService(IRepositoryBase<Student> studentRepository, IMapper mapper, PschoolDbContext context)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<StudentDto> CreateStudentAsync(StudentCreateUpdateDto dto)
        {
            var studentEntity = _mapper.Map<Student>(dto);
            await _studentRepository.AddAsync(studentEntity);
            return _mapper.Map<StudentDto>(studentEntity);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            return await _studentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            foreach(var student in students)
            {
                await _context.Entry(student)
                .Reference(s => s.Parent)
                .LoadAsync();
            }
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return null;
            }
            await _context.Entry(student)
                .Reference(s => s.Parent)
                .LoadAsync();
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentByParentIdAsync(int parentId)
        {
            var students = await _studentRepository.GetAllAsync();
            students = students.Where(x=> x.ParentId == parentId);
            foreach (var student in students)
            {
                await _context.Entry(student)
                .Reference(s => s.Parent)
                .LoadAsync();
            }
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> UpdateStudentAsync(int id, StudentCreateUpdateDto dto)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent == null)
            {
                return null;
            }
            _mapper.Map(dto, existingStudent);
            await _studentRepository.UpdateAsync(existingStudent);
            return _mapper.Map<StudentDto>(existingStudent);
        }
    }
}
