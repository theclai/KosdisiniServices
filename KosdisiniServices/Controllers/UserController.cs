using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KosdisiniServices.Domain.DataModel;
using KosdisiniServices.Interfaces;
using KosdisiniServices.Core;
using KosdisiniServices.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace KosdisiniServices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;

        public UserController(IUserRepository userRepository, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var Users = await _userRepository.GetAll();
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            var User = await _userRepository.GetById(id);
            return Ok(User);
        }

        [HttpPost, Route("PostSimulatingError")]
        public IActionResult PostSimulatingError([FromBody] UserViewModel value)
        {
            var User = new User(value.FullName, value.MobileNumber, value.Email, value.UserType);
            _userRepository.Add(User);

            // The User will not be added
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserViewModel value)
        {
            var User = new User(value.FullName, value.MobileNumber, value.Email, value.UserType);
            _userRepository.Add(User);

            // it will be null
            var testUser = await _userRepository.GetById(User.Id);

            // If everything is ok then:
            await _uow.Commit();

            // The User will be added only after commit
            testUser = await _userRepository.GetById(User.Id);

            return Ok(testUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(Guid id, [FromBody] UserViewModel value)
        {
            var User = new User(value.FullName, value.MobileNumber, value.Email, value.UserType);

            _userRepository.Update(User);

            await _uow.Commit();

            return Ok(await _userRepository.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            _userRepository.Remove(id);

            // it won't be null
            var testUser = await _userRepository.GetById(id);

            // If everything is ok then:
            await _uow.Commit();

            // not it must by null
            testUser = await _userRepository.GetById(id);

            return Ok();
        }
    }
}
