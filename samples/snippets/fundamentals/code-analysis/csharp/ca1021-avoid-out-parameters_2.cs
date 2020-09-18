using System;

namespace DesignLibrary
{
   public class UseComplexMethod
   {
      static void UseTheComplicatedClass()
      {
         // Using the version with the ref and out parameters. 
         // You do not have to initialize an out parameter.

         string[] reply = new string[5];

         // You must initialize a ref parameter.
         Actions[] action = {Actions.Unknown,Actions.Unknown,
                             Actions.Unknown,Actions.Unknown,
                             Actions.Unknown,Actions.Unknown}; 
         bool[] disposition= new bool[5];
         int i = 0;

         foreach(TypeOfFeedback t in Enum.GetValues(typeof(TypeOfFeedback)))
         {
            // The call to the library.
            disposition[i] = BadRefAndOut.ReplyInformation(
               t, out reply[i], ref action[i]);
            Console.WriteLine("Reply: {0} Action: {1}  return? {2} ", 
               reply[i], action[i], disposition[i]);
            i++;
         }
      }

      static void UseTheSimplifiedClass()
      {
         ReplyData[] answer = new ReplyData[5];
         int i = 0;
         foreach(TypeOfFeedback t in Enum.GetValues(typeof(TypeOfFeedback)))
         {
            // The call to the library.
            answer[i] = RedesignedRefAndOut.ReplyInformation(t);
            Console.WriteLine(answer[i++]);
         }
      }

      public  static void Main()
      {
         UseTheComplicatedClass();

         // Print a blank line in output.
         Console.WriteLine("");

         UseTheSimplifiedClass();
      }
   }
}