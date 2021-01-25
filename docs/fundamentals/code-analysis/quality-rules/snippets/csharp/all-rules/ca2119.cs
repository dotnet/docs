using System;

namespace ca2119
{
    //<snippet1>
    // Internal by default.
    interface IValidate
    {
        bool UserIsValidated();
    }

    public class BaseImplementation : IValidate
    {
        public virtual bool UserIsValidated()
        {
            return false;
        }
    }

    public class UseBaseImplementation
    {
        public void SecurityDecision(BaseImplementation someImplementation)
        {
            if (someImplementation.UserIsValidated() == true)
            {
                Console.WriteLine("Account number & balance.");
            }
            else
            {
                Console.WriteLine("Please login.");
            }
        }
    }
    //</snippet1>
}

namespace ca2119_2
{
    //<snippet2>
    public class BaseImplementation
    {
        public virtual bool UserIsValidated()
        {
            return false;
        }
    }

    public class UseBaseImplementation
    {
        public void SecurityDecision(BaseImplementation someImplementation)
        {
            if (someImplementation.UserIsValidated() == true)
            {
                Console.WriteLine("Account number & balance.");
            }
            else
            {
                Console.WriteLine("Please login.");
            }
        }
    }
    //</snippet2>
}
