(*
Trying to use the result of typeof
on a unit of measure
*)
let theBadFunction<[<Measure>] 'u> = typeof<'u>
