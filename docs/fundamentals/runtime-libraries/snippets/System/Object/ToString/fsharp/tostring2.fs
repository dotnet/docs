module tostring2

// <Snippet2>
type Object1() = class end

let obj1 = Object1()
printfn $"{obj1.ToString()}"
// The example displays the following output:
//   Examples.Object1
// </Snippet2>