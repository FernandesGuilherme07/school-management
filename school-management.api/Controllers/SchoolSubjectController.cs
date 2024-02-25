using Microsoft.AspNetCore.Mvc;
using school_management.Application.use_cases;
using school_management.Application.use_cases.contracts;
using school_management.shared.input_models;

namespace school_management.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SchoolSubjectController : Controller
    {
        private readonly ICreateSchoolSubjectUseCase _createSchoolSubjectUseCase;
        private readonly IDeleteSchoolSubjectUseCase _deleteSchoolSubjectUseCase;
        private readonly IGetAllSchoolSubjectsUSeCase _getAllSchoolSubjectsUSeCase;
        private readonly IShowSchoolSubjectByIdUseCase _showSchoolSubjectByIdUseCase;

        public SchoolSubjectController(
            ICreateSchoolSubjectUseCase createSchoolSubjectUseCase,
            IDeleteSchoolSubjectUseCase deleteSchoolSubjectUseCase,
            IGetAllSchoolSubjectsUSeCase getAllSchoolSubjectsUSeCase,
            IShowSchoolSubjectByIdUseCase showSchoolSubjectByIdUseCase
            )
        {
            _createSchoolSubjectUseCase = createSchoolSubjectUseCase;
            _deleteSchoolSubjectUseCase = deleteSchoolSubjectUseCase;
            _getAllSchoolSubjectsUSeCase = getAllSchoolSubjectsUSeCase;
            _showSchoolSubjectByIdUseCase = showSchoolSubjectByIdUseCase;
        }

        [HttpGet("GetAllSchoolSubject")]
        public async Task<ActionResult> GetAllSchoolSubject()
        {
            try
            {
                var result = await _getAllSchoolSubjectsUSeCase.Execute();
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine("error: " + err);
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        [HttpGet("GetSchoolSubjectById")]
        public async Task<ActionResult> GetSchoolSubjectById(Guid id)
        {
            try
            {
                var result = await _showSchoolSubjectByIdUseCase.Execute(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("error: " + err);
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        [HttpPost("CreateSchoolSubject")]
        public async Task<ActionResult> CreateSchoolSubject([FromBody] AddSchoolSubjectInputModel data)
        {
            try
            {
                var result = await _createSchoolSubjectUseCase.Execute(data);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine("error: " + err);
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        // POST: SchoolSubjectController/Create
        [HttpDelete("DeleteSchoolSubjectById")]
        public async Task<ActionResult> DeleteSchoolSubjectById(Guid Id)
        {
            try
            {
                var result = await _deleteSchoolSubjectUseCase.Execute(Id);
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }

            }
            catch (Exception err)
            {
                Console.WriteLine("error: " + err);
                return StatusCode(500, "An unexpected error occurred");
            }
        }

    }
}
