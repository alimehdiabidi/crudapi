using crudapi.Model;
using crudapi.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crudapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo repo;
        public EmployeeController(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var _list=await this.repo.GetAll();
            if (_list != null)
            {
               return Ok(_list);

            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("Getbycode/{code}")]
        public async Task<IActionResult> Getbycode(int code )
        {
            var _list = await this.repo.Getbycode(code);
            if (_list != null)
            {
                return Ok(_list);

            }
            else
            {
                return NotFound();
            }
        }
          
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody ] Employee employee)
        {
            var _result = await this.repo.Create(employee);
           
                return Ok(_result);

            
        }
    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Employee employee , int code )
    {
        var _result = await this.repo.Update(employee,code);

        return Ok(_result);

    }
        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int code)
        {
            var _result = await this.repo.Remove( code);

            return Ok(_result);

        }

    }
}


