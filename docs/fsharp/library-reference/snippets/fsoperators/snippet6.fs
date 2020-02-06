
     let append4 string1 string2 string3 = string1 + "." + string2 + "." + string3

     // The <||| operator
     let result3 = append4 <||| ("abc", "def", "ghi")
     printfn "append4 <||| (\"abc\", \"def\", \"ghi\") gives  %A" result3