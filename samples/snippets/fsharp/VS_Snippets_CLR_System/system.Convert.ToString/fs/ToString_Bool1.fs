open System;

[<EntryPoint>]
let main argv = 
    // <Snippet1> 
    let falseFlag = false
    let trueFlag = true

    Console.WriteLine (Convert.ToString falseFlag)
    Console.WriteLine (Convert.ToString falseFlag=Boolean.FalseString)
    Console.WriteLine (Convert.ToString trueFlag)
    Console.WriteLine (Convert.ToString trueFlag=Boolean.TrueString)
    // The example displays the following output:
    //       False
    //       True
    //       True
    //       True
    // </Snippet1>
    0
