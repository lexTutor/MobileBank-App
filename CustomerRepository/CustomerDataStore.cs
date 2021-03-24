using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRepository
{
    public class CustomerDataStore
    {
        private static List<CustomerDetails> BankLedger = new List<CustomerDetails>();

        public static CustomerDetails FindCustomerByMail(string emailAddress)
        {
            var checker = BankLedger.Find(customer => customer.EmailAddress == emailAddress);
            return checker;
        }

        public static CustomerDetails FindCustomerByPassword(string password)
        {
            var checker = BankLedger.Find(customer => customer.Password == password);
            return checker;
        }
        public static void SaveCustomer(CustomerDetails customer)
        {
            BankLedger.Add(customer);
        }
        public static bool DataStoreCount()
        {
            bool result = false;
            if (BankLedger.Count >=1)
            {
                result = true;
            }

            return result;
        }
        public static bool EmailExists(string email)
        {
            bool result = true;
            if (BankLedger.Exists(customer => email ==customer.EmailAddress))
            {
                result = false;
            }
            return result;
        }
    }
}
