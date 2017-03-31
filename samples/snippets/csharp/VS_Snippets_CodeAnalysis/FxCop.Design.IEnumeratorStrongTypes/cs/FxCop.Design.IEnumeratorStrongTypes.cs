//<Snippet1>
using System;
using System.Collections;
namespace DesignLibrary
{
   // The ExceptionEnumerator class implements a strongly typed enumerator 
   // for the ExceptionCollection type.

   public class ExceptionEnumerator: IEnumerator
   {
      private IEnumerator myCollectionEnumerator;

      private ExceptionEnumerator () {}

      public ExceptionEnumerator(ExceptionCollection collection)
      {
         myCollectionEnumerator = collection.data.GetEnumerator();
      }

      // Implement the IEnumerator interface member explicitly.
      object IEnumerator.Current
      {
         get 
         {
            return myCollectionEnumerator.Current;
         }
      }

      // Implement the strongly typed member.
      public Exception Current
      {
         get 
         {
            return (Exception) myCollectionEnumerator.Current;
         }
      }

      // Implement the remaining IEnumerator members.
      public bool MoveNext ()
      {
         return myCollectionEnumerator.MoveNext();
      }

      public void Reset ()
      {
         myCollectionEnumerator.Reset();
      }
   }

   public class ExceptionCollection : ICollection
   {   
      internal ArrayList data;

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
      IEnumerator IEnumerable.GetEnumerator()
      {
         return new ExceptionEnumerator(this);
      }

      public ExceptionEnumerator GetEnumerator()
      {
         return new ExceptionEnumerator(this);
      }
   }
}
//</Snippet1>
