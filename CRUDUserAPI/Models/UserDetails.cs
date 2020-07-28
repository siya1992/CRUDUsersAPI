using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDUserAPI.Models
{
    public class UserDetails
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public int MOBILENO { get; set; }
        public string USERROLE { get; set; }
        public string USERSTATUS { get; set; }
    }
}