using CustomerRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountRepository
{
   public class SavingsAccount: IAccounts
    {
        private ICustomer _accountowner;
        public SavingsAccount()
        {

        }
        public SavingsAccount(ICustomer AccountOwner)
        {
            _accountowner = AccountOwner;
            Random _accountnumber = new Random();
            this.AccountNumber = _accountnumber.Next(1002034504, int.MaxValue);
            this.DateCreated = DateTime.Now;
            this.AccountType = AccountEnums.AccountType.Savings.ToString();

        }


        public ICustomer AccountOwner
        {
            get { return _accountowner; }
            private set { AccountOwner = _accountowner; }
        }
        public string AccountOwnerName { get { return _accountowner.Fullname; } private set { AccountOwnerName = _accountowner.Fullname; } }
        public int AccountNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal AccountBalance { get; set; }
        public string AccountId { get { return AccountId; } private set { AccountOwnerName = _accountowner.UserId; } }
        public string AccountType { get; set; }
        public string Note { get; set; }

        public void DepositFunds(CustomerDetails customer, IAccounts account)
        {
            AccountTransactions.Deposit(customer, account);
        }

        public void GetBalance(CustomerDetails customer, IAccounts account)
        {
            AccountTransactions.GetBalance(customer, account);
        }

        public void GetStatement(CustomerDetails customer, IAccounts account)
        {
            AccountTransactions.GetStatement(customer, account);
        }

        public void MakeInitialDeposit(CustomerDetails customer,  IAccounts account)
        {
            AccountTransactions.InitialDeposit(customer, 100, account);
        }

        public void TransferFunds(CustomerDetails customer, IAccounts account)
        {
            AccountTransactions.Transfer(customer, 1000, account);
        }

        public void WithdrawFunds(CustomerDetails customer, IAccounts account)
        {
            AccountTransactions.Withdraw(customer, 1000, account);
        }
    }
}
