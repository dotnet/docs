module run1
// <Snippet6>
open System.Threading.Tasks

let main =
    task {
        do!
            Task.Run(fun () ->
                for i = 0 to 1000000 do
                    printfn $"Finished {i} loop iterations")
    }

main.Wait()

// The example displays the following output:
//        Finished 1000001 loop iterations
// </Snippet6>
