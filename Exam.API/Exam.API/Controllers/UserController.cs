using Exam.API.Interfaces;
using Exam.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var users = _unitOfWork.UserRepository.GetAll();
            return new JsonResult(users);
        }
        // GET api/values/4
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_unitOfWork.UserRepository.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] List<User> users)
        {
            foreach (var user in users)
            {
                var result = _unitOfWork.UserRepository.Get(user.id);
                if (result == null)
                {
                    _unitOfWork.UserRepository.Add(user);
                    _unitOfWork.Complete();
                }
            }

            return new JsonResult(users);
        }

        // PUT api/values/4
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            if (id != user.id)
                return BadRequest();

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Complete();
            return new JsonResult(user);
        }

        // DELETE api/values/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _unitOfWork.UserRepository.Get(id);
            if (result != null)
            {
                _unitOfWork.UserRepository.Delete(id);
                _unitOfWork.Complete();
            }

            return new JsonResult(result);
        }


    }
}