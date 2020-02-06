
    let append4 string1 string2 string3 = string1 + "." + string2 + "." + string3

    // The |||> operator
    let result3 = ("abc", "def", "ghi") |||> append4
    printfn "(\"abc\", \"def\", \"ghi\") |||> append4 gives  %A" result3