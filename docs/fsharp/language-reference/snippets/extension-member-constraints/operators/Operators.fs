module StructuralOperators

// <Operators>
type List<'T> with
    static member (|>>) (source: 'T list, mapping: 'T -> 'U) =
        List.map mapping source

type Option<'T> with
    static member (|>>) (source: 'T option, mapping: 'T -> 'U) =
        Option.map mapping source

let inline (|>>) (source: ^Input) (mapping: 'T -> 'U) : ^Output =
    (^Input :
        (static member (|>>): ^Input * ('T -> 'U) -> ^Output)
        (source, mapping))
// </Operators>
