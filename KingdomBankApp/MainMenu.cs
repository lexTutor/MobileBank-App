using Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingdomBankApp.UI
{
   public class MainMenu
    {
        public static void Mainmenu()
        {

            var exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.WriteLine("Hello");
                Console.WriteLine("Welcome to the Kingdom Mobile Bank App");
                Console.WriteLine("Designed by AKPAKA CHIBUIKEM ROWLAND");
                Console.WriteLine(@"Please Enter:
                        'L' to log-in 
                        'R' to register
                        'E' to exit the app");

                var UserChoice = Helper1.Reader();
                if (UserChoice.ToUpper() == "L")
                {
                    //Redirects to Log-in User Interface
                    Console.Clear();
                    Log_inUserInterface.CustomerLogger();
                }

                else if (UserChoice.ToUpper() == "R")
                {
                    //Redirects to registeration User Interface
                    RegisterationUserInterface.RegisterCustomer();
                }
                else if (UserChoice.ToUpper() == "E")
                {
                    //Exits Application
                    Console.WriteLine("bye");
                    exit = true;

                }


            }
        }
    }
}
