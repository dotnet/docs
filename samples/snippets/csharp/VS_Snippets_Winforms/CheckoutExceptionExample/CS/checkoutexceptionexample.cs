using System;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{

    public class CheckoutExceptionExample
    {
        public CheckoutExceptionExample()
        {
            //<Snippet1>
            // Throws a checkout exception with a message and error code.
            throw new CheckoutException("This is an example exception", 0);
            //</Snippet1>
        }
    }
}
