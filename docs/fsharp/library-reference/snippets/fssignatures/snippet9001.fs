
namespace Library1

module Module1 =
   
    let function1 x = x + 1
 

    type Type1() =
        member type1.method1() =
            printfn "test1.method1"
        member type1.method2() =
            printfn "test1.method2"
         
         
    [<Sealed>]
    type Type2() =
        member type2.method1() =
            printfn "test1.method1"
        member type1.method2() =
            printfn "test1.method2"
           
    [<Interface>]
    type InterfaceType1 =
        abstract member method1 : int -> int
        abstract member method2 : string -> unit