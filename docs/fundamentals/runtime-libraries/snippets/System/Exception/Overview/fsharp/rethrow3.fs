module rethrow3

open System
open rethrow1
open rethrow1.Library

let e = Exception()
// <Snippet8>
raise (ArgumentNullException("You must supply a search string.", e) )
// </Snippet8>

let s = "It was a cold day when..."
// <Snippet9>
try
    let indexes = findOccurrences s toFind
    showOccurrences toFind indexes
with :? ArgumentNullException as e ->
    printfn $"An exception ({e.GetType().Name}) occurred."
    printfn $"   Message:\n{e.Message}"
    printfn $"   Stack Trace:\n   {e.StackTrace}"
    let ie = e.InnerException
    if ie <> null then
        printfn "   The Inner Exception:"
        printfn $"      Exception Name: {ie.GetType().Name}"
        printfn $"      Message: {ie.Message}\n"
        printfn $"      Stack Trace:\n   {ie.StackTrace}\n"
// The example displays the following output:
//    'a' occurs at the following character positions: 4, 7, 15
//
//    An exception (ArgumentNullException) occurred.
//       Message: You must supply a search string.
//
//       Stack Trace:
//          at Library.FindOccurrences(String s, String f)
//       at Example.Main()
//
//       The Inner Exception:
//          Exception Name: ArgumentNullException
//          Message: Value cannot be null.
//    Parameter name: value
//
//          Stack Trace:
//          at System.String.IndexOf(String value, Int32 startIndex, Int32 count, Stri
//    ngComparison comparisonType)
//       at Library.FindOccurrences(String s, String f)
// </Snippet9>