// <Snippet1>

using System;
using System.Reflection;

class Program
{
    // Methods to get:

    public void MethodA(int i, int j) { }

    public void MethodA(int[] i) { }

    public unsafe void MethodA(int* i) { }

    public void MethodA(ref int r) {}

    // Method that takes an out parameter:
    public void MethodA(int i, out int o) { o = 100;}


  static void Main(string[] args)
  {
    MethodInfo mInfo;

    // Get MethodA(int i, int j)
    mInfo = typeof(Program).GetMethod("MethodA",
        BindingFlags.Public | BindingFlags.Instance,
        null,
        CallingConventions.Any,
        new Type[] { typeof(int), typeof(int) },
        null);
    Console.WriteLine("Found method: {0}", mInfo);

    // Get MethodA(int[] i)
    mInfo = typeof(Program).GetMethod("MethodA",
        BindingFlags.Public | BindingFlags.Instance,
        null,
        CallingConventions.Any,
        new Type[] { typeof(int[]) },
        null);
    Console.WriteLine("Found method: {0}", mInfo);

    // Get MethodA(int* i)
    mInfo = typeof(Program).GetMethod("MethodA",
        BindingFlags.Public | BindingFlags.Instance,
        null,
        CallingConventions.Any,
        new Type[] { typeof(int).MakePointerType() },
        null);
    Console.WriteLine("Found method: {0}", mInfo);

    // Get MethodA(ref int r)
    mInfo = typeof(Program).GetMethod("MethodA",
        BindingFlags.Public | BindingFlags.Instance,
        null,
        CallingConventions.Any,
        new Type[] { typeof(int).MakeByRefType() },
        null);
    Console.WriteLine("Found method: {0}", mInfo);

    // Get MethodA(int i, out int o)
    mInfo = typeof(Program).GetMethod("MethodA",
        BindingFlags.Public | BindingFlags.Instance,
        null,
        CallingConventions.Any,
        new Type[] { typeof(int), typeof(int).MakeByRefType() },
        null);
    Console.WriteLine("Found method: {0}", mInfo);

  }
}
// </Snippet1>


