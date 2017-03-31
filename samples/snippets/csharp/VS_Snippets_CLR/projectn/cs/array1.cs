using System;

public class Example
{
   public static void Main()
   {
      // <Snippet3>
      Type t = typeof(Class1);
      Type at = t.MakeArrayType(1);
      Array arr = Array.CreateInstance(at, 10);
      // </Snippet3>
      Console.WriteLine("{0} has {1} elements", arr.GetType().Name, arr.Length);
   }
}

public class Class1
{
 
}