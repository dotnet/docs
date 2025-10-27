using System;

namespace ca1725
{
    //<snippet1>
    public interface IUserService
    {
        int GetAge(int id);
    }

    public class UserService : IUserService
    {
        // Violates CA1725: Parameter name should match the base declaration ('id')
        // for consistency with IUserService
        public int GetAge(int userId)
        {
            throw new NotImplementedException();
        }
    }
    //</snippet1>
}
