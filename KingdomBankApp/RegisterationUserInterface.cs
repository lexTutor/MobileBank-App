using System;
using AccountRepository;
using CustomerRepository;
using Commons;
using Validations;

namespace KingdomBankApp.UI
{
    class RegisterationUserInterface
    {
        public static void RegisterCustomer()
        {
            var _customerInstance = ClassNewers.CustomerCreator();

            bool active = false;

            while (!active)
            {
                Helper1.Logger("Enter your email Address");
                _customerInstance.EmailAddress = Validate.ValidateMail();

                Helper1.Logger("Enter your FirstName");
                _customerInstance.FirstName = Validate.ValidateName();

                Helper1.Logger("Enter your LastName");
                _customerInstance.LastName = Helper1.Reader();

                Helper1.Logger("Enter your Password"); ;
                _customerInstance.Password = Validate.ValidatePassword();

                CustomerDataStore.SaveCustomer(_customerInstance);
                RegisterAccountInitial(_customerInstance);
                active = true;

                Console.Clear();

                
            }
        }

        public static void RegisterAccountInitial(CustomerDetails customer)
        {
            bool active = false;
            while (!active)
            {
                Console.Clear();
                Helper1.Logger("Please follow the prompt to create a bank account and complete your registeration process");
                Helper1.Logger(@"Enter:
                    '1' to create a savings account
                    '2' to create a current account
                               ");
                var value = Helper1.Reader();

                switch (value)
                {
                    case "1":
                        var _savingsAccountInstance = ClassNewers.SavingsAccountCreator(customer);
                        AccountsDataStore.SaveAccount(_savingsAccountInstance);
                        Helper1.Logger($"Welcome you have successfully registerd a savings account.\n" +
                            $" Your Account number is {_savingsAccountInstance.AccountNumber}");
                        var _accountnumber = _savingsAccountInstance.AccountNumber;
                        var account = AccountsDataStore.ExistChecker(_accountnumber);
                        account.MakeInitialDeposit(customer, account);
                        Console.ReadKey();
                        active = true;
                        break;
                    case "2":
                        var _currentAccountInstance = ClassNewers.CurrentAccountCreator(customer);
                        AccountsDataStore.SaveAccount(_currentAccountInstance);
                        Helper1.Logger($"Welcome you have successfully registerd a current account.\n" +
                            $"Your Account number is {_currentAccountInstance.AccountNumber}");
                        var _accountnumber1 = _currentAccountInstance.AccountNumber;
                        var account1 = AccountsDataStore.ExistChecker(_accountnumber1);
                        account1.MakeInitialDeposit(customer, account1);
                        Console.ReadKey();
                        active = true;
                        break;
                    default:
                        break;
                }

            }

        }
    }
}
