module tostringoverload1

// <Snippet4>
open System

type Automobile(model: string, year: int, doors: int, cylinders: string) =
    member _.Doors = doors
    member _.Model = model
    member _.Year = year
    member _.Cylinders = cylinders

    override this.ToString() =
        this.ToString "G"

    member _.ToString(fmt) =
        let fmt = 
            if String.IsNullOrEmpty fmt then "G"
            else fmt.ToUpperInvariant()

        match fmt with
        | "G" ->
            $"{year} {model}"
        | "D" ->
            $"{year} {model}, {doors} dr."
        | "C" ->
            $"{year} {model}, {cylinders}"
        | "A" ->
            $"{year} {model}, {doors} dr. {cylinders}"
        | _ ->
            raise (ArgumentException $"'{fmt}' is an invalid format string")

let auto = Automobile("Lynx", 2016, 4, "V8")
printfn $"{auto}"
printfn $"""{auto.ToString "A"}"""
// The example displays the following output:
//       2016 Lynx
//       2016 Lynx, 4 dr. V8
// </Snippet4>