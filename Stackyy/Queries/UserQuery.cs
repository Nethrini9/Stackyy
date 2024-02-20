using Stackyy.Entities;
using Stackyy.Repositories;
using ZstdSharp.Unsafe;

namespace Stackyy.Queries
{
    [ExtendObjectType("Query")]
    public class UserQuery
    {
        private readonly UserRepository _repository;
        public UserQuery(UserRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Roles> GetRoles()
        {
            return _repository.GetRoles();
        }
        public Roles GetRoleById(string id)
        {
            return _repository.GetRoleById(id);
        }
        public IEnumerable<Users> GetUsers()
        {
            return _repository.GetUsers();
        }
        public Users GetUserById(string id)
        {
            return _repository.GetUserById(id);
        }
    }
}
