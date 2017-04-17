// <Snippet12>
using System;
using System.Collections.Generic;

public class Person
{
   public Person(String fName, String lName)
   {
      FirstName = fName;
      LastName = lName;
   }
   
   public String FirstName { get; set; }
   public String LastName { get; set; }
}

public class Example
{
   public static void Main()
   {
      var people = new List<Person>();
      
      people.Add(new Person("John", "Doe"));
      people.Add(new Person("Jane", "Doe"));
      people.Sort();
      foreach (var person in people)
         Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
   }
}
// The example displays the following output:
//    Unhandled Exception: System.InvalidOperationException: Failed to compare two elements in the array. ---> 
//       System.ArgumentException: At least one object must implement IComparable.
//       at System.Collections.Comparer.Compare(Object a, Object b)
//       at System.Collections.Generic.ArraySortHelper`1.SwapIfGreater(T[] keys, IComparer`1 comparer, Int32 a, Int32 b)
//       at System.Collections.Generic.ArraySortHelper`1.DepthLimitedQuickSort(T[] keys, Int32 left, Int32 right, IComparer`1 comparer, Int32 depthLimit)
//       at System.Collections.Generic.ArraySortHelper`1.Sort(T[] keys, Int32 index, Int32 length, IComparer`1 comparer)
//       --- End of inner exception stack trace ---
//       at System.Collections.Generic.ArraySortHelper`1.Sort(T[] keys, Int32 index, Int32 length, IComparer`1 comparer)
//       at System.Array.Sort[T](T[] array, Int32 index, Int32 length, IComparer`1 comparer)
//       at System.Collections.Generic.List`1.Sort(Int32 index, Int32 count, IComparer`1 comparer)
//       at Example.Main()
// </Snippet12>

