//<Snippet1>
using System;
using System.Collections;
namespace DesignLibrary
{
   public class YourType
   {
      // Implementation for your strong type goes here.
      
      public YourType() {}
   }

   public class YourTypeCollection : CollectionBase
   {
      // Provide the strongly typed members for IList.
      public YourType this[int index]
      {
         get 
         {
            return (YourType) ((IList)this)[index];
         }
         set 
         {
            ((IList)this)[index] =  value;
         }
      }

      public int Add(YourType value)
      {
         return ((IList)this).Add ((object) value);
      }

      public bool Contains(YourType value) 
      {
         return ((IList)this).Contains((object) value);
      }

      public void Insert(int index, YourType value) 
      {
         ((IList)this).Insert(index, (object) value);
      }

      public void Remove(YourType value) 
      {
         ((IList)this).Remove((object) value);
      }

      public int IndexOf(YourType value) 
      {
         return ((IList)this).IndexOf((object) value);
      }

      // Provide the strongly typed member for ICollection.

      public void CopyTo(YourType[] array, int index)
      {
         ((ICollection)this).CopyTo(array, index);
      }
   }
}
//</Snippet1>
