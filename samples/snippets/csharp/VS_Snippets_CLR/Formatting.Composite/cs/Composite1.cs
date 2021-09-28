using System;

public class Class1
{
   public static void Main()
   {
      // <Snippet1>
      string name = "Fred";
      // <Snippet9>
      String.Format("Name = {0}, hours = {1:hh}", name, DateTime.Now);
      // </Snippet9>
      // </Snippet1>

      // <Snippet3>
      string FormatString1 = String.Format("{0:dddd MMMM}", DateTime.Now);
      string FormatString2 = DateTime.Now.ToString("dddd MMMM");
      // </Snippet3>

      // <Snippet4>
      int MyInt = 100;
      Console.WriteLine("{0:C}", MyInt);
      // The example displays the following output
      // if en-US is the current culture:
      //        $100.00
      // </Snippet4>

      CallSnippet5();
      CallSnippet6();
   }

   private static void CallSnippet5()
   {
      // <Snippet5>
      string myName = "Fred";
      Console.WriteLine(String.Format("Name = {0}, hours = {1:hh}, minutes = {1:mm}",
            myName, DateTime.Now));
      // Depending on the current time, the example displays output like the following:
      //    Name = Fred, hours = 11, minutes = 30
      // </Snippet5>
   }

   private static void CallSnippet6()
   {
      // <Snippet6>
      string myFName = "Fred";
      string myLName = "Opals";
      int myInt = 100;
      string FormatFName = String.Format("First Name = |{0,10}|", myFName);
      string FormatLName = String.Format("Last Name = |{0,10}|", myLName);
      string FormatPrice = String.Format("Price = |{0,10:C}|", myInt);
      Console.WriteLine(FormatFName);
      Console.WriteLine(FormatLName);
      Console.WriteLine(FormatPrice);
      Console.WriteLine();

      FormatFName = String.Format("First Name = |{0,-10}|", myFName);
      FormatLName = String.Format("Last Name = |{0,-10}|", myLName);
      FormatPrice = String.Format("Price = |{0,-10:C}|", myInt);
      Console.WriteLine(FormatFName);
      Console.WriteLine(FormatLName);
      Console.WriteLine(FormatPrice);
      // The example displays the following output on a system whose current
      // culture is en-US:
      //          First Name = |      Fred|
      //          Last Name = |     Opals|
      //          Price = |   $100.00|
      //
      //          First Name = |Fred      |
      //          Last Name = |Opals     |
      //          Price = |$100.00   |
      // </Snippet6>
   }
}
