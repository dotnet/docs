
    // A read-only property.
    member this.MyReadOnlyProperty = myInternalValue
    // A write-only property.
    member this.MyWriteOnlyProperty with set (value) = myInternalValue <- value
    // A read-write property.
    member this.MyReadWriteProperty
        with get () = myInternalValue
        and set (value) = myInternalValue <- value