// <Snippet5>
using System;

static class Func1
{
   public static void Main()
   {
      // Note that each lambda expression has no parameters.
      LazyValue<int> lazyOne = new LazyValue<int>(() => ExpensiveOne());
      LazyValue<long> lazyTwo = new LazyValue<long>(() => ExpensiveTwo("apple"));

      Console.WriteLine("LazyValue objects have been created.");

      // Get the values of the LazyValue objects.
      Console.WriteLine(lazyOne.Value);
      Console.WriteLine(lazyTwo.Value);
   }
      
   static int ExpensiveOne()
   {
      Console.WriteLine("\nExpensiveOne() is executing.");
      return 1;
   }

   static long ExpensiveTwo(string input)
   {
      Console.WriteLine("\nExpensiveTwo() is executing.");
      return (long)input.Length;
   }
}

class LazyValue<T> where T : struct
{
   private Nullable<T> val;
   private Func<T> getValue;

   // Constructor.
   public LazyValue(Func<T> func)
   {
      val = null;
      getValue = func;
   }

   public T Value
   {
      get
      {
         if (val == null)
            // Execute the delegate.
            val = getValue();
         return (T)val;
      }
   }
}
/* The example produces the following output:

    LazyValue objects have been created.
    
    ExpensiveOne() is executing.
    1
    
    ExpensiveTwo() is executing.
    5
*/    
// </Snippet5>
