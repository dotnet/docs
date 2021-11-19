type NumberStrings() =
   let mutable ordinals = [| "one"; "two"; "three"; "four"; "five";
                             "six"; "seven"; "eight"; "nine"; "ten" |]
   let mutable cardinals = [| "first"; "second"; "third"; "fourth";
                              "fifth"; "sixth"; "seventh"; "eighth";
                              "ninth"; "tenth" |]
   member this.Item
      with get(index) = ordinals[index]
      and set index value = ordinals[index] <- value
   member this.Ordinal
      with get(index) = ordinals[index]
      and set index value = ordinals[index] <- value
   member this.Cardinal
      with get(index) = cardinals[index]
      and set index value = cardinals[index] <- value

let nstrs = new NumberStrings()
nstrs[0] <- "ONE"
for i in 0 .. 9 do
  printf "%s " nstrs[i]
printfn ""

nstrs.Cardinal(5) <- "6th"

for i in 0 .. 9 do
  printf "%s " (nstrs.Ordinal(i))
  printf "%s " (nstrs.Cardinal(i))
printfn ""