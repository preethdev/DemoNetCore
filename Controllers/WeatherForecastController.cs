using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestDemo.Controllers
{
    
    [Route("[controller]")]
    public class userListController : ControllerBase
    {
        private readonly ILogger<userListController> _logger;

        public userListController(ILogger<userListController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Getuserlist")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public List<Quota> Get()
        {
            List<Quota> quota = new List<Quota>();
            quota.Add(new Quota { userId = "1", Name = "User1", Age = "25" });
            quota.Add(new Quota { userId = "2", Name = "User2", Age = "26" });
            quota.Add(new Quota { userId = "3", Name = "User3", Age = "27" });
            quota.Add(new Quota { userId = "4", Name = "User4", Age = "28" });
            quota.Add(new Quota { userId = "5", Name = "User5", Age = "29" });

            return quota;
        }
    }
}