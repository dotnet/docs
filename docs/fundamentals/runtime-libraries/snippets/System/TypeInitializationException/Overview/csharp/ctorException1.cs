// <Snippet3>
using System;

public class Example
{
   private static TestClass test = new TestClass(3);
   
   public static void Main()
   {
      Example ex = new Example();
      Console.WriteLine(test.Value);
   }
}

public class TestClass
{
   public readonly int Value;
   
   public TestClass(int value)
   {
      if (value < 0 || value > 1) throw new ArgumentOutOfRangeException(nameof(value));
      Value = value;
   }
}
// The example displays the following output:
//    Unhandled Exception: System.TypeInitializationException: 
//       The type initializer for 'Example' threw an exception. ---> 
//       System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values.
//       at TestClass..ctor(Int32 value)
//       at Example..cctor()
//       --- End of inner exception stack trace ---
//       at Example.Main()
// </Snippet3>
