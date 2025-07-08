module nullorempty1.fs
open System
open System.Globalization

let testForIsNullOrEmpty () =
    let str = ""
    // <Snippet1>
    if str = null || str.Equals String.Empty then
    // </Snippet1>
        printfn "Bad string!"
    else
        printfn "Good string!"

let testForIsNullOrEmptyOrWhitespaceOnly () =
    let str: string = null
    // <Snippet2>
    if str = null || str.Equals String.Empty || str.Trim().Equals String.Empty then
    // </Snippet2>
        printfn "Bad string!"
    else
        printfn "Good string!"

type Temperature(temp: double) =
    override this.ToString() =
        (this :> IFormattable).ToString("G", CultureInfo.CurrentCulture :> IFormatProvider)
    
    member this.ToString(format) =
        (this :> IFormattable).ToString(format, CultureInfo.CurrentCulture)

    interface IFormattable with
        // <Snippet3>
        member _.ToString(format: string, provider: IFormatProvider) =
            let format = 
                if String.IsNullOrEmpty format then "G" else format
            
            let provider: IFormatProvider = 
                if provider = null then CultureInfo.CurrentCulture else provider

            match format.ToUpperInvariant() with
            // Return degrees in Celsius.
            | "G"
            | "C" ->
                temp.ToString("F2", provider) + "°C"
            // Return degrees in Fahrenheit.
            | "F" ->
                (temp * 9. / 5. + 32.).ToString("F2", provider) + "°F"
            // Return degrees in Kelvin.
            | "K" ->
                (temp + 273.15).ToString()
            | _ ->
                raise (FormatException(String.Format("The {0} format string is not supported.",format)))
        // </Snippet3>


testForIsNullOrEmpty ()
printfn "-----" 
testForIsNullOrEmptyOrWhitespaceOnly ()
