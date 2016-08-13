
    let isWholeNumber string1 =
        if (String.forall (fun c -> System.Char.IsDigit(c)) string1) then
            printfn "The string \"%s\" is a whole number." string1
        else
            printfn "The string \"%s\" is not a valid whole number." string1
    isWholeNumber "8005"
    isWholeNumber "512"
    isWholeNumber "0x20"
    isWholeNumber "1.0E-5"
    isWholeNumber "-20"