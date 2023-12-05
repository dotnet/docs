let exists (x: int option) =
    match x with
    | Some(x) -> true
    | None -> false
