using Stackyy.Entities;
using Stackyy.Repositories;

namespace Stackyy.Mutations
{
    [ExtendObjectType("Mutation")]
    public class UserMutation
    {
        private readonly UserRepository _repository;
        public UserMutation(UserRepository repository)
        {
            _repository = repository;
        }

        [GraphQLDescription("Add a new role")]
        public Roles AddRole(string RoleType)
        {
            return _repository.AddRole(RoleType);
        }
        [GraphQLDescription("Updating the role")]
        public Roles UpdateRole(string id, Roles updaterole)
        {
            return _repository.UpdateRole(id, updaterole);
        }
        [GraphQLDescription("Delete a role")]
        public bool DeleteRoleById(string id)
        {
            return _repository.DeleteRoleById(id);
        }

        [GraphQLDescription("Add a new user")]
        public Users AddUser(Users user)
        {
            return _repository.AddUser(user);
        }
        [GraphQLDescription("Updating the user")]
        public Users UpdateUser(string id, Users updateuser)
        {
            return _repository.UpdateUser(id, updateuser);
        }
        [GraphQLDescription("Delete a user")]
        public bool DeleteUserById(string id)
        {
            return _repository.DeleteUserById(id);
        }
    }
}
