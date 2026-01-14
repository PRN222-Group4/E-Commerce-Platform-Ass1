using System;
using System.Collections.Generic;

namespace E_Commerce_Platform_Ass1.Data.Database.Entities
{
    public class Role
    {
        public Guid id { get; set; }

        public string name { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public DateTime create_at { get; set; }

        // Navigation property
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
