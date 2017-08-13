using Frankfurt.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frankfurt.DataAccess.Repository
{
    public interface IAccountRepository
    {
        Task<Account> GetAccount(int id);

        IEnumerable<Account> GetAccounts(int userId);

        Task AddAccount(Account account);

        void RemoveAccount(Account account);
    }
}