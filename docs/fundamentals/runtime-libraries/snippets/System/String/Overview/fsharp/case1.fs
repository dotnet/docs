module case1.fs
// <Snippet7>
open System
open System.Globalization
open System.IO

let showHexValue (s: string) =
    let mutable retval = ""
    for ch in s do
        let bytes = BitConverter.GetBytes ch
        retval <- retval + String.Format("{0:X2} {1:X2} ", bytes[1], bytes[0])
    retval

do
    use sw = new StreamWriter(@".\case.txt")
    let words = [| "file"; "sıfır"; "ǅenana" |]
    let cultures = 
        [| CultureInfo.InvariantCulture 
           CultureInfo "en-US"
           CultureInfo "tr-TR" |]

    for word in words do
        sw.WriteLine("{0}:", word)
        for culture in cultures do
            let name =
                 if String.IsNullOrEmpty culture.Name then "Invariant" else culture.Name
            let upperWord = word.ToUpper culture
            sw.WriteLine("   {0,10}: {1,7} {2, 38}", name, upperWord, showHexValue upperWord)
        sw.WriteLine()
    sw.Close()

// The example displays the following output:
//    file:
//        Invariant:    FILE               00 46 00 49 00 4C 00 45
//            en-US:    FILE               00 46 00 49 00 4C 00 45
//            tr-TR:    FİLE               00 46 01 30 00 4C 00 45
//
//    sıfır:
//        Invariant:   SıFıR         00 53 01 31 00 46 01 31 00 52
//            en-US:   SIFIR         00 53 00 49 00 46 00 49 00 52
//            tr-TR:   SIFIR         00 53 00 49 00 46 00 49 00 52
//
//    ǅenana:
//        Invariant:  ǅENANA   01 C5 00 45 00 4E 00 41 00 4E 00 41
//            en-US:  ǄENANA   01 C4 00 45 00 4E 00 41 00 4E 00 41
//            tr-TR:  ǄENANA   01 C4 00 45 00 4E 00 41 00 4E 00 41
// </Snippet7>
