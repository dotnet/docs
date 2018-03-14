//<Snippet1>
using System;
using System.IO;
  
namespace DesignLibrary
{
   // This class violates the rule.
   public class NoDisposeMethod
   {
      FileStream newFile;

      public NoDisposeMethod()
      {
         newFile = new FileStream(@"c:\temp.txt", FileMode.Open);
      }
   }

   // This class satisfies the rule.
   public class HasDisposeMethod: IDisposable
   {
      FileStream newFile;

      public HasDisposeMethod()
      {
         newFile = new FileStream(@"c:\temp.txt", FileMode.Open);
      }

      protected virtual void Dispose(bool disposing)
      {
         if (disposing)
            {
               // dispose managed resources
               newFile.Close();
            }
          // free native resources
      }

      public void Dispose()
      {
         Dispose(true);
	     GC.SuppressFinalize(this);
      }
   }
}
//</Snippet1>
