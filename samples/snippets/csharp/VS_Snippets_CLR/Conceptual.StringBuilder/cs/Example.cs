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
      StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
      // </Snippet1>
   }

   private static void InstantiateWithCapacity()
   {
      // <Snippet2>
      StringBuilder MyStringBuilder = new StringBuilder("Hello World!", 25);  
      // </Snippet2>
      // <Snippet3>
      MyStringBuilder.Capacity = 25;
      // </Snippet3>
   }

   private static void Appending()
   {
      // <Snippet4>
      StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
      MyStringBuilder.Append(" What a beautiful day.");
      Console.WriteLine(MyStringBuilder);
      // The example displays the following output:
      //       Hello World! What a beautiful day.
      // </Snippet4>
   }

   private static void AppendingFormat()
   {
      // <Snippet5>
      int MyInt = 25; 
      StringBuilder MyStringBuilder = new StringBuilder("Your total is ");
      MyStringBuilder.AppendFormat("{0:C} ", MyInt);
      Console.WriteLine(MyStringBuilder);
      // The example displays the following output:
      //       Your total is $25.00      
      // </Snippet5>
   }

   private static void Inserting()
   {
      // <Snippet6>
      StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
      MyStringBuilder.Insert(6,"Beautiful ");
      Console.WriteLine(MyStringBuilder);
      // The example displays the following output:
      //       Hello Beautiful World!
      // </Snippet6>
   }

   private static void Removing()
   {
      // <Snippet7>
      StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
      MyStringBuilder.Remove(5,7);
      Console.WriteLine(MyStringBuilder);
      // The example displays the following output:
      //       Hello
      // </Snippet7>
   }

   private static void Replacing()
   {
      // <Snippet8>
      StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
      MyStringBuilder.Replace('!', '?');
      Console.WriteLine(MyStringBuilder);
      // The example displays the following output:
      //       Hello World?
      // </Snippet8>
   }
}
