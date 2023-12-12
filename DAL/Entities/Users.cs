using System;

namespace DAL.Entities
{
    public class Users
    {
        public int UserId { get; set; }
        public int Password { get; set; }
        public String Name { get; set; }
        public String UserAccountType { get; set; }
    }
}