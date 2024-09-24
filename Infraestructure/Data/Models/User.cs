using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime LastLogin { get; set; }
        public string Bio { get; set; }

        public ICollection<string> Followers { get; set; }
        public ICollection<string> Following { get; set; }
        public ICollection<string> Posts { get; set; }

        public User()
        {
            CreateAt = DateTime.Now;
            Followers = new List<string>();
            Following = new List<string>();
            Posts = new List<string>();
        }
    }
}
