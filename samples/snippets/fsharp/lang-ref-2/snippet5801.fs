
exception InnerError of string
exception OuterError of string

let function1 x y =
   try
     try
        if x = y then raise (InnerError("inner"))
        else raise (OuterError("outer"))
     with
      | InnerError(str) -> printfn "Error1 %s" str
   finally
      printfn "Always print this."
      
      
let function2 x y =
  try
     function1 x y
  with
     | OuterError(str) -> printfn "Error2 %s" str
     
function2 100 100
function2 100 10