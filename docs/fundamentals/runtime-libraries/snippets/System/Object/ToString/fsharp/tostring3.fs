module tostring3

// <Snippet3>
type Object2(value: obj) =
    inherit obj ()
    override _.ToString() =
        base.ToString() + ": " + value.ToString()

let obj2 = Object2 'a'
printfn $"{obj2.ToString()}"
// The example displays the following output:
//       Object2: a
// </Snippet3>