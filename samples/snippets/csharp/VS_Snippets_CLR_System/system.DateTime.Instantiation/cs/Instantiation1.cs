using System;
using System.Globalization;

public class Class1
{
   public static void Main()
   {
      InstantiateWithConstructor();
      InstantiateWithReturnValue();
      InstantiateFromString();
      InstantiateUsingDftCtor();
   }

   private static void InstantiateWithConstructor()
   {
      // <Snippet1>
      DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
      // </Snippet1>
   }

   private static void InstantiateWithReturnValue()
   {
      // <Snippet3>
      DateTime date1 = DateTime.Now;
      DateTime date2 = DateTime.UtcNow;
      DateTime date3 = DateTime.Today;
      // </Snippet3>
   }

   private static void InstantiateFromString()
   {
      // <Snippet4>
      string dateString = "5/1/2008 8:30:52 AM";
      DateTime date1 = DateTime.Parse(dateString, 
                                System.Globalization.CultureInfo.InvariantCulture); 
      // </Snippet4>
   } 

   private static void InstantiateUsingDftCtor()
   {
      // <Snippet5>
      DateTime dat1 = new DateTime();
      // The following method call displays 1/1/0001 12:00:00 AM.
      Console.WriteLine(dat1.ToString(System.Globalization.CultureInfo.InvariantCulture));
      // The following method call displays True.
      Console.WriteLine(dat1.Equals(DateTime.MinValue));
      // </Snippet5>
   }
}
