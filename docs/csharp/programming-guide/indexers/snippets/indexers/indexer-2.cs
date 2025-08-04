namespace Indexers;

public class ReadOnlySampleCollection<T>
{
   // Declare an array to store the data elements.
   private T[] arr;

   public ReadOnlySampleCollection(params T[] items)
   {
       arr = items;
   }

   public T this[int i] => arr[i];

}

