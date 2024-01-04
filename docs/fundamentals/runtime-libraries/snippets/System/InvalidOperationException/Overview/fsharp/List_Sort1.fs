module List_Sort1

// <Snippet12>
type Person(firstName: string, lastName: string) =
    member val FirstName = firstName with get, set
    member val LastName = lastName with get, set

let people = ResizeArray()

people.Add(Person("John", "Doe"))
people.Add(Person("Jane", "Doe"))
people.Sort()
for person in people do
    printfn $"{person.FirstName} {person.LastName}"
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
//       at <StartupCode$fs>.main()
// </Snippet12>