using ProteinTrackerWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProteinTrackerWebAPI.Controllers
{
    public class UserController : ApiController
    /* another comment to test commit */
    /* comment to test commit */
    /* comment to test commit */
    {
        private UserRepository repository = new UserRepository();
        public string Delete(int id)
        {
            string username;
            if (repository.GetById(id) != null)
            {
                username = repository.GetById(id).Name;
            }else
            {
                username = id.ToString();
            }

             
            return (repository.Delete(id) >= 0)?  "successfully deleted user " + username:
             "Failed to Delete user " + username;
        }

        public int Put(int id, [FromBody] int amount)
        {
            var user = repository.GetById(id);
            if (user == null)
                return -1;
            user.Total += amount;
            repository.Save(user);
            return user.Total;
        }


        public int Post([FromBody] CreateUserRequest request)
        {
            var user = new User { Goal = request.Goal, Name = request.Name, Total = 0 };
            repository.Add(user);

            return user.UserId;
        }


        public IEnumerable<User> Get()
        {
            return new List<User>(repository.GetAll());
        }
        public class CreateUserRequest
        {
            public int Goal { get; set; }
            public string Name { get; set; }


        }

    }
}
