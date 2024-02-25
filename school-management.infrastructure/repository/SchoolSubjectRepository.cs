using Microsoft.EntityFrameworkCore;
using school_management.Application.repositories;
using school_management.infrastructure.context;
using school_management.shared.input_models;
using school_management.shared.models;
using school_management.shared.view_models;

namespace school_management.infrastructure.repository
{
    public class SchoolSubjectRepository : ISchoolSubjectRepository
    {
        private readonly EFCoreDbContext _context;

        public SchoolSubjectRepository(EFCoreDbContext context)
        {
            _context = context;
        }

        public async Task AddSchoolSubjectAsync(AddSchoolSubjectInputModel data)
        {
            var schoolSubject = new SchoolSubjectModel
            {
                Id = data.ToEntity().Id,
                Name = data.Name,
                Description = data.Description
            };

            await _context.SchoolSubjects.AddAsync(schoolSubject);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<SchoolSubjectViewModel>> GetAllSchoolSubjectsAsync()
        {
            var schoolSubjects = await _context.SchoolSubjects
                .Select(s => new SchoolSubjectViewModel(s.Id, s.Name, s.Description, null))
                .ToListAsync();

            return schoolSubjects;
        }

        public async Task<SchoolSubjectViewModel> GetASchoolSubjectByIdAsync(Guid id)
        {
            var schoolSubject = await _context.SchoolSubjects
                .Where(s => s.Id == id)
                .Select(s => new SchoolSubjectViewModel(s.Id, s.Name, s.Description, s.Students))
                .FirstOrDefaultAsync();

            return schoolSubject;
        }

        public async Task<SchoolSubjectViewModel> GetASchoolSubjectByNameAsync(string name)
        {
            var schoolSubject = await _context.SchoolSubjects
                .Where(s => s.Name == name)
                .Select(s => new SchoolSubjectViewModel(s.Id, s.Name, s.Description, null))
                .FirstOrDefaultAsync();

            return schoolSubject;
        }

        public async Task<bool> checkIfThereIsRelationship (RegisterMaterialForStudentInputModel inputModel)
        {
            var student = await _context.Students
                .Include(s => s.SchoolSubjects)
                .FirstOrDefaultAsync(s => s.Id == inputModel.StudentId);

            var subject = await _context.SchoolSubjects.FindAsync(inputModel.SchoolSubjectId);

            if (student == null || subject == null)
            {
                throw new ArgumentException("Student or Subject not found");
            }

            if (student.SchoolSubjects != null && student.SchoolSubjects.Any(ss => ss.Id == subject.Id))
            {
                return true;
            } 

            return false;

        }

        public async Task DeletestudentAsync(Guid id)
        {
            var schoolSubject = await _context.SchoolSubjects.FindAsync(id);
            if (schoolSubject == null)
            {
                throw new ArgumentException($"School subject with id {id} not found");
            }

            _context.SchoolSubjects.Remove(schoolSubject);
            await _context.SaveChangesAsync();
        }


        public async Task<SchoolSubjectWithStudentsViewModel> GetSchoolSubjectWithStudentsAsync(Guid schoolSubjectId)
        {
            var schoolSubject = await _context.SchoolSubjects
             .Include(ss => ss.Students)
             .FirstOrDefaultAsync(ss => ss.Id == schoolSubjectId);

            if (schoolSubject == null)
            {
                throw new ArgumentException("SchoolSubject not found");
            }

            return new SchoolSubjectWithStudentsViewModel
            {
                SchoolSubject = schoolSubject,
                Students = schoolSubject.Students.ToList()
            };
        }
    }
}
