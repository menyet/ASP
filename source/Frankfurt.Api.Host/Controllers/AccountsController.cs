using Frankfurt.Api.Host.Model;
using Frankfurt.DataAccess;
using Frankfurt.DataAccess.AuthProvider;
using Frankfurt.DataAccess.Repository;
using Frankfurt.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Frankfurt.Api.Host.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthProvider _authProvider;
        private readonly IUnitOfWork _unitOfWork;

        public AccountsController(IUnitOfWork unitOfWork, IAccountRepository accountRepository, IAuthProvider authProvider)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _authProvider = authProvider ?? throw new ArgumentNullException(nameof(authProvider));
        }

        public Task<IActionResult> GetAccounts()
        {
            return Task.FromResult<IActionResult>(Ok(_accountRepository.GetAccounts(_authProvider.AuthenticatedUser.Id)));
        }

        [HttpGet("me")]
        public Task<IActionResult> GetCurrentAccount()
        {
            return Task.FromResult<IActionResult>(Ok(_authProvider.AuthenticatedUser));
        }

        [HttpPost]
        public Task<IActionResult> CreateAccount(NewAccountModel account)
        {
            _accountRepository.AddAccount(new Account
            {
                Title = account.Name,
                UserId = _authProvider.AuthenticatedUser.Id
            });

            _unitOfWork.SaveChanges();

            return Task.FromResult<IActionResult>(Ok());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAccount(int id)
        {
            var account = await _accountRepository.GetAccount(id);

            _accountRepository.RemoveAccount(account);

            _unitOfWork.SaveChanges();

            return Ok();
        }
    }
}
