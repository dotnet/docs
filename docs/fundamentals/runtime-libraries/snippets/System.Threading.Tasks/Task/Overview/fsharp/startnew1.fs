module startnew1
// <Snippet7>
open System.Threading.Tasks

let t =
    Task.Factory.StartNew(fun () ->
        // Just loop.
        for i = 0 to 1000000 do
            printfn $"Finished {i} loop iterations")

t.Wait()


// The example displays the following output:
//        Finished 1000001 loop iterations
// </Snippet7>
