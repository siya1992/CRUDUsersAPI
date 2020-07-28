using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDUserAPI.DTO.User
{
    public class UserDetailsResponseDTO
    {
        public List<UserDetailsDTO> UserDetails { get; set; }
    }
}