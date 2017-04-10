using System;

public class Example
{
   public static void Main()
   {
      ShowYMD();
      Console.WriteLine("-----");
      ShowYMDHMS();
      Console.WriteLine("-----");
      ShowYMDHMSMs();
      Console.WriteLine("-----");
      ShowYMDHMSKind();
      Console.WriteLine("-----");
      ShowYMDHMSMsKind();
   }

   private static void ShowYMD()
   {
      // <Snippet1>
      DateTime date1 = new DateTime(2010, 8, 18);
      Console.WriteLine(date1.ToString());
      // The example displays the following output:
      //      8/18/2010 12:00:00 AM      
      // </Snippet1>
   }

   private static void ShowYMDHMS()
   {
      // <Snippet3>
      DateTime date1 = new DateTime(2010, 8, 18, 16, 32, 0);
      Console.WriteLine(date1.ToString());
      // The example displays the following output:
      //      8/18/2010 4:32:00 PM
      // </Snippet3>
   }

   private static void ShowYMDHMSMs()
   {
      // <Snippet5>
      DateTime date1 = new DateTime(2010, 8, 18, 16, 32, 18, 500);
      Console.WriteLine(date1.ToString("M/dd/yyyy h:mm:ss.fff tt"));
      // The example displays the following output:
      //      8/18/2010 4:32:18.500 PM
      // </Snippet5>
   }

   private static void ShowYMDHMSKind()
   {
      // <Snippet7>
      DateTime date1 = new DateTime(2010, 8, 18, 16, 32, 0, DateTimeKind.Local);
      Console.WriteLine("{0} {1}", date1, date1.Kind);
      // The example displays the following output:
      //      8/18/2010 4:32:00 PM Local
      // </Snippet7>
   }

   private static void ShowYMDHMSMsKind()
   {
      // <Snippet8>
      DateTime date1 = new DateTime(2010, 8, 18, 16, 32, 18, 500, 
                                    DateTimeKind.Local);
      Console.WriteLine("{0:M/dd/yyyy h:mm:ss.fff tt} {1}", date1, date1.Kind);
      // The example displays the following output:
      //      8/18/2010 4:32:18.500 PM Local
      // </Snippet8>
   }
}
