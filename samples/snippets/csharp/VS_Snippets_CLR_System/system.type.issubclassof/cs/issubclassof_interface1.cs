// <Snippet1>
using System;

public interface IInterface
{
   void Display();
}

public class Implementation : IInterface
{
   public void Display()
   {
      Console.WriteLine("The implementation...");
   }
}

public class Example
{
   public static void Main()
   {
      Console.WriteLine("Implementation is a subclass of IInterface:   {0}",
                        typeof(Implementation).IsSubclassOf(typeof(IInterface)));
      Console.WriteLine("IInterface is assignable from Implementation: {0}",
                        typeof(IInterface).IsAssignableFrom(typeof(Implementation)));
   }
}
// The example displays the following output:
//       Implementation is a subclass of IInterface:   False
//       IInterface is assignable from Implementation: True
// </Snippet1>