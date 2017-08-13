using Frankfurt.Model;

namespace Frankfurt.DataAccess.AuthProvider
{
    public interface IAuthProvider
    {
        User AuthenticatedUser { get; }
    }
}
