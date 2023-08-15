let rec sum list =
    match list with
    | head :: tail -> head + sum tail
    | [] -> 0
