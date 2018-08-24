using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetJwt.Contracts;
using AutoMapper;
using dotnetJwt.Entities;
using dotnetJwt.Dtos;

namespace dotnet_jwt.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository taskRepository;
        private readonly IMapper mapper;

        public TasksController(ITaskRepository taskRepository, IMapper mapper) 
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var tasks = taskRepository.GetAllTasks();
            var taskDtos = mapper.Map<IEnumerable<TaskEntity>, IEnumerable<TaskDto>>(tasks);

            return new JsonResult(taskDtos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(Guid id)
        {
            var task = await taskRepository.FindTask(id);
            var taskDto = mapper.Map<TaskEntity, TaskDto>(task);

            return new JsonResult(taskDto);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskEntity task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await taskRepository.AddTask(task);

            return Ok();

        }

                // POST api/values
        [HttpPost("update")]
        public async Task<IActionResult> Update(TaskEntity task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await taskRepository.UpdateTask(task);

            return Ok();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            TaskEntity task = await taskRepository.DeleteTask(id);
            var taskDto = mapper.Map<TaskEntity, TaskDto>(task);

            return new JsonResult(taskDto);
        }
    }
}
