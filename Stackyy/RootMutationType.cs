using Stackyy.Mutations;

namespace Stackyy
{
    public class RootMutationType : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Mutation");

            descriptor.Field<UserMutation>(m => m.DeleteUserById(default));
            descriptor.Field<QuestionsMutation>(m => m.DeleteAnswerById(default));
        }
    }
}
