using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationTask.Data;
using RegistrationTask.Models;

namespace RegistrationTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserDbContext dbContext;

        public UserController(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await dbContext.UsersRegistration.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await dbContext.UsersRegistration.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = addUserRequest.Name,
                MobileNumber = addUserRequest.MobileNumber,
                Email = addUserRequest.Email,
                DateOfBirth = addUserRequest.DateOfBirth,
                Gender = addUserRequest.Gender,
                Address = addUserRequest.Address,
                Country = addUserRequest.Country,
                State = addUserRequest.State,
                City = addUserRequest.City,
                PINCode = addUserRequest.PINCode,
            };
            await dbContext.UsersRegistration.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateVehicle([FromRoute] Guid id, AddUserRequest updateUserRequest)
        {
            var user = await dbContext.UsersRegistration.FindAsync(id);

            if (user != null)
            {
                user.Name = updateUserRequest.Name;
                user.DateOfBirth = updateUserRequest.DateOfBirth;
                user.MobileNumber = updateUserRequest.MobileNumber;
                user.Email = updateUserRequest.Email;
                user.Gender = updateUserRequest.Gender; 
                user.Address = updateUserRequest.Address; 
                user.Country = updateUserRequest.Country; 
                user.State = updateUserRequest.State; 
                user.City = updateUserRequest.City; 
                user.PINCode = updateUserRequest.PINCode;
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await dbContext.UsersRegistration.FindAsync(id);
            if (user != null)
            {
                dbContext.UsersRegistration.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }
        
    }
}
