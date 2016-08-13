
let beginning x y = x - 2*y
let ending x y = x + 2*y

let function5 x y =
  for i in (beginning x y) .. (ending x y) do
     printf "%d " i
  printfn ""

function5 10 4