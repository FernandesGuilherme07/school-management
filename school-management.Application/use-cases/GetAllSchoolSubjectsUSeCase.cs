using school_management.Application.repositories;
using school_management.Application.use_cases.contracts;
using school_management.shared.view_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management.Application.use_cases
{
    public class GetAllSchoolSubjectsUSeCase(ISchoolSubjectRepository schoolSubjectRepository) : IGetAllSchoolSubjectsUSeCase
    {
        private readonly ISchoolSubjectRepository _schoolSubjectRepository = schoolSubjectRepository;
        public async Task<ApplicationViewModel> Execute()
        {
            var result = await _schoolSubjectRepository.GetAllSchoolSubjectsAsync();

            return new ApplicationViewModel("consultation carried out successfully", true, result, null);
        }
    }
}
