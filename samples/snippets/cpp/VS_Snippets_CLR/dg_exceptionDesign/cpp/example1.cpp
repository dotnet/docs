#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Runtime::Serialization;
using namespace System::Collections::Generic;

namespace Examples { namespace DesignGuidelines { namespace Exceptions
{
//<Snippet1>
    public ref class BadExceptionHandlingExample1
    {
    public:
        void DoWork()
        {
            // Do some work that might throw exceptions.
        }
        
        void MethodWithBadHandler()
        {
            try
            {
                DoWork();
            }
            catch (Exception^ e)
            {
                // Handle the exception and
                // continue executing.
            }
        }
    };
//</Snippet1>

//<Snippet2>
    public ref class BadExceptionHandlingExample2
    {
    public:
        void DoWork()
        {
            // Do some work that might throw exceptions.
        }
        
        void MethodWithBadHandler()
        {
            try
            {
                DoWork();
            }
            catch (Exception^ e)
            {
                if (e->GetType() == StackOverflowException::typeid ||
                    e->GetType() == OutOfMemoryException::typeid)
                    throw;
                // Handle the exception and
                // continue executing.
            }
        }
    };
//</Snippet2>


    public ref class ThrowExample1
    {
        //<Snippet3>
    public:

        void DoWork(Object^ anObject)
        {
            // Do some work that might throw exceptions.
            //<Snippet7>
            if (anObject == nullptr)
            {
                throw gcnew ArgumentNullException("anObject",
                    "Specify a non-null argument.");
            }
            //</Snippet7>
            // Do work with o.
        }
        //</Snippet3>
        
        //<Snippet4>
        void MethodWithBadCatch(Object^ anObject)
        {
            try
            {
                DoWork(anObject);
            }
            catch (ArgumentNullException^ e)
            {
               System::Diagnostics::Debug::Write(e->Message);
               // This is wrong.
               throw e;
               // Should be this:
               // throw;
            }
        }
        //</Snippet4>

        //<Snippet5>
        void MethodWithBetterCatch()
        {
            try
            {
                DoWork(nullptr);
            }
            catch (ArgumentNullException^ e)
            {
               System::Diagnostics::Debug::Write(e->Message);
               throw;
            }
        }
        //</Snippet5>
    };

    public ref class CommunicationFailureException : Exception
    {
    public:
        CommunicationFailureException(String^ message) : Exception(message)
        {
        }

        CommunicationFailureException(String^ message, Exception^ innerException)
            : Exception(message)
        {
        }
    };

    public ref class Wrapper
    {
    private:
        IPAddress^ address;

    public:
        Wrapper()
        {
            address = IPAddress::Loopback;
        }

        void EstablishConnection(){}

        //<Snippet6>
        void SendMessages()
        {
            try
            {
                EstablishConnection();
            }
            catch (System::Net::Sockets::SocketException^ e)
            {
            throw gcnew CommunicationFailureException(
                "Cannot access remote computer.",
                e);
            }
        }
        //</Snippet6>

        //<Snippet8>
        property IPAddress^ Address
        {
            IPAddress^ get()
            {
                return address;
            }
            void set(IPAddress^ value)
            {
                if (value == nullptr)
                {
                    throw gcnew ArgumentNullException("value");
                }
                address = value;
            }
        }
        //</Snippet8>
    };

    public ref class BaseException : Exception{};

    //<Snippet9>
    public ref class NewException : BaseException, ISerializable
    {
    public:
        NewException()
        {
            // Add implementation.
        }

        NewException(String^ message)
        {
            // Add implementation.
        }

        NewException(String^ message, Exception^ inner)
        {
            // Add implementation.
        }

    protected:
        // This constructor is needed for serialization.
        NewException(SerializationInfo info, StreamingContext context)
        {
            // Add implementation.
        }
    };
    //</Snippet9>

    //<snippet13>
    //<Snippet10>
    public ref class Doer
    {
    public:
        // Method that can potential throw exceptions often.
        static void ProcessMessage(String^ message)
        {
            if (message == nullptr)
            {
                throw gcnew ArgumentNullException("message");
           }
        }
        // Other methods...
    };
    //</Snippet10>

    //<Snippet11>
    public ref class Tester
    {
    public:
        static void TesterDoer(ICollection<String^>^ messages)
        {
            for each (String^ message in messages)
            {
                // Test to ensure that the call
                // won't cause the exception.
                if (message != nullptr)
                {
                    Doer::ProcessMessage(message);
                }
            }
        }
    };
    //</Snippet11>
    //</snippet13>

    public ref class BadParser
    {
        //<Snippet12>
        Uri^ ParseUri(String^ uriValue, bool throwOnError)
        //</Snippet12>
        {return gcnew Uri("http://contoso.com");}
    };

    public ref class TestMain
    {
    public:
        static void Main()
        {
            ThrowExample1^ t = gcnew ThrowExample1();
            // t.MethodWithBadCatch();
            // t.MethodWithBetterCatch();
        }
    };
}}}

int main()
{
    Examples::DesignGuidelines::Exceptions::TestMain::Main();
}
