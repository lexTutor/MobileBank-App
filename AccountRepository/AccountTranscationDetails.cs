using System;
using System.Collections.Generic;
using System.Text;

namespace AccountRepository
{
  public  class AccountTranscationDetails
    {
        private readonly IAccounts _account;
        public AccountTranscationDetails(IAccounts account)
        {
            _account = account;
            this.TransactionTime = DateTime.Now;

        }

        public decimal TransactionAmount { get; set; }
        public string AccountOwnerName { get { return _account.AccountOwnerName; } private set { AccountOwnerName = _account.AccountOwnerName; } }
        public int AccountNumber { get { return _account.AccountNumber; } private set { AccountNumber = _account.AccountNumber; } }
        public decimal AccountBalance { get; set; }
        public string AccountType { get { return _account.AccountType; } private set { AccountType = _account.AccountType; } }
        public string Note { get; set; }
        public DateTime TransactionTime { get; set; }

    }
}
