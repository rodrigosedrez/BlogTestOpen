﻿namespace BlogTestOpen.Api.Models
{
    public class User
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image {  get; set; }
        public string Slug { get; set; }     // slug means - unique identifying part of a web address
        public string Bio { get; set; }

        public IList<Post> Posts { get; set; }
        public IList<Role> Roles { get; set; }
    }
}
