﻿namespace MVC_Roles.Models
{
    public class Roles
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public List<User>? Users { get; set; }

    }
}
