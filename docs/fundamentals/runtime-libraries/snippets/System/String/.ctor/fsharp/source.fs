module source

open System
open System.Text

do
//<snippet1>
    // Unicode Mathematical operators
    let charArr1 = [| '\u2200'; '\u2202'; '\u200F'; '\u2205' |]
    let szMathSymbols = String charArr1

    // Unicode Letterlike Symbols
    let charArr2 = [| '\u2111'; '\u2118'; '\u2122'; '\u2126' |]
    let szLetterLike = String charArr2

    // Compare Strings - the result is false
    printfn $"The Strings are equal? %b{String.Compare(szMathSymbols, szLetterLike) = 0}"
//</snippet1>
//<snippet2>
    // Null terminated ASCII characters in an sbyte array
    let szAsciiUpper =
        let sbArr1 = [| 0x41y; 0x42y; 0x43y; 0x00y |]
        // Instruct the Garbage Collector not to move the memory
        use pAsciiUpper = fixed sbArr1
        String pAsciiUpper

    let szAsciiLower =
        let sbArr2 = [| 0x61y; 0x62y; 0x63y; 0x00y |]
        // Instruct the Garbage Collector not to move the memory
        use pAsciiLower = fixed sbArr2 
        String(pAsciiLower, 0, sbArr2.Length)

    // Prints "ABC abc"
    printfn $"{szAsciiUpper} {szAsciiLower}"

    // Compare Strings - the result is true
    printfn $"The Strings are equal when capitalized ? %b{String.Compare(szAsciiUpper.ToUpper(), szAsciiLower.ToUpper()) = 0}"

    // This is the effective equivalent of another Compare method, which ignores case
    printfn $"The Strings are equal when capitalized ? %b{String.Compare(szAsciiUpper, szAsciiLower, true) = 0}"
//</snippet2>
//<snippet3>
    // Create a Unicode String with 5 Greek Alpha characters
    let szGreekAlpha = String('\u0391',5)
    // Create a Unicode String with a Greek Omega character
    let szGreekOmega = String([| '\u03A9'; '\u03A9'; '\u03A9' |],2,1)

    let szGreekLetters = String.Concat(szGreekOmega, szGreekAlpha, szGreekOmega.Clone())

    // Examine the result
    printfn $"{szGreekLetters}"

    // The first index of Alpha
    let ialpha = szGreekLetters.IndexOf '\u0391'
    // The last index of Omega
    let iomega = szGreekLetters.LastIndexOf '\u03A9'

    printfn $"The Greek letter Alpha first appears at index {ialpha} and Omega last appears at index {iomega} in this String."
//</snippet3>

//<snippet4>
    let utfeightstring = 
        let asciiChars = [| 0x51y; 0x52y; 0x53y; 0x54y; 0x54y; 0x56y |]
        let encoding = UTF8Encoding(true, true)

        // Instruct the Garbage Collector not to move the memory
        use pAsciiChars = fixed asciiChars
        String(pAsciiChars,0,asciiChars.Length,encoding)
    printfn $"The UTF8 String is {utfeightstring}" // prints "QRSTTV"
//</snippet4>