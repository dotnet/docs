// <Snippet4>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      // Instantiate a target object.
      int integer1 = 0;
      // Set the Type instance to the target class type.
      Type type1 = integer1.GetType();
      // Instantiate an Assembly class to the assembly housing the Integer type.
      Assembly sampleAssembly = Assembly.GetAssembly(integer1.GetType());
      // Display the name of the assembly that is calling the method.
      Console.WriteLine("GetCallingAssembly = " + Assembly.GetCallingAssembly().FullName);
   }
}
// The example displays output like the following:
//    GetCallingAssembly = Example, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// </Snippet4>

