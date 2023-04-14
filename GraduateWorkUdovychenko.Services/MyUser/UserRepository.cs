using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWorkUdovychenko.Domain.Models;
using GraduateWorkUdovychenko.Domain.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;


namespace GraduateWorkUdovychenko.Services.MyUser
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository()
        {
            var client = new MongoClient("mongodb://root:example@132.226.192.36:27017");
            var database = client.GetDatabase("GraduateUsers");
            _collection = database.GetCollection<User>("user");
        }

        public User Correct(AuthViewModel user)
        {
            try
            {
                var MyUser = GetByEmail(user.Email);
                if (MyUser != null && user.Password == MyUser.Password)
                {
                    return MyUser;
                }
                return null;

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool Create(User entity)
        {
            _collection.InsertOne(entity);
            return true;
        }

        public bool Delete(User Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string mail)
        {

            var user = _collection.Find(new BsonDocument("_id", mail)).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
