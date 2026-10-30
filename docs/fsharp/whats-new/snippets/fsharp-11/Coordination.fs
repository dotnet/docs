module Coordination

// <Ordering>
open System.Threading
open System.Threading.Tasks

let orderedResults () =
    let first = TaskCompletionSource<string>()
    let second = TaskCompletionSource<string>()
    let pending =
        Task.parallelLimit 2 CancellationToken.None
            [ (fun _ -> first.Task); (fun _ -> second.Task) ]
    second.SetResult("second")
    first.SetResult("first")
    pending

let ordered = (orderedResults ()).GetAwaiter().GetResult()
printfn "%A" ordered
// [|"first"; "second"|]
// </Ordering>

do if ordered <> [|"first"; "second"|] then failwith "Input ordering"
