//<Snippet1>
using System;
using System.Collections;
namespace DesignLibrary
{
   
   public class ExceptionCollection : ICollection
   {   
      private ArrayList data;

      ExceptionCollection()
      {
         data = new ArrayList();
      }

      // Provide the explicit interface member for ICollection.
      void ICollection.CopyTo(Array array, int index)
      {
         data.CopyTo(array, index);
      }

      // Provide the strongly typed member for ICollection.
      public void CopyTo(Exception[] array, int index)
      {
         ((ICollection)this).CopyTo(array, index);
      }
   
      // Implement the rest of the ICollection members.
      public int Count
      {
        get 
        {
           return data.Count;
        }
      }

      public object SyncRoot
      {
         get 
        {
           return this; 
        }
      }

      public bool IsSynchronized
      {
         get 
         {
            return false; 
         }
      }

      // The IEnumerable interface is implemented by ICollection.
      // Because the type underlying this collection is a reference type,
      // you do not need a strongly typed version of GetEnumerator.

      public IEnumerator GetEnumerator()
      {
         return data.GetEnumerator();
      }
   }
}
//</Snippet1>
