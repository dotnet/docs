// This sample demonstrates how to use each member of the
// CryptographicUnexpectedOperationException class.
//<Snippet2>
using System;
using System.Security.Cryptography;
using System.Runtime.Serialization;

class Members
{
    [STAThread]
    static void Main(string[] args)
    {
        Members testRun = new Members();

        testRun.TestConstructors();
        testRun.ShowProperties();

        Console.WriteLine("Sample ended successfully, " +
            " press Enter to continue.");
        Console.ReadLine();
    }

    // Test each public implementation of the
    // CryptographicUnexpectedOperationException constructors.
    private void TestConstructors()
    {
        EmptyConstructor();
        StringConstructor();
        StringExceptionConstructor();
        StringStringConstructor();
    }

    private void EmptyConstructor()
    {
        // Construct a CryptographicUnexpectedOperationException
        // with no parameters.
        //<Snippet1>
        CryptographicUnexpectedOperationException cryptographicException =
            new CryptographicUnexpectedOperationException();
        //</Snippet1>
        Console.WriteLine("Created an empty " + 
            "CryptographicUnexpectedOperationException.");
    }

    private void StringConstructor()
    {
        // Construct a CryptographicUnexpectedOperationException
        // using a custom error message.
        //<Snippet3>
        string errorMessage = ("Unexpected operation exception.");
        CryptographicUnexpectedOperationException cryptographicException =
            new CryptographicUnexpectedOperationException(errorMessage);
        //</Snippet3>
        Console.WriteLine("Created a " + 
            "CryptographicUnexpectedOperationException with the following " +
            " error message: " + errorMessage);
    }

    private void StringExceptionConstructor()
    {
        // Construct a CryptographicUnexpectedOperationException using a 
        // custom error message and an inner exception.
        //<Snippet4>
        string errorMessage = ("The current operation is not supported.");
        NullReferenceException nullException = new NullReferenceException();
        CryptographicUnexpectedOperationException cryptographicException = 
            new CryptographicUnexpectedOperationException(
            errorMessage, nullException);
        //</Snippet4>
        Console.WriteLine("Created a " +
            "CryptographicUnexpectedOperationException with the following" +
            "error message: " + errorMessage + " and inner exception: "
            + nullException.ToString());
    }

    private void StringStringConstructor()
    {
        // Create a CryptographicUnexpectedOperationException using a time
        // format and the current date.
        //<Snippet5>
        string dateFormat = "{0:t}";
        string timeStamp = (DateTime.Now.ToString());
        CryptographicUnexpectedOperationException cryptographicException = 
            new CryptographicUnexpectedOperationException(
            dateFormat, timeStamp);
        //</Snippet5>
        Console.WriteLine("Created a " + 
            "CryptographicUnexpectedOperationException with (" + dateFormat +
            ") as the format and (" + timeStamp + ") as the message.");
    }

    // Construct an invalid DSACryptoServiceProvider to throw a
    // CryptographicUnexpectedOperationException for introspection.
    private void ShowProperties()
    {
        // Attempting to encode an OID greater than 127 bytes is not supported
        // and will throw an exception.
        string veryLongNumber = "1234567890.1234567890.";
        for (int i=0; i < 4; i++)
        {
            veryLongNumber += veryLongNumber;
        }
        veryLongNumber += "0";
        try 
        {
            byte[] tooLongOID = CryptoConfig.EncodeOID(veryLongNumber);
        }
        catch(CryptographicUnexpectedOperationException ex)
        {
            // Retrieve the link to the Help file for the exception.
            //<Snippet6>
            string helpLink = ex.HelpLink;
            //</Snippet6>            
            
            // Retrieve the exception that caused the current
            // CryptographicUnexpectedOperationException.
            //<Snippet7>            
            System.Exception innerException = ex.InnerException;
            //</Snippet7>
            string innerExceptionMessage = "";
            if (innerException != null)
            {
                innerExceptionMessage = innerException.ToString();
            }

            // Retrieve the message that describes the exception.
            //<Snippet8>
            string message = ex.Message;
            //</Snippet8>

            // Retrieve the name of the application that caused the exception.
            //<Snippet9>
            string exceptionSource = ex.Source;
            //</Snippet9>

            // Retrieve the call stack at the time the exception occurred.
            //<Snippet10>
            string stackTrace = ex.StackTrace;
            //</Snippet10>

            // Retrieve the method that threw the exception.
            //<Snippet11>
            System.Reflection.MethodBase targetSite = ex.TargetSite;
            //</Snippet11>
            string siteName = targetSite.Name;

            // Retrieve the entire exception as a single string.
            //<Snippet12>
            string entireException = ex.ToString();
            //</Snippet12>

            // GetObjectData
            setSerializationInfo(ref ex);

            // Get the root exception that caused the current
            // CryptographicUnexpectedOperationException.
            //<Snippet13>
            System.Exception baseException = ex.GetBaseException();
            //</Snippet13>
            string baseExceptionMessage = "";
            if (baseException != null)
            {
                baseExceptionMessage = baseException.Message;
            }

            Console.WriteLine("Caught an expected exception:");
            Console.WriteLine(entireException + "\n");

            Console.WriteLine("Properties of the exception are as follows:");
            Console.WriteLine("Message: " + message);
            Console.WriteLine("Source: " + exceptionSource);
            Console.WriteLine("Stack trace: " + stackTrace);
            Console.WriteLine("Help link: " + helpLink);
            Console.WriteLine("Target site's name: " + siteName);
            Console.WriteLine("Base exception message: " + 
                baseExceptionMessage);
            Console.WriteLine("Inner exception message: " + 
                innerExceptionMessage);
        }
    }

    private void setSerializationInfo(
        ref CryptographicUnexpectedOperationException ex)
    {
        // Insert information about the exception into a serialized object.
        //<Snippet14>
        FormatterConverter formatConverter = new FormatterConverter();
        SerializationInfo serializationInfo =
            new SerializationInfo(ex.GetType(), formatConverter);
        StreamingContext streamingContext =
            new StreamingContext(StreamingContextStates.All);

        ex.GetObjectData(serializationInfo,streamingContext);
        //</Snippet14>
    }
}
//
// This sample produces the following output:
//
// Created an empty CryptographicUnexpectedOperationException.
// Created a CryptographicUnexpectedOperationException with the following 
// error message: Unexpected operation exception.
// Created a CryptographicUnexpectedOperationException with the following
// error message: The current operation is not supported. and inner exception:
// System.NullReferenceException: Object reference not set to an instance of
// an object.
// Created a CryptographicUnexpectedOperationException with ({0:t}) as the
// format and (2/24/2004 2:35:22 PM) as the message.
// Caught an expected exception:
// System.Security.Cryptography.CryptographicUnexpectedOperationException: 
// Encoded OID length is too large (greater than 0x7f bytes).
//  at System.Security.Cryptography.CryptoConfig.EncodeOID(String str)
//  at Members.ShowProperties() in c:\consoleapplication1\class1.cs:line 106
// 
// Properties of the exception are as follows:
// Message: Encoded OID length is too large (greater than 0x7f bytes).
// Source: mscorlib
// Stack trace:    at System.Security.Cryptography.CryptoConfig.EncodeOID(
// String str)
//  at Members.ShowProperties() in c:\consoleapplication1\class1.cs:line 106
// Help link:
// Target site's name: EncodeOID
// Base exception message: Encoded OID length is too large (greater than 0x7f
// bytes).
// Inner exception message:
// Sample ended successfully,  press Enter to continue.
//</Snippet2>