
    let printPermutation n array1 =
        let length = Array.length array1
        if (n > 0 && n < length) then
            Array.permute (fun index -> (index + n) % length) array1
        else
            array1
        |> printfn "%A"
    let array1 = [| 1 .. 5 |]
    // There are 5 valid permutations of array1, with n from 0 to 4.
    for n in 0 .. 4 do
        printPermutation n array1 