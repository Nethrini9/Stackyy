using MongoDB.Driver;
using Stackyy.Entities;
using ZstdSharp.Unsafe;

namespace Stackyy.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<Roles> _rolesCollection;
        private readonly IMongoCollection<Users> _usersCollection;
        public UserRepository(DataBaseService service)
        {
            _rolesCollection = service.GetCollection<Roles>("Roles");
            _usersCollection = service.GetCollection<Users>("Users");
        }
        public IEnumerable<Roles> GetRoles()
        {
            return _rolesCollection.Find(x => true).ToList();
        }

        public Roles GetRoleById(string id)
        {
            return _rolesCollection.Find(x => x.RoleId == id).FirstOrDefault();
        }
        public Roles AddRole(string roleType)
        {
            var role = new Roles { RoleType = roleType };
            _rolesCollection.InsertOne(role);
            return role;
        }
        public Roles UpdateRole(string id, Roles updaterole)
        {
            updaterole.RoleId = id;
            _rolesCollection.ReplaceOne(x => x.RoleId == id, updaterole);
            return updaterole;
        }
        public bool DeleteRoleById(string id)
        {
            var result = _rolesCollection.DeleteOne(x => x.RoleId == id);
            return result.DeletedCount > 0;
        }
        public IEnumerable<Users> GetUsers()
        {
            return _usersCollection.Find(x => true).ToList();
        }
        public Users GetUserById(string id)
        {
            return _usersCollection.Find(x => x.UserId == id).FirstOrDefault();
        }
        public Users AddUser(Users user)
        {
            var users = new Users { RoleId = user.RoleId, Name = user.Name, Email = user.Email, Password = user.Password, JoiningDate = user.JoiningDate, LastSeen = user.LastSeen, Location = user.Location, UserProfile = user.UserProfile };
            _usersCollection.InsertOne(users);
            return users;
        }
        public Users UpdateUser(string id, Users updateuser)
        {
            updateuser.UserId = id;
            _usersCollection.ReplaceOne(x => x.UserId == id, updateuser);
            return updateuser;
        }
        public bool DeleteUserById(string id)
        {
            var result = _usersCollection.DeleteOne(x => x.UserId == id);
            return result.DeletedCount > 0;
        }
        public string Signin(Users user)
        {
            var userdetails = _usersCollection.Find(x => x.Email!.ToLower() == user.Email!.ToLower()).FirstOrDefault();
            if(userdetails!=null)
            {
                if(userdetails.Password==user.Password)
                {
                    return "Logged in successfully";
                }
                else
                {
                    return "Logged in failed";
                }
            }
            else
            {
                return "No user exist";
            }
        }
    }
}