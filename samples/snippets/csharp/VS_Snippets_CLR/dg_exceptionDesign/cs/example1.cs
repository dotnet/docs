using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Examples.DesignGuidelines.Exceptions
{
//<Snippet1>
    public class BadExceptionHandlingExample1
    {
        public void DoWork()
        {
            // Do some work that might throw exceptions.
        }
        public void MethodWithBadHandler()
        {
            try
            {
                DoWork();
            }
            catch (Exception e)
            {
                // Handle the exception and
                // continue executing.
            }
        }
    }
//</Snippet1>

//<Snippet2>
    public class BadExceptionHandlingExample2
    {
        public void DoWork()
        {
            // Do some work that might throw exceptions.
        }
        public void MethodWithBadHandler()
        {
            try
            {
                DoWork();
            }
            catch (Exception e)
            {
                if (e is StackOverflowException ||
                    e is OutOfMemoryException)
                    throw;
                // Handle the exception and
                // continue executing.
            }
        }
    }
//</Snippet2>


public class ThrowExample1
{
    //<Snippet3>
        public void DoWork(Object anObject)
        {
            // Do some work that might throw exceptions.
            //<Snippet7>
            if (anObject == null)
            {
                throw new ArgumentNullException("anObject",
                    "Specify a non-null argument.");
            }
            //</Snippet7>
            // Do work with o.
        }
        //</Snippet3>
        //<Snippet4>
        public void MethodWithBadCatch(Object anObject)
        {
            try
            {
                DoWork(anObject);
            }
            catch (ArgumentNullException e)
            {
               System.Diagnostics.Debug.Write(e.Message);
               // This is wrong.
               throw e;
               // Should be this:
               // throw;
            }
        }
        //</Snippet4>
        //<Snippet5>
        public void MethodWithBetterCatch()
        {
            try
            {
                DoWork(null);
            }
            catch (ArgumentNullException e)
            {
               System.Diagnostics.Debug.Write(e.Message);
               throw;
            }
        }
        //</Snippet5>
}


public class Wrapper
{
    public void EstablishConnection(){}


    //<Snippet6>
    public void SendMessages()
    {
        try
        {
            EstablishConnection();
        }
        catch (System.Net.Sockets.SocketException e)
        {
            throw new CommunicationFailureException(
                "Cannot access remote computer.",
                e);
        }
    }
    //</Snippet6>

    IPAddress address = IPAddress.Loopback;
    //<Snippet8>
    public IPAddress Address
    {
        get
        {
            return address;
        }
        set
        {
            if(value == null)
            {
                throw new ArgumentNullException("value");
            }
            address = value;
        }
    }
    //</Snippet8>
}
public class CommunicationFailureException : Exception
{
    public CommunicationFailureException(string message) : base(message)
    {
    }
    public CommunicationFailureException(string message, Exception innerException)
        : base(message)
    {
    }
}

public class BaseException: Exception{}

//<Snippet9>
public class NewException : BaseException, ISerializable
{
    public NewException()
    {
        // Add implementation.
    }
    public NewException(string message)
    {
        // Add implementation.
    }
    public NewException(string message, Exception inner)
    {
        // Add implementation.
    }

    // This constructor is needed for serialization.
   protected NewException(SerializationInfo info, StreamingContext context)
   {
        // Add implementation.
   }
}
//</Snippet9>
//<snippet13>
//<Snippet10>
public class Doer
{
    // Method that can potential throw exceptions often.
    public static void ProcessMessage(string message)
    {
        if (message == null)
        {
            throw new ArgumentNullException("message");
        }
    }
    // Other methods...
}
//</Snippet10>

//<Snippet11>
public class Tester
{
    public static void TesterDoer(ICollection<string> messages)
    {
        foreach (string message in messages)
        {
            // Test to ensure that the call
            // won't cause the exception.
            if (message != null)
            {
                Doer.ProcessMessage(message);
            }
        }
    }
}
//</Snippet11>
//</snippet13>

public class BadParser
{
    //<Snippet12>
    Uri ParseUri(string uriValue, bool throwOnError)
    //</Snippet12>
    {return new Uri("http://contoso.com");}
}

public class TestMain
{
    public static void Main()
    {
        ThrowExample1 t = new ThrowExample1();
        // t.MethodWithBadCatch();
        // t.MethodWithBetterCatch();
    }
}

}
