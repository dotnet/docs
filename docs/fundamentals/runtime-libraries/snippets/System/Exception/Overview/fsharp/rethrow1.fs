module rethrow1

// <Snippet6>
open System

module Library = 
    let findOccurrences (s: string) (f: string) =
        let indexes = ResizeArray()
        let mutable currentIndex = 0
        try
            while currentIndex >= 0 && currentIndex < s.Length do
                currentIndex <- s.IndexOf(f, currentIndex)
                if currentIndex >= 0 then
                    indexes.Add currentIndex
                    currentIndex <- currentIndex + 1
        with :? ArgumentNullException ->
            // Perform some action here, such as logging this exception.
            reraise ()
        indexes.ToArray()
// </Snippet6>

// <Snippet7>
open Library

let showOccurrences toFind (indexes: int[]) =
    printf $"'{toFind}' occurs at the following character positions: "
    for i = 0 to indexes.Length - 1 do
        printf $"""{indexes[i]}{if i = indexes.Length - 1 then "" else ", "}"""
    printfn ""

let s = "It was a cold day when..."
let indexes = findOccurrences s "a"
showOccurrences "a" indexes
printfn ""

let toFind: string = null
try
    let indexes = findOccurrences s toFind
    showOccurrences toFind indexes

with :? ArgumentNullException as e ->
    printfn $"An exception ({e.GetType().Name}) occurred."
    printfn $"Message:\n   {e.Message}\n"
    printfn $"Stack Trace:\n   {e.StackTrace}\n"

// The example displays the following output:
//    'a' occurs at the following character positions: 4, 7, 15
//
//    An exception (ArgumentNullException) occurred.
//    Message:
//       Value cannot be null. (Parameter 'value')
//
//    Stack Trace:
//          at System.String.IndexOf(String value, Int32 startIndex, Int32 count, Stri
//    ngComparison comparisonType)
//       at Library.findOccurrences(String s, String f)
//       at <StartupCode$fs>.main@()
// </Snippet7>