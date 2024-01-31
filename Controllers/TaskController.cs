using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIAssessment.IRepo;

namespace WebAPIAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskRepo _repo;

        public TaskController(ITaskRepo repo)
        {

            _repo = repo;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var data = _repo.GetAllTasks();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);

            }

        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int? id)
        {
            if (!id.HasValue)
            {

                return BadRequest();
            }
            else
            {
                var data = _repo.GetTaskById(id.Value);
                if (data == null)
                {
                    return NotFound();

                }
                else
                {
                    return Ok(data);
                }
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Model.Task user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
              
                _repo.AddTasks(user);
                return Ok("Added successfully");
            }
        }

        [HttpPost]
        [Route("Update/{id}")]
        public IActionResult Update(Model.Task task, int id)
        {
            var data = _repo.UpdateTasks(task, id);

            if (data == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok("Updated Successfully");
            }

        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            bool data = _repo.DeleteTasks(id);
            if (data == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

    }
}
