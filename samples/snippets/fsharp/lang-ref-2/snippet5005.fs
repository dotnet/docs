let err = 1.e-10

let isNearlyIntegral (x:float) = abs (x - round(x)) < err

let (|Square|_|) (x : int) =
  if isNearlyIntegral (sqrt (float x)) then Some(x)
  else None

let (|Cube|_|) (x : int) =
  if isNearlyIntegral ((float x) ** ( 1.0 / 3.0)) then Some(x)
  else None

let examineNumber x =
   match x with
      | Cube x -> printfn "%d is a cube" x
      | _ -> ()
   match x with
      | Square x -> printfn "%d is a square" x
      | _ -> ()

let findSquareCubes x =
   if (match x with
       | Cube x -> true
       | _ -> false
       &&
       match x with
       | Square x -> true
       | _ -> false
      )
   then printf "%d \n" x

[ 1 .. 1000000 ] |> List.iter (fun elem -> findSquareCubes elem)