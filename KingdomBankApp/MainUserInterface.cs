using CustomerRepository;
using System;
using AccountRepository;
using Commons;
using System.Threading;

namespace KingdomBankApp.UI
{
    class MainUserInterface
    {
        public static void ActivityPage(CustomerDetails customer)
        {
            Console.Clear();
            bool active = false;

            while (!active)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("->> Welcome to the Kingdom School Admin Home page; we hope you have a wonderful experience");

                    Console.WriteLine("Please follow the prompt to update your details");
                    Console.WriteLine(@"Enter:
                    '1' to Deopsit funds
                    '2' to Withdraw funds
                    '3' to transfer funds
                    '4' to Get your account balance
                    '5' to get your statement of account
                    '6' to create a new savings account
                    '7' to create a new current account
                    '0' to Log out");
                    var value = Console.ReadLine();
                    switch (value)
                    {
                        case "1":
                            Helper1.Logger("Enter The account number to deposiit funds into");
                            var value1 = Convert.ToInt32(Helper1.Reader());
                            var _accountnumber1 = value1;
                            var account1 = AccountsDataStore.ExistChecker(_accountnumber1);
                            account1.DepositFunds(customer, account1);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "2":
                            Helper1.Logger("Enter your account number");
                            var value2 = Convert.ToInt32(Helper1.Reader());
                            var _accountnumber2 = value2;
                            var account2 = AccountsDataStore.ExistChecker(_accountnumber2);
                            account2.WithdrawFunds(customer, account2);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "3":
                            Helper1.Logger("Enter your account number");
                            var value3 = Convert.ToInt32(Helper1.Reader());
                            var _accountnumber3 = value3;
                            var account3 = AccountsDataStore.ExistChecker(_accountnumber3);
                            account3.TransferFunds(customer, account3);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "4":
                            Helper1.Logger("Enter The account number to get balance from");
                            var value4 = Convert.ToInt32(Helper1.Reader());
                            var _accountnumber4 = value4;
                            var account4 = AccountsDataStore.ExistChecker(_accountnumber4);
                            account4.GetBalance(customer, account4);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "5":
                            Helper1.Logger("Enter The account number to get statemnt from");
                            var value5 = Convert.ToInt32(Helper1.Reader());
                            var _accountnumber5 = value5;
                            var account5 = AccountsDataStore.ExistChecker(_accountnumber5);
                            account5.GetStatement(customer, account5);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "6":
                            var _savingsAccountInstance = ClassNewers.SavingsAccountCreator(customer);
                            AccountsDataStore.SaveAccount(_savingsAccountInstance);
                            Helper1.Logger($"Welcome you have successfully registerd your Account number is {_savingsAccountInstance.AccountNumber}");
                            var _accountnumber = _savingsAccountInstance.AccountNumber;
                            var account = AccountsDataStore.ExistChecker(_accountnumber);
                            account.MakeInitialDeposit(customer, account);
                            Console.ReadKey();
                            Console.ReadLine();
                            break;
                        case "7":
                            var _currentAccountInstance = ClassNewers.CurrentAccountCreator(customer);
                            AccountsDataStore.SaveAccount(_currentAccountInstance);
                            Helper1.Logger($"Welcome you have successfully registerd your Account number is {_currentAccountInstance.AccountNumber}");
                            var _accountnumber7 = _currentAccountInstance.AccountNumber;
                            var account7 = AccountsDataStore.ExistChecker(_accountnumber7);
                            account7.MakeInitialDeposit(customer, account7);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "0":
                            active = true;
                            Console.WriteLine("Thank YOU FOR VISITING");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            break;

                    }
                }
                catch (FormatException)
                {
                    Helper1.Logger("Account must be a number");
                    Thread.Sleep(1500);
                }
                catch(Exception)
                {
                    Helper1.Logger("There was an Error in your input please try again");
                    Thread.Sleep(1500);
                }
            }
        }
    }
}
