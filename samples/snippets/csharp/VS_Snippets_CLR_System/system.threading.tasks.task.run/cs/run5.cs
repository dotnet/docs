// <Snippet5>
using System;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Random rnd = new Random();
      Task<int>[] tasks = new Task<int>[2];
      Object obj = new Object();
      
      while (true) {
         for (int ctr = 0; ctr <= 1; ctr++)
            tasks[ctr] = Task.Factory.StartNew(() => { int i = 0;
                                                       lock(obj) {
                                                          i = rnd.Next(101);
                                                       }
                                                       return i; });

         Task.WaitAll(tasks);
         int n1 = tasks[0].Result;
         int n2 = tasks[1].Result;
         int result = n1 + n2;
         bool validInput = false;
         while (! validInput) {
            ShowMessage(n1, n2);
            string userInput = Console.ReadLine();
            // Process user input.
            if (userInput.Trim().ToUpper() == "X") return;
            int answer;
            validInput = Int32.TryParse(userInput, out answer);
            if (! validInput)
               Console.WriteLine("Invalid input. Try again, but enter only numbers. ");
            else if (answer == result)
               Console.WriteLine("Correct!");
            else
               Console.WriteLine("Incorrect. The correct answer is {0}.", result);
         }
      }
   }

   private static void ShowMessage(int n1, int n2)
   {
      Console.WriteLine("\nEnter 'x' to exit...");
      Console.Write("{0} + {1} = ", n1, n2);
   }
}
// The example displays the following output:
//       Enter 'x' to exit...
//       15 + 11 = 26
//       Correct!
//
//       Enter 'x' to exit...
//       75 + 33 = adc
//       Invalid input. Try again, but enter only numbers.
//
//       Enter 'x' to exit...
//       75 + 33 = 108
//       Correct!
//
//       Enter 'x' to exit...
//       67 + 55 = 133
//       Incorrect. The correct answer is 122.
//
//       Enter 'x' to exit...
//       92 + 51 = 133
//       Incorrect. The correct answer is 143.
//
//       Enter 'x' to exit...
//       81 + 65 = x
// </Snippet5>
