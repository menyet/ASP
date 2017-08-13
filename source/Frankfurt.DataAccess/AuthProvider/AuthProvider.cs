using Frankfurt.DataAccess.Repository;
using Frankfurt.Model;

namespace Frankfurt.DataAccess.AuthProvider
{
    public class AuthProvider : IAuthProvider
    {
        private IUserRepository _userRepository;

        public User AuthenticatedUser => _userRepository.GetUser(1);

        public AuthProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
