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
        CryptographicUnexpectedOperationException cryptographicException =
            new CryptographicUnexpectedOperationException();
        Console.WriteLine("Created an empty " + 
            "CryptographicUnexpectedOperationException.");
    }

    private void StringConstructor()
    {
        // Construct a CryptographicUnexpectedOperationException
        // using a custom error message.
        string errorMessage = ("Unexpected operation exception.");
        CryptographicUnexpectedOperationException cryptographicException =
            new CryptographicUnexpectedOperationException(errorMessage);
        Console.WriteLine("Created a " + 
            "CryptographicUnexpectedOperationException with the following " +
            " error message: " + errorMessage);
    }

    private void StringExceptionConstructor()
    {
        // Construct a CryptographicUnexpectedOperationException using a 
        // custom error message and an inner exception.
        string errorMessage = ("The current operation is not supported.");
        NullReferenceException nullException = new NullReferenceException();
        CryptographicUnexpectedOperationException cryptographicException = 
            new CryptographicUnexpectedOperationException(
            errorMessage, nullException);
        Console.WriteLine("Created a " +
            "CryptographicUnexpectedOperationException with the following" +
            "error message: " + errorMessage + " and inner exception: "
            + nullException.ToString());
    }

    private void StringStringConstructor()
    {
        // Create a CryptographicUnexpectedOperationException using a time
        // format and the current date.
        string dateFormat = "{0:t}";
        string timeStamp = (DateTime.Now.ToString());
        CryptographicUnexpectedOperationException cryptographicException = 
            new CryptographicUnexpectedOperationException(
            dateFormat, timeStamp);
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
            string helpLink = ex.HelpLink;
            
            // Retrieve the exception that caused the current
            // CryptographicUnexpectedOperationException.
            System.Exception innerException = ex.InnerException;
            string innerExceptionMessage = "";
            if (innerException != null)
            {
                innerExceptionMessage = innerException.ToString();
            }

            // Retrieve the message that describes the exception.
            string message = ex.Message;

            // Retrieve the name of the application that caused the exception.
            string exceptionSource = ex.Source;

            // Retrieve the call stack at the time the exception occurred.
            string stackTrace = ex.StackTrace;

            // Retrieve the method that threw the exception.
            System.Reflection.MethodBase targetSite = ex.TargetSite;
            string siteName = targetSite.Name;

            // Retrieve the entire exception as a single string.
            string entireException = ex.ToString();

            // GetObjectData
            setSerializationInfo(ref ex);

            // Get the root exception that caused the current
            // CryptographicUnexpectedOperationException.
            System.Exception baseException = ex.GetBaseException();
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
        FormatterConverter formatConverter = new FormatterConverter();
        SerializationInfo serializationInfo =
            new SerializationInfo(ex.GetType(), formatConverter);
        StreamingContext streamingContext =
            new StreamingContext(StreamingContextStates.All);

        ex.GetObjectData(serializationInfo,streamingContext);
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