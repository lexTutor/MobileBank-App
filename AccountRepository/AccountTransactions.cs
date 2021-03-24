using Commons;
using CustomerRepository;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AccountRepository
{
    class AccountTransactions
    {
        public static void Deposit(CustomerDetails customer, IAccounts account)
        {
            bool active = false;
            while (!active)
            {
                Helper1.Logger("Enter Account Number to Deposit funds to");
                try
                {
                    var _AccountNumber = account.AccountNumber;

                    Helper1.Logger("Enter amount to deposit");
                    var _amountToDeposit = Console.ReadLine();

                    var value = Convert.ToDecimal(_amountToDeposit);

                    if (value > 0)
                    {
                        if (account.AccountOwner == customer)
                        {

                            Helper1.Logger("Enter transaction description");
                            account.Note = Helper1.Reader();

                            account.AccountBalance += value;


                            var transactDetails = ClassNewers.TransactionDetailsCreator(account);
                            transactDetails.TransactionAmount = value;
                            transactDetails.AccountBalance = account.AccountBalance;
                            transactDetails.Note = account.Note;

                            AccountsDataStore.SaveTransactionDetails(transactDetails);

                            Helper1.Logger("Transaction Successful");
                            Helper1.Logger($"Your new account balance is #{account.AccountBalance}");

                            active = true;

                        }
                        else
                        {
                            Helper1.Logger("The details you entered were incorrect, make sure the account number you eneterd is yours");
                            Thread.Sleep(1500);
                            active = true;
                        }

                    }
                    else
                    {
                        Helper1.Logger("The amount must be a greater than zer0");
                        Thread.Sleep(1500);
                    }
                }
                catch (FormatException)
                {
                    Helper1.Logger("Account Number Must be a number");
                    Thread.Sleep(1500);
                    active = true;

                }
                catch (Exception)
                {
                    Helper1.Logger("No such account exists in our Database");
                    Thread.Sleep(1500);
                    active = true;
                }
            }
        }

        public static void GetBalance(CustomerDetails customer, IAccounts account)
        {
            bool active = false;

            while (!active)
            {

                Helper1.Logger("Enter Account Number to get balance from");

                try
                {
                    var _AccountNumber = account.AccountNumber;;

                    if (account.AccountOwner == customer)
                    {
                        Helper1.Logger("Please Enter your passord for additional security");
                        var authpassword = Console.ReadLine();

                        if (authpassword == customer.Password)
                        {
                            if (account.AccountBalance >= 1010.23m)
                            {
                                var value = 10.23m;

                                account.Note = "Get Balance";

                                account.AccountBalance -= value;

                                var transactDetails = ClassNewers.TransactionDetailsCreator(account);
                                transactDetails.TransactionAmount = value;
                                transactDetails.AccountBalance = account.AccountBalance;
                                transactDetails.Note = account.Note;

                                AccountsDataStore.SaveTransactionDetails(transactDetails);

                                Helper1.Logger("Transaction Successful");
                                Helper1.Logger($" Your Account Balance for {account.AccountNumber} is {account.AccountBalance} as at {DateTime.Now}");

                                active = true;
                            }
                            else
                            {
                                Helper1.Logger("Your Account is insufficient please make a deposit and try again. Thank you");
                                Thread.Sleep(1500);
                                active = true;
                            }
                        }
                        else
                        {
                            Helper1.Logger("Your password is incorrect");
                            Thread.Sleep(1500);
                            active = true;
                        }

                    }
                    else
                    {
                        Helper1.Logger("The details you entered were incorrect, ensure the account number you eneterd is yours");
                        Thread.Sleep(1500);
                        active = true;
                    }

                }
                catch (FormatException)
                {
                    Helper1.Logger("Account number must be a number");
                    Thread.Sleep(1500);
                    active = true;

                }
                catch (Exception)
                {
                    Helper1.Logger("No such account exists in our Database");
                    Thread.Sleep(1500);
                    active = true;
                }
            }

        }

        public static void GetStatement(CustomerDetails customer, IAccounts account)
        {
            bool active = false;
            while (!active)
            {
                try
                {
                    var _AccountNumber = account.AccountNumber;

                    if (account.AccountOwner == customer)
                    {
                        Helper1.Logger("Please Enter your passord for additional security");
                        var authpassword = Console.ReadLine();

                        if (authpassword == customer.Password)
                        {
                            if (account.AccountBalance >= 1019.4m)
                            {
                                var value = 19.14m;
                                account.AccountBalance -= value;

                                account.Note = "Get statement of Account";


                                var transactDetails = ClassNewers.TransactionDetailsCreator(account);

                                transactDetails.TransactionAmount = value;
                                transactDetails.AccountBalance = account.AccountBalance;
                                transactDetails.Note = account.Note;

                                AccountsDataStore.SaveTransactionDetails(transactDetails);

                                var _statement = AccountsDataStore.FindTransactions(_AccountNumber);
                                foreach (var transaction in _statement)
                                {
                                    Console.WriteLine("{0}  ||   {1}  ||  {2}  ||   {3}  ||  {4}  ||  {5}  ||   {6}",
                               transaction.AccountOwnerName, transaction.AccountNumber,
                               transaction.AccountType,
                                transaction.TransactionAmount, transaction.AccountBalance,
                               transaction.Note, transaction.TransactionTime);

                                }

                                Helper1.Logger("Transaction Successful");

                                active = true;
                            }
                            else
                            {
                                Helper1.Logger("Your account balance is insufficient, please credit your account and try again. Thank you.");
                                Thread.Sleep(1500);
                                active = true;
                            }
                        }
                        else
                        {
                            Helper1.Logger("Your password is incorrect");
                            Thread.Sleep(1500);
                            active = true;
                        }

                    }
                    else
                    {
                        Helper1.Logger("The details you entered were incorrect, ensure the account number you eneterd is yours");
                        Thread.Sleep(1500);
                        active = true;
                    }

                }
                catch (FormatException)
                {
                    Helper1.Logger("Account number must be a number");
                    Thread.Sleep(1500);
                    active = true;

                }
                catch (Exception)
                {
                    Helper1.Logger("No such account exists in our Database");
                    Thread.Sleep(1500);
                    active = true;
                }

            }
        }
        public static void InitialDeposit(CustomerDetails customer, decimal defaultValue, IAccounts account)
        {
            try
            {
                var _AccountNumber = account.AccountNumber;

                Helper1.Logger("Enter amount to deposit");
                var _amountToDeposit = Console.ReadLine();

                var value = Convert.ToDecimal(_amountToDeposit);

                if (value > defaultValue)
                {
                    if (account.AccountOwner == customer )
                    {

                        Helper1.Logger("Enter transaction description");
                        account.Note = Helper1.Reader();

                        account.AccountBalance += value;


                        var transactDetails =ClassNewers.TransactionDetailsCreator(account);
                        transactDetails.TransactionAmount = value;
                        transactDetails.AccountBalance = account.AccountBalance;
                        transactDetails.Note = account.Note;

                        AccountsDataStore.SaveTransactionDetails(transactDetails);

                        Helper1.Logger("Transaction Successful");
                        Helper1.Logger($"Your new account balance is #{account.AccountBalance}");

                    }
                    else
                    {
                        Helper1.Logger("The details you entered were incorrect, make sure the account number you eneterd is yours");
                        InitialDeposit(customer, defaultValue, account);
                    }

                }
                else
                {
                    Helper1.Logger($"The amount must be at least eqaul to {defaultValue}");
                    InitialDeposit(customer, defaultValue, account);
                }
            }
            catch (FormatException)
            {
                Helper1.Logger("Account Number Must be a number");
                InitialDeposit(customer, defaultValue, account);

            }
            catch (Exception)
            {
                Helper1.Logger("No such account exists in our Database");
                InitialDeposit(customer, defaultValue, account);
            }
        }
        public static void Transfer(CustomerDetails customer, int defaultAmount, IAccounts accounts)
        {
            bool active = false;
            while (!active)
            {
                Helper1.Logger("Enter Account Number to transfer funds to");
                var _accountToTransferTo = Helper1.Reader();


                try
                {
                    var beneficiary = Convert.ToInt32(_accountToTransferTo);
                    var useraccount = accounts.AccountNumber;

                    var checker1 = AccountsDataStore.FindAccount(beneficiary);

                    if (accounts.AccountOwner == customer)
                    {
                        Helper1.Logger("Enter amount to transfer");
                        var _amountToTransfer = Helper1.Reader();

                        var value = Convert.ToDecimal(_amountToTransfer);
                        if (value >= 0)
                        {
                            if (value < accounts.AccountBalance && accounts.AccountBalance > defaultAmount)
                            {
                                Helper1.Logger("Please enter your password for additional security");
                                var authpassword = Helper1.Reader();

                                if (authpassword == customer.Password)
                                {
                                    Helper1.Logger("Enter transaction description");
                                    accounts.Note = Helper1.Reader();

                                    accounts.AccountBalance -= value;
                                    checker1.AccountBalance += value;

                                    var transactDetails = ClassNewers.TransactionDetailsCreator(accounts);
                                    transactDetails.TransactionAmount = value;
                                    transactDetails.AccountBalance = checker1.AccountBalance;
                                    transactDetails.Note = checker1.Note;
                                    AccountsDataStore.SaveTransactionDetails(transactDetails);

                                    var transactDetails1 = ClassNewers.TransactionDetailsCreator(checker1);
                                    transactDetails.TransactionAmount = value;
                                    transactDetails.AccountBalance = checker1.AccountBalance;
                                    transactDetails.Note = checker1.Note;
                                    AccountsDataStore.SaveTransactionDetails(transactDetails);


                                    Helper1.Logger("Transaction Successful");
                                    Helper1.Logger($"Your new account balance is #{accounts.AccountBalance}");

                                    active = true;
                                }
                                else
                                {
                                    Helper1.Logger("Password is incorrect");
                                    Thread.Sleep(2000);
                                    active = true;
                                }
                            }
                            else
                            {
                                Helper1.Logger("Your account balance is insufficient");
                                Thread.Sleep(1500);
                                active = true;
                            }
                        }
                        else
                        {
                            Helper1.Logger("Amount must be a positive number");
                        }

                    }
                    else
                    {
                        Helper1.Logger("The details you entered were incorrect, ensure the account number you eneterd is yours");
                        Thread.Sleep(1500);
                        active = true;
                    }


                }
                catch (FormatException)
                {
                    Helper1.Logger("Account number must be a number");
                    Thread.Sleep(1500);
                    active = true;

                }
                catch (Exception)
                {
                    Helper1.Logger("No such account exists in our Database");
                    Thread.Sleep(1500);
                    active = true;
                }
            }
        }

        public static void Withdraw(CustomerDetails customer, int defaultAmount, IAccounts account)
        {
            bool active = false;
            while (!active)
            {
                try
                {
                    var _AccountNumber = account.AccountNumber;

                    if (account.AccountOwner == customer )
                    {
                        Helper1.Logger("Enter amount to withdraw");
                        var _amountToTransfer = Helper1.Reader();


                        var value = Convert.ToDecimal(_amountToTransfer);
                        if (value > 0)
                        {
                            if (value < account.AccountBalance && account.AccountBalance > defaultAmount)
                            {
                                Helper1.Logger("Please enter your password for additional security");
                                var authpassword = Console.ReadLine();


                                if (authpassword == customer.Password)
                                {
                                    Helper1.Logger("Enter transaction description");
                                    account.Note = Helper1.Reader();

                                    account.AccountBalance -= value;


                                    var transactDetails = ClassNewers.TransactionDetailsCreator(account);
                                    transactDetails.TransactionAmount = value;
                                    transactDetails.AccountBalance = account.AccountBalance;
                                    transactDetails.Note = account.Note;

                                    AccountsDataStore.SaveTransactionDetails(transactDetails);

                                    Helper1.Logger("Transaction Successful");
                                    Helper1.Logger($"Your new account balance is #{account.AccountBalance}");

                                    active = true;
                                }
                                else
                                {
                                    Helper1.Logger("Passowrd is Incorrect");
                                    Thread.Sleep(1500);
                                    active = true;
                                }
                            }
                            else
                            {
                                Helper1.Logger("Your account balance is insufficient");
                                Thread.Sleep(1500);
                                active = true;
                            }
                        }
                        else
                        {
                            Helper1.Logger("Amount must be a positive Integer");
                            Thread.Sleep(1500);
                        }

                    }
                    else
                    {
                        Helper1.Logger("The details you entered were incorrect, make sure the account number you eneterd is yours");
                        Thread.Sleep(1500);
                        active = true;
                    }

                ;
                }
                catch (FormatException)
                {
                    Helper1.Logger("Account Number must be a number");
                    Thread.Sleep(1500);
                    active = true;

                }
                catch (Exception)
                {
                    Helper1.Logger("No such account exists in our Database");
                    Thread.Sleep(1500);
                    active = true;
                }
            }
        }
    }
}
