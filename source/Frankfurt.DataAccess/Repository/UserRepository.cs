using Frankfurt.Model;

namespace Frankfurt.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
