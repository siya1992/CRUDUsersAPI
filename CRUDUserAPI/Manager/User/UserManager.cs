using CRUDUserAPI.DTO.User;
using CRUDUserAPI.Models;
using CRUDUserAPI.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDUserAPI.Manager.User
{
    public class UserManager
    {
        public bool SaveUser(UserDetailsDTO userDetailsRequest)
        {
            var response = false;
            try
            {
                    UserRepository userRepo = new UserRepository();
                    var userDetail = new UserDetails
                    {
                        ID=userDetailsRequest.Id != null? userDetailsRequest.Id : 0,
                        NAME=userDetailsRequest.Name,
                        EMAIL=userDetailsRequest.Email,
                        MOBILENO=userDetailsRequest.MobileNo,
                        USERROLE=userDetailsRequest.UserRole,
                        USERSTATUS=userDetailsRequest.UserStatus
                    };
                    response = userRepo.SaveUser(userDetail);
        
            }
            catch (Exception ex)
            {

            }

            return response;
        }

         #region All User Details
        public UserDetailsResponseDTO GetAllUsers()
        {
                UserRepository userRepo = new UserRepository();
                var UserDetailsResponse = new UserDetailsResponseDTO();
                var response = userRepo.GetAllUsers();
                if (response != null)
                {

                    return response;
                                                                 
                }
                return UserDetailsResponse;
            
        }
         #endregion

        #region User Details
        public UserDetailsResponseDTO GetUserById(int userId)
        {
            UserRepository userRepo = new UserRepository();
            UserDetailsResponseDTO UserDetailsResponse = new UserDetailsResponseDTO();
            var response = userRepo.GetUserById(userId);
            if (response != null)
            {
                return response;
            }
            return UserDetailsResponse;
        }
        #endregion
        #region Delete User Details
        public bool DeleteUser(int userId)
        {
            UserRepository userRepo = new UserRepository();
            var response = userRepo.DeleteUser(userId);
            return response;
        }
        #endregion

    }
}