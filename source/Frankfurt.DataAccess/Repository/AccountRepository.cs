using System;
using System.Threading.Tasks;
using Frankfurt.Model;
using System.Collections.Generic;
using System.Linq;

namespace Frankfurt.DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DatabaseContext _context;

        public AccountRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Account> GetAccount(int id)
        {
            return _context.Accounts.FindAsync(id);
        }

        public async Task AddAccount(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }

        public IEnumerable<Account> GetAccounts(int userId)
        {
            return _context.Accounts.Where(a => a.UserId == userId);
        }

        public void RemoveAccount(Account account)
        {
            _context.Accounts.Remove(account);
        }
    }
}
