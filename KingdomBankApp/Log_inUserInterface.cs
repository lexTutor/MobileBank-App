using System;
using AccountRepository;
using CustomerRepository;
using Commons;

namespace KingdomBankApp.UI
{
    class Log_inUserInterface
    {
        public static void CustomerLogger()
        {
            Console.Clear();
            bool active = false;
            while (!active)
            {
                //Checks that the Databse is not empty before allowing any user access to log-in.
                if (CustomerDataStore.DataStoreCount())
                {
                   CustomerDetails  foundUser = null;
                   Helper1.Logger("Please enter your log-in details");

                    Helper1.Logger("Please enter your registered email Address");
                    var Login_mail = Helper1.Reader();

                    Helper1.Logger("Please enter your password");
                    var Login_password = Helper1.Reader();

                    //Checks to see that the user attempting to log-in actually exists in the Database
                    var user1 = CustomerDataStore.FindCustomerByMail(Login_mail);
                    var user2 = CustomerDataStore.FindCustomerByPassword(Login_password);
                    if (user1 != null && user2 != null && user1 == user2)
                    {
                        Helper1.Logger("Welcome you are logged in");
                        Helper1.Reader();
                        foundUser = user1;

                        MainUserInterface.ActivityPage(foundUser);
                        active = true;

                    }
                    else
                    {
                        Console.WriteLine("Sorry, this user does not exist in our database");
                        Console.ReadKey();
                        active = true;
                    }
                }
                else
                {
                    Console.WriteLine("There are currently no users in the database. Rgister first");
                    Console.ReadKey();
                    active = true;
                }
               break;
            }
        }
    }
}
