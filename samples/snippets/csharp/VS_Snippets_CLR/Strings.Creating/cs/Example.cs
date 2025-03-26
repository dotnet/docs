using System;

[assembly: CLSCompliant(true)]
public class Class1
{
   public static void Main()
   {
      UseStringFormat();
      Console.WriteLine();
      UseStringConcat();
      Console.WriteLine();
      UseStringJoin();
      Console.WriteLine();
      UseStringInsert();
      Console.WriteLine();
      UseStringCopyTo();
   }

   private static void UseStringFormat()
   {
      // <Snippet1>
      int numberOfFleas = 12;
      string miscInfo = String.Format("Your dog has {0} fleas. " +
                                      "It is time to get a flea collar. " +
                                      "The current universal date is: {1:u}.",
                                      numberOfFleas, DateTime.Now);
      Console.WriteLine(miscInfo);
      // The example displays the following output:
      //       Your dog has 12 fleas. It is time to get a flea collar.
      //       The current universal date is: 2008-03-28 13:31:40Z.
      // </Snippet1>
   }

   private static void UseStringConcat()
   {
      // <Snippet2>
      string helloString1 = "Hello";
      string helloString2 = "World!";
      Console.WriteLine(String.Concat(helloString1, ' ', helloString2));
      // The example displays the following output:
      //      Hello World!
      // </Snippet2>
   }

   private static void UseStringJoin()
   {
      // <Snippet3>
      string[] words = {"Hello", "and", "welcome", "to", "my" , "world!"};
      Console.WriteLine(String.Join(" ", words));
      // The example displays the following output:
      //      Hello and welcome to my world!
      // </Snippet3>
   }

   private static void UseStringInsert()
   {
       // <Snippet4>
     string sentence = "Once a time.";
      Console.WriteLine(sentence.Insert(4, " upon"));
      // The example displays the following output:
      //      Once upon a time.
      // </Snippet4>
   }

   private static void UseStringCopyTo()
   {
       // <Snippet5>
      string greeting = "Hello World!";
      char[] charArray = {'W','h','e','r','e'};
      Console.WriteLine($"The original character array: {new string(charArray)}");
      greeting.CopyTo(0, charArray,0 ,5);
      Console.WriteLine($"The new character array: {new string(charArray)}");
      // The example displays the following output:
      //       The original character array: Where
      //       The new character array: Hello
      // </Snippet5>
   }
}
