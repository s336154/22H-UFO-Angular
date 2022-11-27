using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UFO_Webapplikasjon.DAL;
using UFO_Webapplikasjon.Model;

namespace UFO_Webapplikasjon.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly InUserRepository _db;

        private ILogger<UserController> _log;

        public UserController(InUserRepository db, ILogger<UserController> log)
        {
            _db = db;
            _log = log;
        }

        [HttpGet]
        public async Task<ActionResult> ReadAllUsers()
        {
            List<User> everyUsers = await _db.ReadAllUsers();
            return Ok(everyUsers);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(User innUser)
        {
            bool returOK = await _db.CreateUser(innUser);

            if (!returOK)
            {
                _log.LogInformation("The user could not be created.");
                return BadRequest("The user could not be saved.");
            }
            return Ok("The user is now created.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            bool returOK = await _db.DeleteUser(id);

            if (!returOK)
            {
                _log.LogInformation("The user could not be deleted.");
                return NotFound("The user could not be deleted.");
            }
            return Ok("The user is now deleted.");
        }

        [HttpGet]
        public async Task<ActionResult> ReadLatestUser()
        {
            User singleUser = await _db.ReadLatestUser();

            if (singleUser == null)
            {
                _log.LogInformation("The latest user could not be found.");
                return NotFound("The latest user could not be found.");
            }
            return Ok("The latest user was found.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ReadOneUser(int id)
        {
            User singleUser = await _db.ReadOneUser(id);

            if (singleUser == null)
            {
                _log.LogInformation("The user was not found.");
                return NotFound("The user was not found.");
            }
            return Ok("The user was found.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(User updateUser)
        {
            bool returOK = await _db.UpdateUser(updateUser);

            if (!returOK)
            {
                _log.LogInformation("The user could not be updated.");
                return NotFound("The user could not be updated.");
            }
            return Ok("The user is now changed.");
        }


        public async Task<ActionResult> LoggInn(User user)
        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _db.LoggInn(user);
                if (!returnOK)
                {
                    _log.LogInformation("Innloggingen feilet for bruker" + user.Username);
                    return Ok(false);
                }
                return Ok(true);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }


    }
}