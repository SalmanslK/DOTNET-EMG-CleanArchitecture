using CleanArchitecture.Business.DTOs;
using CleanArchitecture.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeDTO dto)
        {
            var result = await _service.Add(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeDTO dto)
        {
            var result = await _service.Update(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _service.Get(id);
            await _service.Delete(employee);
            return Ok();
        }
    }
}
