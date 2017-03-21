using System;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization;

class CryptographicExceptionMembers
{
    [STAThread]
    public static void Main(string[] args)
    {
        CryptographicExceptionMembers testRun = 
            new CryptographicExceptionMembers();
        testRun.TestConstructors();
        testRun.ShowProperties();
        
        Console.WriteLine("This sample ended successfully; " + 
            " press Enter to exit.");
        Console.ReadLine();
    }

    // Test each public implementation of the CryptographicException
    // constructors.
    private void TestConstructors()
    {
        EmptyConstructor();
        IntConstructor();
        StringConstructor();
        StringExceptionConstructor();
        StringStringConstructor();
    }

    private void EmptyConstructor()
    {
        // Construct a CryptographicException with no parameters.
        CryptographicException cryptographicException =
            new CryptographicException();
        Console.WriteLine("Created an empty CryptographicException.");
    }

    private void IntConstructor()
    {
        // Construct a CryptographicException using the error code for an
        // unexpected operation exception.
        int exceptionNumber = unchecked((int)0x80131431);
        CryptographicException cryptographicException =
            new CryptographicException(exceptionNumber);
        Console.WriteLine("Created a CryptographicException with the " + 
            "following error code: " + exceptionNumber);
    }

    private void StringConstructor()
    {
        // Construct a CryptographicException using a custom error message.
        string errorMessage = ("Unexpected Operation exception.");
        CryptographicException cryptographicException =
            new CryptographicException(errorMessage);
        Console.WriteLine("Created a CryptographicException with the " + 
            "following error message: " + errorMessage);
    }

    private void StringExceptionConstructor()
    {
        // Construct a CryptographicException using a custom error message
        // and an inner exception.
        string errorMessage = ("The current operation is not supported.");
        NullReferenceException nullException = new NullReferenceException();
        CryptographicException cryptographicException = 
            new CryptographicException(errorMessage, nullException);
        Console.WriteLine("Created a CryptographicException with the " +
            "following error message: " + errorMessage + 
            " and the inner exception of " + nullException.ToString());
    }

    private void StringStringConstructor()
    {
        // Create a CryptographicException using a time format and a the 
        // current date.
        string dateFormat = "{0:t}";
        string timeStamp = (DateTime.Now.ToString());
        CryptographicException cryptographicException = 
            new CryptographicException(dateFormat, timeStamp);
        Console.WriteLine("Created a CryptographicException with (" +
            dateFormat + ") as the format and (" + timeStamp + 
            ") as the message.");
    }

    // Construct an invalid DSACryptoServiceProvider to throw a
    // CryptographicException for introspection.
    private void ShowProperties()
    {
        try 
        {
            // Create a DSACryptoServiceProvider with invalid provider type
            // code to throw a CryptographicException exception.
            CspParameters cspParams = new CspParameters(44);
            DSACryptoServiceProvider DSAalg = 
                new DSACryptoServiceProvider(cspParams);
        }
        catch (CryptographicException ex)
        {
            // Retrieve the link to the help file for the exception.
            string helpLink = ex.HelpLink;
            
            // Retrieve the exception that caused the current
            // CryptographicException exception.
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

            // Retrieve the call stack at the time the exception occured.
            string stackTrace = ex.StackTrace;

            // Retrieve the method that threw the exception.
            System.Reflection.MethodBase targetSite = ex.TargetSite;
            string siteName = targetSite.Name;

            // Retrieve the entire exception as a single string.
            string entireException = ex.ToString();

            // GetObjectData
            setSerializationInfo(ref ex);

            // Get the root exception that caused the current
            // CryptographicException exception.
            System.Exception baseException = ex.GetBaseException();
            string baseExceptionMessage = "";
            if (baseException != null)
            {
                baseExceptionMessage = baseException.Message;
            }

            Console.WriteLine("Caught an expected exception:");
            Console.WriteLine(entireException);

            Console.WriteLine("\n");
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

    private void setSerializationInfo(ref CryptographicException ex)
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
// Created an empty CryptographicException.
// Created a CryptographicException with the following error code: -2146233295
// Created a CryptographicException with the following error message: 
// Unexpected Operation exception.
// Created a CryptographicException with the following error message: The
// current operation is not supported. and the inner exception of 
// System.NullReferenceException: Object reference not set to an instance of
// an object.
// Created a CryptographicException with ({0:t}) as the format and (2/24/2004
// 2:13:15 PM) as the message.
// Caught an expected exception:
// System.Security.Cryptography.CryptographicException: CryptoAPI
// cryptographic service provider (CSP) for this implementation could not be
// acquired. 
//  at System.Security.Cryptography.DSACryptoServiceProvider..ctor(Int32
// dwKeySize, CspParameters parameters)
//  at System.Security.Cryptography.DSACryptoServiceProvider..ctor(
// CspParametersparameters)
//  at CryptographicExceptionMembers.ShowProperties() in c:\inetpub\
// vssolutions\test\testbuild\consoleapplication1\class1.cs:line 109
//
//
// Properties of the exception are as follows:
// Message: CryptoAPI cryptographic service provider (CSP) for this
// implementation could not be acquired.
// Source: mscorlib
// Stack trace:    
//  at System.Security.Cryptography.DSACryptoServiceProvider..ctor(
// Int32 dwKeySize, CspParameters parameters) 
//  at System.Security.Cryptography.DSACryptoServiceProvider..ctor(
// CspParameters parameters)
//  at CryptographicExceptionMembers.ShowProperties() in c:\inetpub\
// vssolutions\test\testbuild\consoleapplication1\class1.cs:line 109
// Help link:
// Target site's name: .ctor
// Base exception message: CryptoAPI cryptographic service provider (CSP) for
// this implementation could not be acquired.
// Inner exception message:
// This sample ended successfully;  press Enter to exit.