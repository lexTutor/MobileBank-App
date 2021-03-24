using CustomerRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountRepository
{
   public class ClassNewers
    {
        public static CustomerDetails CustomerCreator()
        {
            return new CustomerDetails();
        }

        public static SavingsAccount SavingsAccountCreator(CustomerDetails customer)
        {
            return new SavingsAccount(customer);
        }

        public static CurrentAccount CurrentAccountCreator(CustomerDetails customer)
        {
            return new CurrentAccount(customer);
        }

        public static AccountTranscationDetails TransactionDetailsCreator(IAccounts account)
        {
            return new AccountTranscationDetails(account);
        }

    }
}
