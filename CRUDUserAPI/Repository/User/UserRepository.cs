using CRUDUserAPI.DTO.User;
using CRUDUserAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDUserAPI.Repository.User
{
    public class UserRepository
    {
        private readonly string CS = ConfigurationManager.ConnectionStrings["UserCrud"].ConnectionString;
        public bool SaveUser(UserDetails userDetailsRequest)
        {
            UserDetails response = new UserDetails();
            var userDetails = new UserDetailsDTO();
            var cmd = new SqlCommand();
            using (SqlConnection con = new SqlConnection(CS))
            {
                if (userDetailsRequest.ID != 0)
                {
                    cmd = new SqlCommand("Update [dbo].[USER] SET NAME=@name,EMAIL=@email,MOBILENO=@mobileno,USERROLEID=@userroleid,USERSTATUSID=@userstatusid where ID=@id", con);
                    cmd.Parameters.AddWithValue("@id", userDetailsRequest.ID);
                }
                else
                {
                    cmd = new SqlCommand("Insert into [dbo].[USER](NAME,EMAIL,MOBILENO,USERROLEID,USERSTATUSID) VALUES(@name,@email,@mobileno,@userroleid,@userstatusid)", con);
                }
                
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Parameters.AddWithValue("@name", userDetailsRequest.NAME);
                cmd.Parameters.AddWithValue("@email", userDetailsRequest.EMAIL);
                cmd.Parameters.AddWithValue("@mobileno", userDetailsRequest.MOBILENO);
                cmd.Parameters.AddWithValue("@userroleid", userDetailsRequest.USERROLE);
                cmd.Parameters.AddWithValue("@userstatusid", userDetailsRequest.USERSTATUS);
                SqlDataReader rdr = cmd.ExecuteReader();
            } 

            return true;
        }

        #region All User Details
        public UserDetailsResponseDTO GetAllUsers()
        {

            var userDetailsResponse = new UserDetailsResponseDTO();
            
            userDetailsResponse.UserDetails = new List<UserDetailsDTO>();
            using (SqlConnection con = new SqlConnection(CS))    
            {
                var cmd = new SqlCommand("Select * from [dbo].[USER]", con);    
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var userDetails = new UserDetailsDTO();
                    userDetails.Name = rdr["NAME"].ToString();
                    userDetails.Email = rdr["EMAIL"].ToString();
                    userDetails.MobileNo = Convert.ToInt32(rdr["MOBILENO"]);
                    userDetails.UserRole = rdr["USERROLEID"].ToString();
                    userDetails.UserStatus = rdr["USERSTATUSID"].ToString();
                    userDetailsResponse.UserDetails.Add(userDetails);
                    userDetails.Id = Convert.ToInt32(rdr["ID"]);

                }
               
                return userDetailsResponse;     
            } 
        }
        #endregion

        #region User Details
        public UserDetailsResponseDTO GetUserById(int userId)
        {
            
            var userDetailsResponse = new UserDetailsResponseDTO();
            userDetailsResponse.UserDetails = new List<UserDetailsDTO>();
           
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("Select * from [dbo].[USER] u where u.id = @userId", con);
                cmd.Parameters.AddWithValue("@userId",userId);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var userDetails = new UserDetailsDTO();
                    userDetails.Name = rdr["NAME"].ToString();
                    userDetails.Email = rdr["EMAIL"].ToString();
                    userDetails.MobileNo = Convert.ToInt32(rdr["MOBILENO"]);
                    userDetails.UserRole = rdr["USERROLEID"].ToString();
                    userDetails.UserStatus = rdr["USERSTATUSID"].ToString();
                    userDetailsResponse.UserDetails.Add(userDetails);
                }

                return userDetailsResponse;
            } 
        }
        #endregion
        #region Delete User Details
        public bool DeleteUser(int userId)
        {
            var response = false;
            using (SqlConnection con = new SqlConnection(CS))
            {
                var cmd = new SqlCommand("Delete from [dbo].[USER] where id=@userId", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.ExecuteNonQuery();
                response = true;
            }
            return response;
        }
        #endregion
        
    }
}