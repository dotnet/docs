module zero1

// <Snippet6>
open System

let rnd = Random()

let getTimeBeforeLunch () =
    TimeSpan(rnd.Next(3, 6), 0, 0)

let getTimeAfterLunch() =
    TimeSpan(rnd.Next(3, 6), 0, 0)

do
    let timeSpent = TimeSpan.Zero

    let timeSpent = timeSpent + getTimeBeforeLunch ()
    let timeSpent = timeSpent + getTimeAfterLunch ()

    printfn $"Total time: {timeSpent}"


// The example displays output like the following:
//        Total time: 08:00:00
// </Snippet6>