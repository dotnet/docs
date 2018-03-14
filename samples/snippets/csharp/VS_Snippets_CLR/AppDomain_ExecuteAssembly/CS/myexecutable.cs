using System;

// <Snippet2>
public class MyExecutable {
   public static void Main() {
      string name = AppDomain.CurrentDomain.FriendlyName;
      Console.WriteLine("MyExecutable running on " + name);
   }
}
// </Snippet2>