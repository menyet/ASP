using System;
using System.Collections.Generic;

namespace Frankfurt.Model
{
    public class Account
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }

    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }

        public Account TargetAccount { get; set; }

        public int TargetAccountId { get; set; }

        public Account SourceAccount { get; set; }

        public int SourceAccountId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Time { get; set; }
    }
}
