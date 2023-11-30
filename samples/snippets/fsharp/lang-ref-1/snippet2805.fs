type Interface1 =
    abstract member Method1: int -> int

type Interface2 =
    abstract member Method2: int -> int

type Interface3 =
    inherit Interface1
    inherit Interface2
    abstract member Method3: int -> int

type MyClass() =
    interface Interface3 with
        member this.Method1(n) = 2 * n
        member this.Method2(n) = n + 100
        member this.Method3(n) = n / 10