type MyClassBase1() =
    let mutable z = 0
    abstract member function1: int -> int

    default u.function1(a: int) =
        z <- z + a
        z

type MyClassDerived1() =
    inherit MyClassBase1()
    override u.function1(a: int) = a + 1
