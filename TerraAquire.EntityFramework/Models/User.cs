using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TerraAcquire.EntityFramework.Models

{
    public class User
    {
        public Guid? Id { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImage { get; set; }
        public string? FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public bool? IsActive { get; set; }
        public Role Role { get; set; }
    }
}

