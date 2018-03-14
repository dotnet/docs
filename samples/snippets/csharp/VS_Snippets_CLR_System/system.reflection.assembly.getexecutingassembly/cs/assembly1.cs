// <Snippet1>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      Assembly assem = typeof(Example).Assembly;
      Console.WriteLine("Assembly name: {0}", assem.FullName);
   }
}
// The example displays output like the following:
//    Assembly name: Assembly1, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// </Snippet1>