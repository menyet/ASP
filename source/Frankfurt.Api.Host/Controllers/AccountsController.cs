using Frankfurt.DataAccess;
using Frankfurt.DataAccess.Repository;
using Frankfurt.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frankfurt.Api.Host.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;


        public AccountsController(IUnitOfWork unitOfWork, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<IActionResult> GetAccounts()
        {
            return Task.FromResult<IActionResult>(Ok(_accountRepository.GetAccounts()));
        }

        [HttpPost]
        public Task<IActionResult> CreateAccount()
        {
            _accountRepository.AddAccount(new Account
            {
                Title = "asdasd"
            }
                );

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
