using System;

public class Example
{
   public static void Main()
   {
   }
}

public class Disposable : IDisposable
{
   // <Snippet7>
   public void Dispose()
   {
      Dispose(true);             // Dispose of unmanaged resources.
      GC.SuppressFinalize(this); // Suppress finalization.
   }
   // </Snippet7>

   // <Snippet8>
   protected virtual void Dispose(bool disposing)
   // </Snippet8>
   {}
}
