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
      // Dispose of unmanaged resources.
      Dispose(true);
      // Suppress finalization.
      GC.SuppressFinalize(this);
   }
   // </Snippet7> 

   // <Snippet8>
   protected virtual void Dispose(bool disposing)
   // </Snippet8>
   {}
}

