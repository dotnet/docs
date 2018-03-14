// <Snippet1>
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class Example
{
   public static void Main()
   {
      bool serialized = false;
      var formatter = new BinaryFormatter();
      Double[] values = { 3, 2, 1 };
      Double divisor = 0;
      foreach (var value in values) {
         try {
            BadDivisionException ex = null;
            if (divisor == 0) { 
               if (! serialized) {
                  // Instantiate the exception object.
                  ex = new BadDivisionException(0);
                  // Serialize the exception object.
                  var fs = new FileStream("BadDivision1.dat", 
                                           FileMode.Create);
                  formatter.Serialize(fs, ex);
                  fs.Close();
                  Console.WriteLine("Serialized the exception...");
               }
               else {
                  // Deserialize the exception.
                  var fs = new FileStream("BadDivision1.dat",
                                           FileMode.Open);
                  ex = (BadDivisionException) formatter.Deserialize(fs);
                  // Reserialize the exception.
                  fs.Position = 0;
                  formatter.Serialize(fs, ex);
                  fs.Close();
                  Console.WriteLine("Reserialized the exception...");                                            
               }   
              throw ex; 
            } 
            Console.WriteLine("{0} / {1} = {1}", value, divisor, value/divisor);
         }   
         catch (BadDivisionException e) {
            Console.WriteLine("Bad divisor from a {0} exception: {1}",
                              serialized ? "deserialized" : "new", e.Divisor);             
            serialized = true;
         }   
      }
   }
}

[Serializable] public class BadDivisionException : Exception
{
   // Maintain an internal BadDivisionException state object.
   [NonSerialized] private BadDivisionExceptionState state = new BadDivisionExceptionState();

   public BadDivisionException(Double divisor)
   {
      state.Divisor = divisor;
      HandleSerialization();      
   }
   
   private void HandleSerialization()
   {
      SerializeObjectState += delegate(object exception, SafeSerializationEventArgs eventArgs) 
                                      { 
                                          eventArgs.AddSerializedState(state);
                                      };
   }
   
   public Double Divisor
   { get { return state.Divisor; } }

   [Serializable] private struct BadDivisionExceptionState : ISafeSerializationData 
   {
      private Double badDivisor;
      
      public Double Divisor
      { get { return badDivisor; } 
        set { badDivisor = value; } }

      void ISafeSerializationData.CompleteDeserialization(object deserialized)
      { 
         var ex = deserialized as BadDivisionException;
         ex.HandleSerialization();
         ex.state = this; 
      }
   }
}
// The example displays the following output:
//       Serialized the exception...
//       Bad divisor from a new exception: 0
//       Reserialized the exception...
//       Bad divisor from a deserialized exception: 0
//       Reserialized the exception...
//       Bad divisor from a deserialized exception: 0
// </Snippet1>