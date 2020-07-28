using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDUserAPI.DTO.User
{
    public class UserDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string UserRole { get; set; }
        public string UserStatus { get; set; }
    }
}