using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repository;

namespace test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser userRepository;

        public UserController(IUser userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost(Name = "CreateUser")]
        public async Task<ActionResult> CreateUser(User user)
        {
            try
            {
                return Ok(await userRepository.CreateUser(user));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error in employee creation");
            }
        }
        [HttpDelete(Name = "DeleteUser")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            try
            {
                return Ok(await userRepository.DeleteUser(userId));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "error in deleting employee");
            }
        }
        [HttpPost(Name = "validateUser")]
        public bool validateUser(string userName, string password)
        {
            try
            {
                return userRepository.ValidateUser(userName, password);
            }
            catch
            {
                return false;
            }
        }

    }
}
