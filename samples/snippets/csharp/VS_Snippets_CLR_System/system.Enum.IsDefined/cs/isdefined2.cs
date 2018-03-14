// <Snippet2>
using System;

[Flags] public enum Pets { 
      None = 0, Dog = 1, Cat = 2, Bird = 4, 
      Rodent = 8, Other = 16 };

public class Example
{
   public static void Main()
   {
      Pets value = Pets.Dog | Pets.Cat;
      Console.WriteLine("{0:D} Exists: {1}", 
                        value, Pets.IsDefined(typeof(Pets), value));
      string name = value.ToString();
      Console.WriteLine("{0} Exists: {1}", 
                        name, Pets.IsDefined(typeof(Pets), name));
   }
}
// The example displays the following output:
//       3 Exists: False
//       Dog, Cat Exists: False
// </Snippet2>
