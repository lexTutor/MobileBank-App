using System;
using CustomerRepository;
using System.Text.RegularExpressions;

namespace Validations
{
    public class Validate
    {
        public static string ValidateMail()
        {
            try
            {
                var emailaddress = Console.ReadLine();
                var value =CustomerDataStore.EmailExists(emailaddress);


                if (Regex.IsMatch(emailaddress, @"^[^@\s\.]+@[^@\s]+\.[^@\s]+$") &&  value)
                {
                    return emailaddress;
                }
                else
                {
                    throw new FormatException("The mail you entered is invalid");
                }

            }

            catch (FormatException ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Please enter a valid email");
                return ValidateMail();

            }
        }

        /// <summary>
        /// Validates that the name does not contain numbers and begins with a capital letter
        /// </summary>
        /// <returns> userName </returns>
        public static string ValidateName()
        {
            try
            {
                var _firstname = Console.ReadLine();
                if (Regex.IsMatch(_firstname, @"^[A-Z][a-z]*$") == true)
                    return _firstname;
                else
                {
                    throw new FormatException("The name you entered is invalid");
                }

            }
            catch (FormatException)
            {

                Console.WriteLine("Please ensure that your name starts with a capital letter and not a number");
                return ValidateName();
            }

        }

        /// <summary>
        /// Validates that password is not an empty space
        /// </summary>
        /// <returns>password</returns>
        public static string ValidatePassword()
        {
            try
            {
                var password = Console.ReadLine();



                if (!string.IsNullOrWhiteSpace(password))
                {
                    return password;
                }
                else
                {
                    throw new FormatException("Your password cannot be an empty space");
                }

            }

            catch (FormatException ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("Please try using a better password");
                return ValidatePassword();

            }
        }
    }
}
