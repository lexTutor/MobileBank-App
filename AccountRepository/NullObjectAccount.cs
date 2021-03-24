using CustomerRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountRepository
{
    public class nullCheck: IAccounts
    {
        public ICustomer AccountOwner { get; }

        public string AccountOwnerName { get; }

        public int AccountNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal AccountBalance { get; set; }

        public string AccountId { get; }

        public string AccountType { get; set; }
        public string Note { get; set; }

        public void DepositFunds(CustomerDetails customer, IAccounts account)
        {
            Console.WriteLine("Entry does not exist");
        }

        public void GetBalance(CustomerDetails customer, IAccounts account)
        {
            Console.WriteLine("Entry does not exist");
        }

        public void GetStatement(CustomerDetails customer, IAccounts account)
        {
            Console.WriteLine("Entry does not exist");
        }

        public void MakeInitialDeposit(CustomerDetails customer, IAccounts account)
        {
            Console.WriteLine("Entry does not exist");
        }

        public void TransferFunds(CustomerDetails customer, IAccounts account)
        {
            Console.WriteLine("Entry does not exist");
        }

        public void WithdrawFunds(CustomerDetails customer,  IAccounts account)
        {
            Console.WriteLine("Entry does not exist");
        }
    }
}
