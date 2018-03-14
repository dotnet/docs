let rot13 c =
    let upperZero = int 'A' - 1
    let lowerZero = int 'a' - 1
    if System.Char.IsLetter(c) then
        if System.Char.IsUpper(c) then
            char (((int c + 13 - upperZero) % 26) + upperZero)
        else
            char (((int c + 13 - lowerZero) % 26) + lowerZero)
    else c
let test = "The quick sly fox jumped over the lazy brown dog."
printfn "%s" test
printfn "%s" <| (String.map rot13 test)