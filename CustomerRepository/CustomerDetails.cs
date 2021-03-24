using System;

namespace CustomerRepository
{
    public class CustomerDetails: ICustomer
    {
        public CustomerDetails()
        {
            this.UserId = Guid.NewGuid().ToString().Substring(2, 13);
        }

        public string FirstName { private get; set; }

        public string LastName { private get; set; }


        public string Fullname
        {
            get
            {

                string fullname = FirstName + " " + LastName;
                return fullname;

            }

            set { }
        }

        public string Password { get; set; }

        public string EmailAddress { get; set; }

        public string UserId { get; private set; }

    }
}
