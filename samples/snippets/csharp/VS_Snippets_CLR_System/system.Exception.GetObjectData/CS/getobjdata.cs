//<Snippet1>
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.Permissions;

 // Define a serializable derived exception class.
 [Serializable()]
 class SecondLevelException : Exception, ISerializable
 {
     // This public constructor is used by class instantiators.
     public SecondLevelException( string message, Exception inner ) :
         base( message, inner )
     {
         HelpLink = "http://MSDN.Microsoft.com";
         Source = "Exception_Class_Samples";
     }

     // This protected constructor is used for deserialization.
     protected SecondLevelException( SerializationInfo info, 
         StreamingContext context ) :
             base( info, context )
     { }

     // GetObjectData performs a custom serialization.
     [SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter=true)]
     public override void GetObjectData( SerializationInfo info, 
         StreamingContext context ) 
     {
         // Change the case of two properties, and then use the 
         // method of the base class.
         HelpLink = HelpLink.ToLower( );
         Source = Source.ToUpperInvariant();

         base.GetObjectData( info, context );
     }
 }

 class SerializationDemo 
 {
     public static void Main() 
     {
         Console.WriteLine( 
             "This example of the Exception constructor " +
             "and Exception.GetObjectData\nwith Serialization" +
             "Info and StreamingContext parameters " +
             "generates \nthe following output.\n" );

         try
         {
             // This code forces a division by 0 and catches the 
             // resulting exception.
             try
             {
                 int  zero = 0;
                 int  ecks = 1 / zero;
             }
             catch( Exception ex )
             {
                 // Create a new exception to throw again.
                 SecondLevelException newExcept =
                     new SecondLevelException( 
                         "Forced a division by 0 and threw " +
                         "another exception.", ex );

                 Console.WriteLine( 
                     "Forced a division by 0, caught the " +
                     "resulting exception, \n" +
                     "and created a derived exception:\n" );
                 Console.WriteLine( "HelpLink: {0}", 
                     newExcept.HelpLink );
                 Console.WriteLine( "Source:   {0}", 
                     newExcept.Source );

                 // This FileStream is used for the serialization.
                 FileStream stream = 
                     new FileStream( "NewException.dat", 
                         FileMode.Create );

                 try
                 {
                     // Serialize the derived exception.
                     SoapFormatter formatter = 
                         new SoapFormatter( null,
                             new StreamingContext( 
                                 StreamingContextStates.File ) );
                     formatter.Serialize( stream, newExcept );

                     // Rewind the stream and deserialize the 
                     // exception.
                     stream.Position = 0;
                     SecondLevelException deserExcept = 
                         (SecondLevelException)
                             formatter.Deserialize( stream );

                     Console.WriteLine( 
                         "\nSerialized the exception, and then " +
                         "deserialized the resulting stream " +
                         "into a \nnew exception. " +
                         "The deserialization changed the case " +
                         "of certain properties:\n" );
                     
                     // Throw the deserialized exception again.
                     throw deserExcept;
                 }
                 catch( SerializationException se )
                 {
                     Console.WriteLine( "Failed to serialize: {0}", 
                         se.ToString( ) );
                 }
                 finally
                 {
                     stream.Close( );
                 }
             }
         }
         catch( Exception ex )
         {
             Console.WriteLine( "HelpLink: {0}", ex.HelpLink );
             Console.WriteLine( "Source:   {0}", ex.Source );

             Console.WriteLine( );
             Console.WriteLine( ex.ToString( ) );
         }
     }
 }
/*
This example displays the following output.

Forced a division by 0, caught the resulting exception,
and created a derived exception:

HelpLink: http://MSDN.Microsoft.com
Source:   Exception_Class_Samples

Serialized the exception, and then deserialized the resulting stream into a
new exception. The deserialization changed the case of certain properties:

HelpLink: http://msdn.microsoft.com
Source:   EXCEPTION_CLASS_SAMPLES

NDP_UE_CS.SecondLevelException: Forced a division by 0 and threw another except
ion. ---> System.DivideByZeroException: Attempted to divide by zero.
   at NDP_UE_CS.SerializationDemo.Main()
   --- End of inner exception stack trace ---
   at NDP_UE_CS.SerializationDemo.Main()
*/
//</Snippet1>
