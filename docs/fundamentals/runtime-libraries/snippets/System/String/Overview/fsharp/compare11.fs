module compare11.fs
// <Snippet10>
open System
open System.Globalization
open System.Threading

Thread.CurrentThread.CurrentCulture <- CultureInfo.CreateSpecificCulture "en-US"
printfn $"""{String.Compare("A", "a", StringComparison.CurrentCulture)}"""
printfn $"""{String.Compare("A", "a", StringComparison.Ordinal)}"""
// The example displays the following output:
//       1
//       -32
// </Snippet10>
