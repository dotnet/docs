// A generic function.
// In this example, the generic type parameter 'a makes function3 generic.
let function3 (x: 'a) (y: 'a) = printf "%A %A" x y

// A generic record, with the type parameter in angle brackets.
type GR<'a> = { Field1: 'a; Field2: 'a }

// A generic class.
type C<'a>(a: 'a, b: 'a) =
    let z = a
    let y = b
    member this.GenericMethod(x: 'a) = printfn "%A %A %A" x y z

// A generic discriminated union.
type U<'a> =
    | Choice1 of 'a
    | Choice2 of 'a * 'a

type Test() =
    // A generic member
    member this.Function1<'a>(x, y) = printfn "%A, %A" x y

    // A generic abstract method.
    abstract abstractMethod<'a, 'b> : 'a * 'b -> unit
    override this.abstractMethod<'a, 'b>(x: 'a, y: 'b) = printfn "%A, %A" x y
