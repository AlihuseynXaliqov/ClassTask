using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Business.DTOs.Assignment;
using TaskApp.Business.DTOs.Tag;
using TaskApp.Business.Service.Implementation;
using TaskApp.Business.Service.Interface;

namespace TaskApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService service;

        public AssignmentController(IAssignmentService service)
        {
            this.service = service;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await service.GetById(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAssignmentDto dto)
        {
            return StatusCode(StatusCodes.Status201Created, await service.CreateAsync(dto));
        }




        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateAssignmentDto dto)
        {
            await service.Update(dto);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await service.Delete(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }

    }
}
