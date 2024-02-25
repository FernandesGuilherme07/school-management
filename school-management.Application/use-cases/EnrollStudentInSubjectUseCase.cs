using school_management.Application.repositories;
using school_management.Application.use_cases.contracts;
using school_management.shared.input_models;
using school_management.shared.view_models;

namespace school_management.Application.use_cases
{
    public class EnrollStudentInSubjectUseCase(IStudentRepository studentRepository, ISchoolSubjectRepository schoolSubjectRepository) : IEnrollStudentInSubjectUseCase
    {
        private readonly ISchoolSubjectRepository _schoolSubjectRepository = schoolSubjectRepository;
        private readonly IStudentRepository _studentRepository = studentRepository;
        public async Task<ApplicationViewModel> Execute(RegisterMaterialForStudentInputModel data)
        {
            var schoolSubjectIdAlreadyExists = await _schoolSubjectRepository.GetASchoolSubjectByIdAsync(data.SchoolSubjectId);

            if (schoolSubjectIdAlreadyExists == null)
            {
                return new ApplicationViewModel("school subject id already exists", false, null, null);
            }
            var studentIdAlreadyExists = await _studentRepository.GetstudentByIdAsync(data.StudentId);

            if (studentIdAlreadyExists == null)
            {
                return new ApplicationViewModel("studentid already exists", false, null, null);
            }

            var checkIfThereIsRelationship = await _schoolSubjectRepository.checkIfThereIsRelationship(data);

            if(checkIfThereIsRelationship)
            {
                return new ApplicationViewModel("This student is already registered in this subject", false, null, null);

            }

            await _studentRepository.RegisterMaterialForStudentAsync(data);


            return new ApplicationViewModel("student successfully enrolled in the subject", true, null, null);

        }
    }
}
