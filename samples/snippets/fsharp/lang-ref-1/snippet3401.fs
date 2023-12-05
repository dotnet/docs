type SomeType(factor0: int) =
    let factor = factor0
    member this.SomeMethod(a, b, c) = (a + b + c) * factor

    member this.SomeOtherMethod(a, b, c) = this.SomeMethod(a, b, c) * factor
