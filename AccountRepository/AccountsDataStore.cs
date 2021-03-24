using System;
using System.Collections.Generic;
using System.Text;

namespace AccountRepository
{
   public class AccountsDataStore
    {
        private static List<IAccounts> AccountDataBase = new List<IAccounts>();

        private static List<AccountTranscationDetails> AccountTransactionDetails = new List<AccountTranscationDetails>();

        public static IAccounts FindAccount(int accountnumber)
        {
            var checker = AccountDataBase.Find(account => account.AccountNumber == accountnumber);
            return checker;
        }

        public static List<AccountTranscationDetails> FindTransactions(int accountnumber)
        {
            var checker = AccountTransactionDetails.FindAll(transactions => transactions.AccountNumber == accountnumber);
            return checker;
        }
        public static void SaveTransactionDetails(AccountTranscationDetails transactDetails)
        {
            AccountTransactionDetails.Add(transactDetails);
        }
        public static void SaveAccountDetails(IAccounts account)
        {
            AccountDataBase.Add(account);
        }
        public static void SaveAccount(IAccounts accounts)
        {
            AccountDataBase.Add(accounts);
        }
        public static IAccounts ExistChecker(int accountnumber)
        {
            IAccounts result = new nullCheck();
            IAccounts x = new SavingsAccount();
            if (AccountDataBase.Exists(account => accountnumber == account.AccountNumber))
            {
                result = FindAccount(accountnumber);
            }
            return result;
        }
    }
}
