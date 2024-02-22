let xRef = ref 10

printfn "%d" xRef.Value

xRef.Value <- 11

printfn "%d" xRef.Value
