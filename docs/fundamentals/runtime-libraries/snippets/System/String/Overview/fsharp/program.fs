module program.fs
#nowarn "9"
open System
let instantiateByAssignment () =
    // <Snippet1>
    let string1 = "This is a string created by assignment."
    printfn "%s" string1
    let string2a = "The path is C:\\PublicDocuments\\Report1.doc"
    printfn "%s" string2a
    let string2b = @"The path is C:\PublicDocuments\Report1.doc"
    printfn "%s" string2b
    // The example displays the following output:
    //       This is a string created by assignment.
    //       The path is C:\PublicDocuments\Report1.doc
    //       The path is C:\PublicDocuments\Report1.doc
    // </Snippet1>

let callConstructors () =
    // <Snippet2>
    let chars = [| 'w'; 'o'; 'r'; 'd' |]
    let bytes = [| 0x41y; 0x42y; 0x43y; 0x44y; 0x45y; 0x00y |]

    // Create a string from a character array.
    let string1 = String chars
    printfn "%s" string1

    // Create a string that consists of a character repeated 20 times.
    let string2 = String('c', 20)
    printfn "%s" string2

    let stringFromBytes =
        // Create a string from a pointer to a signed byte array.
        use pbytes = fixed bytes
        String pbytes
    let stringFromChars = 
        // Create a string from a pointer to a character array.
        use pchars = fixed chars
        String pchars

    printfn $"{stringFromBytes}"
    printfn $"{stringFromChars}"
    // The example displays the following output:
    //       word
    //       cccccccccccccccccccc
    //       ABCDE
    //       word
    // </Snippet2>

let concatenate () =
    // <Snippet3>
    let string1 = "Today is " + DateTime.Now.ToString("D") + "."
    printfn $"{string1}"

    let string2 = "This is one sentence. " + "This is a second. "
    let string2 = string2 + "This is a third sentence."
    printfn $"{string2}"
    // The example displays output like the following:
    //    Today is Tuesday, July 06, 2011.
    //    This is one sentence. This is a second. This is a third sentence.
    // </Snippet3>

let extractString () =
    // <Snippet4>
    let sentence = "This sentence has five words."
    // Extract the second word.
    let startPosition = sentence.IndexOf " " + 1
    let word2 = 
        sentence.Substring(startPosition, sentence.IndexOf(" ", startPosition) - startPosition)
    printfn $"Second word: {word2}"
    // The example displays the following output:
    //       Second word: sentence
    // </Snippet4>

let formatting () =
    // <Snippet5>
    let dateAndTime = DateTime(2011, 7, 6, 7, 32, 0)
    let temperature = 68.3
    String.Format("At {0:t} on {0:D}, the temperature was {1:F1} degrees Fahrenheit.", dateAndTime, temperature)
    |> printfn "%s"
    // The example displays the following output:
    //       At 7:32 AM on Wednesday, July 06, 2011, the temperature was 68.3 degrees Fahrenheit.
    // </Snippet5>

instantiateByAssignment ()
printfn "-----"
callConstructors ()
printfn "-----"
concatenate ()
printfn "-----"
extractString ()
printfn "-----"
formatting ()
