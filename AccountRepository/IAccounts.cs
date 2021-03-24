using System;
using CustomerRepository;

namespace AccountRepository
{
    public interface IAccounts
    {
        ICustomer AccountOwner { get; }
        string AccountOwnerName { get; }

        int AccountNumber { get; set; }

        DateTime DateCreated { get; set; }

        decimal AccountBalance { get; set; }

        string AccountId { get; }

        string AccountType { get; set; }

        string Note { get; set; }

        void DepositFunds(CustomerDetails customer, IAccounts accounts);

        void WithdrawFunds(CustomerDetails customer, IAccounts accounts);

        void MakeInitialDeposit(CustomerDetails customer, IAccounts accounts);

        void TransferFunds(CustomerDetails customer, IAccounts accounts);

        void GetStatement(CustomerDetails customer, IAccounts accounts);

        void GetBalance(CustomerDetails customer, IAccounts accounts);
    }
}
