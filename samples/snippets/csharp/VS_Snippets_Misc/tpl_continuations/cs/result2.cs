﻿// <Snippet7>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var t = Task.Run( () => { DateTime dat = DateTime.Now;
                                if (dat == DateTime.MinValue)
                                   throw new ArgumentException("The clock is not working.");

                                if (dat.Hour > 17)
                                   return "evening";
                                else if (dat.Hour > 12)
                                   return "afternoon";
                                else
                                   return "morning"; });
      var c = t.ContinueWith( (antecedent) => { if (t.Status == TaskStatus.RanToCompletion) {
                                                   Console.WriteLine("Good {0}!",
                                                                     antecedent.Result);
                                                   Console.WriteLine("And how are you this fine {0}?",
                                                                  antecedent.Result);
                                                }
                                                else if (t.Status == TaskStatus.Faulted) {
                                                   Console.WriteLine(t.Exception.GetBaseException().Message);
                                                }} );
   }
}
// The example displays output like the following:
//       Good afternoon!
//       And how are you this fine afternoon?
// </Snippet7>
