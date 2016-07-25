
    let append1 string1 = string1 + ".append1"
    let append2 string1 = string1 + ".append2"

    // Reverse composition of two functions.
    let appendBothReverse = append1 << append2
    printfn "%s" (appendBothReverse "abc")

    // Reverse composition of three functions.
    let append3 string1 = string1 + ".append3"
    printfn "%s" ((append1 << append2 << append3) "abc")

    // Reverse composition of functions with more than one parameter.
    let appendString (string1:string) (string2:string) = string1 + string2

    let appendFileExtension extension =
        appendString extension << appendString "." 
    printfn "%s" (appendFileExtension "myfile" "txt")