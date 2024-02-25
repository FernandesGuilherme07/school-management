using school_management.shared.view_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management.Application.use_cases.contracts
{
    public interface IShowSchoolSubjectByIdUseCase
    {
        Task<ApplicationViewModel> Execute(Guid SchoolSubjectId);
    }
}
