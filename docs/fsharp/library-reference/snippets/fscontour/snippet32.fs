
let checkFor item = 
    let functionToReturn = fun lst ->
                           List.exists (fun a -> a = item) lst
    functionToReturn