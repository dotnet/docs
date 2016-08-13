
    let maxValue = 10
    let function1 x =
       if (x > maxValue) then
           eprintfn "Error: the input %d exceeds the maximum value, %d." x maxValue
       else
           printfn "Success!"
    function1 1
    function1 11