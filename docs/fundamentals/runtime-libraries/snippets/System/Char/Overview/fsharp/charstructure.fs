// <snippet23>
open System

let chA = 'A'
let ch1 = '1'
let str = "test string"

printfn $"{chA.CompareTo 'B'}"          //-----------  Output: "-1" (meaning 'A' is 1 less than 'B')
printfn $"{chA.Equals 'A'}"             //-----------  Output: "True"
printfn $"{Char.GetNumericValue ch1}"   //-----------  Output: "1"
printfn $"{Char.IsControl '\t'}"        //-----------  Output: "True"
printfn $"{Char.IsDigit ch1}"           //-----------  Output: "True"
printfn $"{Char.IsLetter ','}"          //-----------  Output: "False"
printfn $"{Char.IsLower 'u'}"           //-----------  Output: "True"
printfn $"{Char.IsNumber ch1}"          //-----------  Output: "True"
printfn $"{Char.IsPunctuation '.'}"     //-----------  Output: "True"
printfn $"{Char.IsSeparator(str, 4)}"   //-----------  Output: "True"
printfn $"{Char.IsSymbol '+'}"          //-----------  Output: "True"
printfn $"{Char.IsWhiteSpace(str, 4)}"  //-----------  Output: "True"
printfn $"""{Char.Parse "S"}"""         //-----------  Output: "S"
printfn $"{Char.ToLower 'M'}"           //-----------  Output: "m"
printfn $"{'x'}"                        //-----------  Output: "x"
// </snippet23>