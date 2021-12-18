using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;

        public UsersController(DataContext context)
        {
            this.context = context;
        }
        // Gets the collection of users
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            return context.Users.ToList();
        }
        // Gets a single user by id
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            return context.Users.Find(id);
        }
    }
}