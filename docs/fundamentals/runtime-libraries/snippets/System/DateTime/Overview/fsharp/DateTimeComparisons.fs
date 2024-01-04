module DateTimeComparisons

open System
open System.Text

// <Snippet1>
let roughlyEquals (time: DateTime) (timeWithWindow: DateTime) windowInSeconds frequencyInSeconds =
    let delta = 
        int64 (timeWithWindow - time).TotalSeconds % frequencyInSeconds
    
    let delta = if delta > windowInSeconds then frequencyInSeconds - delta else delta
    abs delta < windowInSeconds

let testRoughlyEquals () =
    let window = 10
    let window' = 10.
    let freq = 60 * 60 * 2 // 2 hours

    let d1 = DateTime.Now

    let d2 = d1.AddSeconds(2. * window')
    let d3 = d1.AddSeconds(-2. * window')
    let d4 = d1.AddSeconds(window' / 2.)
    let d5 = d1.AddSeconds(-window' / 2.)

    let d6 = (d1.AddHours 2).AddSeconds(2. * window')
    let d7 = (d1.AddHours 2).AddSeconds(-2. * window')
    let d8 = (d1.AddHours 2).AddSeconds(window' / 2.)
    let d9 = (d1.AddHours 2).AddSeconds(-window' / 2.)

    printfn $"d1 ({d1}) ~= d1 ({d1}): {roughlyEquals d1 d1 window freq}"
    printfn $"d1 ({d1}) ~= d2 ({d2}): {roughlyEquals d1 d2 window freq}"
    printfn $"d1 ({d1}) ~= d3 ({d3}): {roughlyEquals d1 d3 window freq}"
    printfn $"d1 ({d1}) ~= d4 ({d4}): {roughlyEquals d1 d4 window freq}"
    printfn $"d1 ({d1}) ~= d5 ({d5}): {roughlyEquals d1 d5 window freq}"

    printfn $"d1 ({d1}) ~= d6 ({d6}): {roughlyEquals d1 d6 window freq}"
    printfn $"d1 ({d1}) ~= d7 ({d7}): {roughlyEquals d1 d7 window freq}"
    printfn $"d1 ({d1}) ~= d8 ({d8}): {roughlyEquals d1 d8 window freq}"
    printfn $"d1 ({d1}) ~= d9 ({d9}): {roughlyEquals d1 d9 window freq}"

// The example displays output similar to the following:
//    d1 (1/28/2010 9:01:26 PM) ~= d1 (1/28/2010 9:01:26 PM): True
//    d1 (1/28/2010 9:01:26 PM) ~= d2 (1/28/2010 9:01:46 PM): False
//    d1 (1/28/2010 9:01:26 PM) ~= d3 (1/28/2010 9:01:06 PM): False
//    d1 (1/28/2010 9:01:26 PM) ~= d4 (1/28/2010 9:01:31 PM): True
//    d1 (1/28/2010 9:01:26 PM) ~= d5 (1/28/2010 9:01:21 PM): True
//    d1 (1/28/2010 9:01:26 PM) ~= d6 (1/28/2010 11:01:46 PM): False
//    d1 (1/28/2010 9:01:26 PM) ~= d7 (1/28/2010 11:01:06 PM): False
//    d1 (1/28/2010 9:01:26 PM) ~= d8 (1/28/2010 11:01:31 PM): True
//    d1 (1/28/2010 9:01:26 PM) ~= d9 (1/28/2010 11:01:21 PM): True
// </Snippet1>
testRoughlyEquals ()