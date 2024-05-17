module starting1

open System

let snippet31 () =
    // <Snippet31>
    String.Format("At {0}, the temperature is {1}°C.", DateTime.Now, 20.4)
    |> printfn "%s"
    // Output similar to: 'At 4/10/2015 9:29:41 AM, the temperature is 20.4°C.'
    // </Snippet31>
      
let snippet32 () =
    // <Snippet32>
    String.Format("It is now {0:d} at {0:t}", DateTime.Now)
    |> printfn "%s"
    // Output similar to: 'It is now 4/10/2015 at 10:04 AM'
    // </Snippet32>

let snippet34 () =
    // <Snippet34>
    let years = [| 2013; 2014; 2015 |]
    let population = [| 1025632; 1105967; 1148203 |]
    let mutable s = String.Format("{0,-10} {1,-10}\n\n", "Year", "Population")
    for i = 0 to years.Length - 1 do
        s <- s + String.Format("{0,-10} {1,-10:N0}\n", years[i], population[i])
    printfn $"\n{s}"
    // Result:
    //    Year       Population
    //
    //    2013       1,025,632
    //    2014       1,105,967
    //    2015       1,148,203
    // </Snippet34>

// <Snippet30>
let temp = 20.4m
String.Format("The temperature is {0}°C.", temp)
|> printfn "%s"
// Displays 'The temperature is 20.4°C.'
// </Snippet30>

snippet31 ()
snippet32 ()
snippet34 ()