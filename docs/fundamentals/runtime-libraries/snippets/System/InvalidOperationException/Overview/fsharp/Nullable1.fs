module Nullable1

// <Snippet4>
open System
open System.Linq

let queryResult = [| Nullable 1; Nullable 2; Nullable(); Nullable 4 |]
let map = queryResult.Select(fun nullableInt -> nullableInt.Value)

// Display list.
for num in map do
    printf $"{num} "
printfn ""
// The example displays the following output:
//    1 2
//    Unhandled Exception: System.InvalidOperationException: Nullable object must have a value.
//       at System.ThrowHelper.ThrowInvalidOperationException(ExceptionResource resource)
//       at Example.<Main>b__0(Nullable`1 nullableInt)
//       at System.Linq.Enumerable.WhereSelectArrayIterator`2.MoveNext()
//       at <StartupCode$fs>.main()
// </Snippet4>