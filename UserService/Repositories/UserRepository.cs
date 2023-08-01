using UserService.Models;
using DataLayer;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.VisualBasic;
using UserService.DTOs;
using AutoMapper;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("Users");
        }

        public User createUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users.Find(u => true).ToList();
        }

        public User GetUserById(string id)
        {
            var objectId = new ObjectId(id);
            return _users.Find(u => u.Id == objectId).FirstOrDefault();
        }
    }
}
