// <Snippet1>
using System;
using System.Diagnostics;

public class ExampleClass
{
   Stopwatch sw;
   
   public ExampleClass()
   {
      sw = Stopwatch.StartNew();
      Console.WriteLine("Instantiated object");
   } 

   public void ShowDuration()
   {
      Console.WriteLine("This instance of {0} has been in existence for {1}",
                        this, sw.Elapsed);
   }
   
   ~ExampleClass()
   {
      Console.WriteLine("Finalizing object");
      sw.Stop();
      Console.WriteLine("This instance of {0} has been in existence for {1}",
                        this, sw.Elapsed);
   }
}

public class Demo
{
   public static void Main()
   {
      ExampleClass ex = new ExampleClass();
      ex.ShowDuration();
   }
}
// The example displays output like the following:
//    Instantiated object
//    This instance of ExampleClass has been in existence for 00:00:00.0011060
//    Finalizing object
//    This instance of ExampleClass has been in existence for 00:00:00.0036294
// </Snippet1>


// Finalize1.cs(21,28): error CS0249: Do not override object.Finalize. Instead, provide a
//         destructor.
