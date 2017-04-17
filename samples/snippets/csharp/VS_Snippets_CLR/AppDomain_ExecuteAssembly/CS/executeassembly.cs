using System;

// <Snippet1>
class Test {
   public static void Main() {
      AppDomain currentDomain = AppDomain.CurrentDomain;
      AppDomain otherDomain = AppDomain.CreateDomain("otherDomain");
      
      currentDomain.ExecuteAssembly("MyExecutable.exe");
      // Prints "MyExecutable running on [default]"

      otherDomain.ExecuteAssembly("MyExecutable.exe");
      // Prints "MyExecutable running on otherDomain"
   }
}
// </Snippet1>
