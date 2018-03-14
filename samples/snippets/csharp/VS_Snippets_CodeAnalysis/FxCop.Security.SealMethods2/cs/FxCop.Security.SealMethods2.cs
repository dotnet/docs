//<Snippet1>
using System;

namespace SecurityLibrary
{
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
}
//</Snippet1>
