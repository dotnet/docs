let charList = ['A'; 'B'; 'C'; 'D']

// This example demonstrates multiple cons patterns.
let matchChars xs =
    match xs with
    | 'A'::'B'::t -> printfn "starts with 'AB', rest: %A" t
    | 'A'::t -> printfn "starts with 'A', rest: %A" t
    | 'C'::'D'::t -> printfn "starts with 'CD', rest: %A" t
    | _ -> printfn "does not match"

matchChars charList
matchChars ['A'; 'X']
matchChars ['C'; 'D'; 'E']
