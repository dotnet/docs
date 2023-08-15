type MyClass1(x: int, y: int) =
    do printfn "%d %d" x y
    new() = MyClass1(0, 0)
