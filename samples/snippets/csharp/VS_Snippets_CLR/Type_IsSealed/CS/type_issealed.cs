// <Snippet1>   
using System;

 public class Example
 {
     // Declare InnerClass as sealed.
     sealed public class InnerClass
     {
     }

     public static void Main()
     {
          InnerClass inner = new InnerClass();
          // Get the type of InnerClass.
          Type innerType = inner.GetType();
          // Get the IsSealed property of  innerClass.
          bool isSealed = innerType.IsSealed;
          Console.WriteLine("{0} is sealed: {1}.", innerType.FullName, isSealed);
     }
}
// The example displays the following output:
//        Example+InnerClass is sealed: True.
// </Snippet1>