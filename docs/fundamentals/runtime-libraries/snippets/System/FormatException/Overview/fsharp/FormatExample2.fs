module FormatExample2

// <Snippet2>
open System

type CustomerFormatter() = 
    interface IFormatProvider with
        member this.GetFormat(formatType) =
            if formatType = typeof<ICustomFormatter> then
                this
            else
                null

    interface ICustomFormatter with
        member this.Format(format, arg, formatProvider: IFormatProvider) = 
            if this.Equals formatProvider |> not then
                null
            else
                let format = 
                    if String.IsNullOrEmpty format then "G"
                    else format.ToUpper()
                
                let customerString = 
                    let s = string arg
                    if s.Length < 8 then
                        s.PadLeft(8, '0')
                    else s
                
                match format with
                | "G" ->
                    customerString.Substring(0, 1) + "-" +
                        customerString.Substring(1, 5) + "-" +
                        customerString.Substring 6
                | "S" ->                          
                    customerString.Substring(0, 1) + "/" +
                        customerString.Substring(1, 5) + "/" +
                        customerString.Substring 6
                | "P" ->                          
                    customerString.Substring(0, 1) + "." +
                        customerString.Substring(1, 5) + "." +
                        customerString.Substring 6
                | _ ->
                    raise (FormatException $"The '{format}' format specifier is not supported.")

let acctNumber = 79203159
String.Format(CustomerFormatter(), "{0}", acctNumber)
|> printfn "%s"
String.Format(CustomerFormatter(), "{0:G}", acctNumber)
|> printfn "%s"
String.Format(CustomerFormatter(), "{0:S}", acctNumber)
|> printfn "%s"
String.Format(CustomerFormatter(), "{0:P}", acctNumber)
|> printfn "%s"
try
    String.Format(CustomerFormatter(), "{0:X}", acctNumber)
    |> printfn "%s"
with :? FormatException as e ->
    printfn $"{e.Message}"

// The example displays the following output:
//       7-92031-59
//       7-92031-59
//       7/92031/59
//       7.92031.59
//       The 'X' format specifier is not supported.
// </Snippet2>