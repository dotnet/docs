// Abstract property in abstract class.
// The property is an int type that has a get and
// set method
[<AbstractClass>]
type AbstractBase() =
    abstract Property1: int with get, set

// Implementation of the abstract property
type Derived1() =
    inherit AbstractBase()
    let mutable value = 10

    override this.Property1
        with get () = value
        and set (v: int) = value <- v

// A type with a "virtual" property.
type Base1() =
    let mutable value = 10
    abstract Property1: int with get, set

    default this.Property1
        with get () = value
        and set (v: int) = value <- v

// A derived type that overrides the virtual property
type Derived2() =
    inherit Base1()
    let mutable value2 = 11

    override this.Property1
        with get () = value2
        and set (v) = value2 <- v
