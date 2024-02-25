using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_management.Application.use_cases;
using school_management.Application.use_cases.contracts;
using school_management.shared.input_models;

namespace school_management.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly ICreatestudentUseCase _createStudentUseCase;
        private readonly IDeletestudentUseCase _deletestudentUseCase;
        private readonly IGetAllstudentsUseCase _getAllstudentsUseCase;
        private readonly IEnrollStudentInSubjectUseCase _enrollStudentInSubjectUseCase;
        private readonly IShowStudentByIdUseCase _showStudentByIdUseCase;
        private readonly IUpdatestudentDataUseCase _updatestudentDataUseCase;

        public StudentsController(
            ICreatestudentUseCase createStudentUseCase,
            IDeletestudentUseCase deletestudentUseCase,
            IGetAllstudentsUseCase getAllstudentsUseCase,
            IEnrollStudentInSubjectUseCase enrollStudentInSubjectUseCase,
            IShowStudentByIdUseCase showStudentByIdUseCase,
            IUpdatestudentDataUseCase updatestudentDataUseCase)
        {
            _createStudentUseCase = createStudentUseCase;
            _deletestudentUseCase = deletestudentUseCase;
            _getAllstudentsUseCase = getAllstudentsUseCase;
            _enrollStudentInSubjectUseCase = enrollStudentInSubjectUseCase;
            _showStudentByIdUseCase = showStudentByIdUseCase;
            _updatestudentDataUseCase = updatestudentDataUseCase;
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult> CreateStudent([FromBody] AddstudentInputModel data)
        {
            try
            {
                var result = await _createStudentUseCase.Execute(data);
                if (result.Success)
                {
                    return Ok(result);
                } else
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

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult> GetAllStudents()
        {
            try
            {
                var result = await _getAllstudentsUseCase.Execute();
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

        [HttpGet("GetStudentById")]
        public async Task<ActionResult> GetStudentById(Guid id)
        {
            try
            {
                var result = await _showStudentByIdUseCase.Execute(id);
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

        [HttpPut("UpdateStudentData")]
        public async Task<ActionResult> UpdateStudentData(UpdatestudentInputModel data)
        {
            try
            {
                var result = await _updatestudentDataUseCase.Execute(data);
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

        [HttpPost("RegisterNewSubjectForStudent")]
        public async Task<ActionResult> RegisterNewSubjectForStudent(RegisterMaterialForStudentInputModel data)
        {
            try
            {
                var result = await _enrollStudentInSubjectUseCase.Execute(data);
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

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult> DeleteStudent(Guid Id)
        {
            try
            {
                var result = await _deletestudentUseCase.Execute(Id);
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
