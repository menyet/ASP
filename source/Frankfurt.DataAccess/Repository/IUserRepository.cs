using Frankfurt.Model;

namespace Frankfurt.DataAccess.Repository
{
    public interface IUserRepository
    {
        User GetUser(int id);
    }
}
