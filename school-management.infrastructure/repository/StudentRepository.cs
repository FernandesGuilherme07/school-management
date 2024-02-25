using Microsoft.EntityFrameworkCore;
using school_management.Application.repositories;
using school_management.infrastructure.context;
using school_management.shared.input_models;
using school_management.shared.models;
using school_management.shared.view_models;
using System.Linq;

namespace school_management.infrastructure.repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EFCoreDbContext _context;

        public StudentRepository(EFCoreDbContext context)
        {
            _context = context;
        }
        public async Task AddstudentAsync(AddstudentInputModel data)
        {            
            var schoolSubjectsModels = new List<SchoolSubjectModel>();

            foreach (var item in data.SchoolSubjects.ToList())
            {
                var schoolSubjects = await _context.SchoolSubjects
                                               .Where(s => s.Id == item.Id)
                                               .ToListAsync();

                schoolSubjects.ForEach(schoolSubject => schoolSubjectsModels.Add(schoolSubject));
            }

            var model = new StudentModel();
            model.Age = data.Age;
            model.Name = data.Name;
            model.Id = data.ToEntity().Id; 
            model.Email = data.Email;


            model.SchoolSubjects = schoolSubjectsModels;

            await _context.Students.AddAsync(model);
            await _context.SaveChangesAsync();
        }



        public async Task DeletestudentAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();
        }
        public async Task<IList<studentViewModel>> GetAllstudentsAsync()
        {
            var data = await _context.Students
                                     .Include(p => p.SchoolSubjects)
                                     .ToListAsync();

            var result = data.Select(student =>
                new studentViewModel(student.Id, student.Name, student.Age, student.Email, student.SchoolSubjects)
            ).ToList();

            return result;
        }

        public async Task<studentViewModel>? GetstudentByIdAsync(Guid id)
        {
            var data = await _context.Students
                                     .Include(p => p.SchoolSubjects)
                                     .AsNoTracking()
                                     .SingleOrDefaultAsync(p => p.Id == id);

            if (data == null)
            {
                return null;
            }

            var result = new studentViewModel(data.Id, data.Name, data.Age, data.Email, data.SchoolSubjects);

            return result;
        }

        public async Task<studentViewModel>? GetstudentEmailAsync(string email)
        {
            var data = await _context.Students
                                     .Include(p => p.SchoolSubjects)
                                     .AsNoTracking()
                                     .SingleOrDefaultAsync(p => p.Email == email);

            if (data == null)
            {
                return null;
            }

            var result = new studentViewModel(data.Id, data.Name, data.Age, data.Email, data.SchoolSubjects);

            return result;
        }

        public async Task RegisterMaterialForStudentAsync(RegisterMaterialForStudentInputModel data)
        {
            var student = await _context.Students.FindAsync(data.StudentId);
            var subject = await _context.SchoolSubjects.FindAsync(data.SchoolSubjectId);

            if (student != null && subject != null)
            {
                student.SchoolSubjects ??= new List<SchoolSubjectModel>();
                student.SchoolSubjects.Add(subject);
                await _context.SaveChangesAsync();
            }


        }


        public async Task UpdatestudentAsync(UpdatestudentInputModel data)
        {
            var student = await _context.Students.FindAsync(data.Id);

            student.Name = data.Name;
            student.Age = data.Age;
            student.Email = data.Email;

            await _context.SaveChangesAsync();
        }

    }
}
