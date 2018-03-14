// <Snippet1>
using System;

public class TestClass
{
}

public class Example
{
   public static void Main()
   {
      TestClass testClassInstance = new TestClass();
      // Get the type of myTestClassInstance.
      Type   testType = testClassInstance.GetType();
      // Get the IsPublic property of testClassInstance.
      bool isPublic = testType.IsPublic;
      Console.WriteLine("Is {0} public? {1}", testType.FullName, isPublic);
   }
}
// The example displays the following output:
//        Is TestClass public? True
// </Snippet1>
