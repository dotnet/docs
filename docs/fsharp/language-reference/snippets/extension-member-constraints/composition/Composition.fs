namespace Composition

module Adapters =
    // <CombineAdapters>
    type System.Int32 with
        static member (++) (left: int, right: int) = left + right

    type List<'T> with
        static member (++) (left: 'T list, right: 'T list) = left @ right

    type ('T1 * 'T2) with
        static member inline (++) ((a, b), (c, d)) = (a ++ c, b ++ d)
    // </CombineAdapters>

    // <ContextAdapters>
    type ('Context * 'Value) with
        static member inline (<*>) ((before, mapping), (after, value)) =
            (before ++ after, mapping value)

    type struct ('Context * 'Value) with
        static member inline (<*>) (struct (before, mapping), struct (after, value)) =
            struct (before ++ after, mapping value)
    // </ContextAdapters>

    // <ReturnAdapters>
    type List<'T> with
        static member Return(value: 'T) : 'T list = [value]

    type Option<'T> with
        static member Return(value: 'T) : 'T option = Some value
    // </ReturnAdapters>

module Algorithms =
    open Adapters

    // <Return>
    let inline singleton (value: 'T) : ^Output =
        (^Output : (static member Return: 'T -> ^Output) value)
    // </Return>
