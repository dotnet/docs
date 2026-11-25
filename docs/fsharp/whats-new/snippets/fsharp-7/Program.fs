// <GenericSum>
open System.Numerics

let sum<'T, 'TResult when INumber<'T> and INumber<'TResult>>(values: 'T seq) =
    let mutable result = 'TResult.Zero
    for value in values do
        result <- result + 'TResult.CreateChecked(value)
    result
// </GenericSum>

module PreviousSyntax =
    // <PreviousSrtpAverage>
    let inline average< ^T
                       when ^T: (static member (+): ^T * ^T -> ^T)
                       and  ^T: (static member DivideByInt : ^T * int -> ^T)
                       and  ^T: (static member Zero : ^T)>
                       (xs: ^T array) =
        let mutable sum : ^T = (^T : (static member Zero: ^T) ())
        for x in xs do
            sum <- (^T : (static member op_Addition: ^T * ^T -> ^T) (sum, x))
        (^T : (static member DivideByInt: ^T * int -> ^T) (sum, xs.Length))
    // </PreviousSrtpAverage>

module SimplifiedSyntax =
    // <SimplifiedSrtpAverage>
    let inline average<'T
                    when 'T: (static member (+): 'T * 'T -> 'T)
                    and  'T: (static member DivideByInt : 'T * int -> 'T)
                    and  'T: (static member Zero : 'T)>
                    (xs: 'T array) =
        let mutable sum = 'T.Zero
        for x in xs do
            sum <- sum + x
        'T.DivideByInt(sum, xs.Length)
    // </SimplifiedSrtpAverage>

let total = sum<int, int64> [1; 2; 3]
if total <> 6L then failwith "Unexpected sum."
printfn "Generic sum: %d" total

let values = [| 1.0; 2.0; 3.0 |]
let previousAverage = PreviousSyntax.average values
let simplifiedAverage = SimplifiedSyntax.average values
if previousAverage <> 2.0 || simplifiedAverage <> 2.0 then
    failwith "Unexpected average."
printfn "Previous SRTP average: %g" previousAverage
printfn "Simplified SRTP average: %g" simplifiedAverage

let person = Person(Id = 42, Name = "John", Surname = "Doe")
if person.Id <> 42 || person.Set() <> person then
    failwith "Unexpected init-only property value."
printfn "Init-only person: %d %s %s" person.Id person.Name person.Surname
