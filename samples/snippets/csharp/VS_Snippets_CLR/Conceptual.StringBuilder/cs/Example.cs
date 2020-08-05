// <Snippet11>
using System;
using System.Text;
// </Snippet11>

[assembly: CLSCompliant(true)]
public class Example
{
   public static void Main()
   {
      InstantiateStringBuilder();
      InstantiateWithCapacity();
      Appending();
      AppendingFormat();
      Inserting();
      Removing();
      Replacing();
   }

   private static void InstantiateStringBuilder()
   {
      // <Snippet1>
      StringBuilder myStringBuilder = new StringBuilder("Hello World!");
      // </Snippet1>
   }

   private static void InstantiateWithCapacity()
   {
      // <Snippet2>
      StringBuilder myStringBuilder = new StringBuilder("Hello World!", 25);
      // </Snippet2>
      // <Snippet3>
      myStringBuilder.Capacity = 25;
      // </Snippet3>
   }

   private static void Appending()
   {
      // <Snippet4>
      StringBuilder myStringBuilder = new StringBuilder("Hello World!");
      myStringBuilder.Append(" What a beautiful day.");
      Console.WriteLine(myStringBuilder);
      // The example displays the following output:
      //       Hello World! What a beautiful day.
      // </Snippet4>
   }

   private static void AppendingFormat()
   {
      // <Snippet5>
      int MyInt = 25;
      StringBuilder myStringBuilder = new StringBuilder("Your total is ");
      myStringBuilder.AppendFormat("{0:C} ", MyInt);
      Console.WriteLine(myStringBuilder);
      // The example displays the following output:
      //       Your total is $25.00
      // </Snippet5>
   }

   private static void Inserting()
   {
      // <Snippet6>
      StringBuilder myStringBuilder = new StringBuilder("Hello World!");
      myStringBuilder.Insert(6,"Beautiful ");
      Console.WriteLine(myStringBuilder);
      // The example displays the following output:
      //       Hello Beautiful World!
      // </Snippet6>
   }

   private static void Removing()
   {
      // <Snippet7>
      StringBuilder myStringBuilder = new StringBuilder("Hello World!");
      myStringBuilder.Remove(5,7);
      Console.WriteLine(myStringBuilder);
      // The example displays the following output:
      //       Hello
      // </Snippet7>
   }

   private static void Replacing()
   {
      // <Snippet8>
      StringBuilder myStringBuilder = new StringBuilder("Hello World!");
      myStringBuilder.Replace('!', '?');
      Console.WriteLine(myStringBuilder);
      // The example displays the following output:
      //       Hello World?
      // </Snippet8>
   }
}
