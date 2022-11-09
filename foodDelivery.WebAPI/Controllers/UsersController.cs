using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using foodDelivery.Entity.Models;
using foodDelivery.Repository;
using Microsoft.AspNetCore.Mvc;

namespace foodDelivery.WebAPI.Controllers
{
    /// <summary>
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepository<User> _repository;

        /// <summary>
        /// Users controller
        /// </summary>
        public UsersController(IRepository<User> repository)
        {
            _repository = repository;
        }

        
        /// <summary>
        /// Get users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUsers()
        {
            var myUser= new User()
            {
                Surname="Gusev",
                Name="Ilya",
                Email="am@asd",
                PasswordHash="sdf343fss",
                BirthDate=DateTime.Now,
                IsBlocked=false
            };
           _repository.Save(myUser);
           myUser.Email="34@ty5";
           _repository.Save(myUser);
            var users = _repository.GetAll();
            return Ok(users);
        }
        
        /// <summary>
        /// Delete users
        /// </summary>
        /// <param name="users"></param>
        [HttpDelete]
        public IActionResult DeleteUsers(User user)
        {
            _repository.Delete(user);
            return Ok();
        }
        /// <summary>
        /// Post users
        /// </summary>
        /// <param name="users"></param>
        [HttpPost]
        public IActionResult PostUsers(User user)
        {
           var result= _repository.Save(user);
            return Ok(result);
        }
        
        /// <summary>
        /// Update users
        /// </summary>
        /// <param name="users"></param>
        [HttpPut]
        public IActionResult Updatesers(User user)
        {
            return PostUsers(user);
        }
          
    }

}