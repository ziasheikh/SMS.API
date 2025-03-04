using Microsoft.AspNetCore.Mvc;
using SMS.Application.Interfaces;

namespace SMS.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}/report")]
        public async Task<IActionResult> GetStudentReport(int id)
        {
            try
            {
                var report = await _studentService.GetStudentReportAsync(id);
                return Ok(report);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}
