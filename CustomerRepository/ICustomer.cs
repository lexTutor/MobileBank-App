using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRepository
{
    public interface ICustomer
    {
        string FirstName { set; }

        string LastName { set; }


         string Fullname { get; set; }

        string Password { get; set; }

       string EmailAddress { get; set; }

         string UserId { get; }
    }
}
