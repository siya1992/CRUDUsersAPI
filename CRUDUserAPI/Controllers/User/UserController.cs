using CRUDUserAPI.DTO.User;
using CRUDUserAPI.Manager.User;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
//using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CRUDUserAPI.Controllers.User
{
 
    
    public class UserController : ApiController
    {
        // GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetAllUsers")]
        public UserDetailsResponseDTO GetAllUsers()
        {
           //var response = _userManager.GetAllUsers();
            UserManager userManager = new UserManager();
            var response = userManager.GetAllUsers();
            return response;
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetUserById")]
        public UserDetailsResponseDTO GetUserById(int userId)
        {
            //var response = _userManager.GetUserById(userId);
            UserManager userManager = new UserManager();
            var response = userManager.GetUserById(userId);
            return response;
        }

        
        [AllowAnonymous]
        [HttpOptions]
        [HttpPost]
        [ActionName("SaveUser")]
        public bool SaveUser([FromBody] UserDetailsDTO userDetails)
        {
            
            if (userDetails != null)
            {
                UserManager userManager = new UserManager();
                var response = userManager.SaveUser(userDetails);
                return response;
            }
            else
            {
                return false;
            }
        }

        [AllowAnonymous]
        [HttpOptions]
        [HttpDelete]
        [ActionName("DeleteUser")]
        public bool DeleteUser(int userId)
        {
            //var response = _userManager.DeleteUser(userId);
            UserManager userManager = new UserManager();
           
            var response = userManager.DeleteUser(userId);
            return response;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[ActionName("UpdateUser")]
        //public bool UpdateUser([FromBody] UserDetailsDTO userDetails)
        //{
        //    if (userDetails != null)
        //    {
        //        UserManager userManager = new UserManager();
        //        var response = userManager.UpdateUser(userDetails);
        //        return response;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}