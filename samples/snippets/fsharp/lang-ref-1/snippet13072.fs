let sum list =
    let rec loop list acc =
        match list with
        | head :: tail -> loop tail (acc + head)
        | [] -> acc

    loop list 0
