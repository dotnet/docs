let containsUppercase string1 =
    if (String.exists (fun c -> System.Char.IsUpper(c)) string1) then
        printfn "The string \"%s\" contains uppercase characters." string1
    else
        printfn "The string \"%s\" does not contain uppercase characters." string1
containsUppercase "Hello World!"
containsUppercase "no"