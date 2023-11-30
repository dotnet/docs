type MyClass(x: string) =
    let mutable myInternalValue = x

    member this.MyProperty
        with get () = myInternalValue
        and set (value) = myInternalValue <- value
