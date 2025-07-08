module immutability2

#nowarn "9"

do
    // <Snippet1>
    let mutable value = "This is the first sentence" + "."
    use start = fixed value
    value <- System.String.Concat(value, "This is the second sentence. ")
    use current = fixed value
    printfn $"{start = current}"
// The example displays the following output:
//      False
// </Snippet1>
