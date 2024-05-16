let err = 1.e-10

let isNearlyIntegral (x:float) = abs (x - round(x)) < err

let (|Square|_|) (x : int) =
  if isNearlyIntegral (sqrt (float x)) then Some(x)
  else None

let (|Cube|_|) (x : int) =
  if isNearlyIntegral ((float x) ** ( 1.0 / 3.0)) then Some(x)
  else None

let findSquareCubes x =
   match x with
   | Cube x & Square _ -> printfn "%d is a cube and a square" x
   | Cube x -> printfn "%d is a cube" x
   | _ -> ()
   

[ 1 .. 1000 ] |> List.iter (fun elem -> findSquareCubes elem)
