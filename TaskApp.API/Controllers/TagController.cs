﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Business.DTOs.Tag;
using TaskApp.Business.Service.Interface;

namespace TaskApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {

        ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await tagService.GetById(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(StatusCodes.Status200OK,tagService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateTagDto dto)
        {
            return StatusCode(StatusCodes.Status201Created, await tagService.CreateAsync(dto));
        }

        


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateTagDto dto)
        {
            await tagService.Update(dto);
            return StatusCode(StatusCodes.Status202Accepted);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
           await tagService.Delete(id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
    }
}
