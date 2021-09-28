(* warn *)
System.DateTime.Now.ToString() |> printfn "%s"

(* No warn 1 *)
let now = System.DateTime.Now
now.ToString() |> printfn "%s"

(* No warn 2 *)
System.DateTime.Now |> printfn "%A"
