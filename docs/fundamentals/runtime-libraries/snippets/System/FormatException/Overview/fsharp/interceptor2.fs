module interceptor2

// <Snippet11>
open System
open System.Globalization

type InterceptProvider() =
    interface IFormatProvider with
        member this.GetFormat(formatType) =
            if formatType = typeof<ICustomFormatter> then
                this
            else
                null
    interface ICustomFormatter with
        member _.Format(format, obj, provider: IFormatProvider) = 
            // Display information about method call.
            let formatString =
                if format = null then "<null>" else format
            printfn $"Provider: {provider.GetType().Name}, Object: %A{obj}, Format String: %s{formatString}"
                                
            if obj = null then
                String.Empty
            else
                // If this is a byte and the "R" format string, format it with Roman numerals.
                match obj with
                | :? byte as value when formatString.ToUpper().Equals "R" -> 
                    let mutable returnString = String.Empty

                    // Get the hundreds digit(s)
                    let struct (result, remainder) = Math.DivRem(value, 100uy)
                    if result > 0uy then
                        returnString <- String('C', int result)
                    let value = byte remainder
                    // Get the 50s digit
                    let struct (result, remainder) = Math.DivRem(value, 50uy)
                    if result = 1uy then
                        returnString <- returnString + "L"
                    let value = byte remainder
                    // Get the tens digit.
                    let struct (result, remainder) = Math.DivRem(value, 10uy)
                    if result > 0uy then
                        returnString <- returnString + String('X', int result)
                    let value = byte remainder 
                    // Get the fives digit.
                    let struct (result, remainder) = Math.DivRem(value, 5uy)
                    if result > 0uy then
                        returnString <- returnString + "V"
                    let value = byte remainder
                    // Add the ones digit.
                    if remainder > 0uy then 
                        returnString <- returnString + String('I', int remainder)
                    
                    // Check whether we have too many X characters.
                    let pos = returnString.IndexOf "XXXX"
                    if pos >= 0 then
                        let xPos = returnString.IndexOf "L" 
                        returnString <-
                            if xPos >= 0 && xPos = pos - 1 then
                                returnString.Replace("LXXXX", "XC")
                            else
                                returnString.Replace("XXXX", "XL")   
                    // Check whether we have too many I characters
                    let pos = returnString.IndexOf "IIII"
                    if pos >= 0 then
                        returnString <-
                            if returnString.IndexOf "V" >= 0 then
                                returnString.Replace("VIIII", "IX")
                            else
                                returnString.Replace("IIII", "IV")    
                    returnString 

                // Use default for all other formatting.
                | :? IFormattable as x ->
                    x.ToString(format, CultureInfo.CurrentCulture)
                | _ ->
                    string obj

let n = 10
let value = 16.935
let day = DateTime.Now
let provider = InterceptProvider()
String.Format(provider, "{0:N0}: {1:C2} on {2:d}\n", n, value, day)
|> printfn "%s"
String.Format(provider, "{0}: {1:F}\n", "Today: ", DateTime.Now.DayOfWeek)
|> printfn "%s"
String.Format(provider, "{0:X}, {1}, {2}\n", 2uy, 12uy, 199uy)
|> printfn "%s"
String.Format(provider, "{0:R}, {1:R}, {2:R}\n", 2uy, 12uy, 199uy)
|> printfn "%s"
// The example displays the following output:
//    Provider: InterceptProvider, Object: 10, Format String: N0
//    Provider: InterceptProvider, Object: 16.935, Format String: C2
//    Provider: InterceptProvider, Object: 1/31/2013 6:10:28 PM, Format String: d
//    10: $16.94 on 1/31/2013
//    
//    Provider: InterceptProvider, Object: Today: , Format String: <null>
//    Provider: InterceptProvider, Object: Thursday, Format String: F
//    Today: : Thursday
//    
//    Provider: InterceptProvider, Object: 2, Format String: X
//    Provider: InterceptProvider, Object: 12, Format String: <null>
//    Provider: InterceptProvider, Object: 199, Format String: <null>
//    2, 12, 199
//    
//    Provider: InterceptProvider, Object: 2, Format String: R
//    Provider: InterceptProvider, Object: 12, Format String: R
//    Provider: InterceptProvider, Object: 199, Format String: R
//    II, XII, CXCIX
// </Snippet11>