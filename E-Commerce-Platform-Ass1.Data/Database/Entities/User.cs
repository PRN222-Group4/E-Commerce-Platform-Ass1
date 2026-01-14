using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Platform_Ass1.Data.Database.Entities
{
    public class User
    {
        public Guid id { get; set; }

        public string name { get; set; } = string.Empty;

        public string password_hash { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public Guid role_id { get; set; }

        public bool status { get; set; }

        public DateTime create_at { get; set; }

        // Navigation property
        public Role Role { get; set; } = null!;
    }
}
