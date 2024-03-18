// dump a range of Unicode characters as a 16x16 array
// <Snippet4>
module DisplayChars

open System
open System.IO
open System.Globalization
open System.Text

type uint = uint32

let inline roundDownToMultipleOf b u = u - (u % b)

let inline roundUpToMultipleOf b u = roundDownToMultipleOf b u |> (+) b

let displayRange (start: uint) (``end``: uint) =

    let upperRange = 0x10FFFFu
    let surrogateStart = 0xD800u
    let surrogateEnd = 0xDFFFu

    let start, ``end`` =
        if ``end`` <= start then ``end``, start
        else start, ``end``

    // Check whether the start or end range is outside of last plane.
    if start > upperRange then
        invalidArg "start"
            (String.Format("0x{0:X5} is outside the upper range of Unicode code points (0x{1:X5})", start, upperRange))
    if ``end`` > upperRange then
        invalidArg "end"
            (String.Format("0x{0:X5} is outside the upper range of Unicode code points (0x{0:X5})", ``end``, upperRange))

    // Since we're using 21-bit code points, we can't use U+D800 to U+DFFF.
    if (start < surrogateStart && ``end`` > surrogateStart) || (start >= surrogateStart && start <= surrogateEnd) then
        raise
            (ArgumentException
                (String.Format
                    ("0x{0:X5}-0x{1:X5} includes the surrogate pair range 0x{2:X5}-0x{3:X5}", start, ``end``,
                     surrogateStart, surrogateEnd)))
    let last = roundUpToMultipleOf 0x10u ``end``
    let first = roundDownToMultipleOf 0x10u start

    let rows = (last - first) / 0x10u

    for r in 0u .. (rows - 1u) do
        // Display the row header.
        printf "%05x " (first + 0x10u * r)

        for c in 0u .. (0x10u - 1u) do
            let cur = (first + 0x10u * r + c)
            if cur < start || ``end`` < cur then
                printf " %c " (Convert.ToChar 0x20)
            else
                // the cast to int is safe, since we know that val <= upperRange.
                let chars = Char.ConvertFromUtf32(int cur)
                // Display a space for code points that are not valid characters.
                if CharUnicodeInfo.GetUnicodeCategory(chars[0]) = UnicodeCategory.OtherNotAssigned then
                    printf " %c " (Convert.ToChar 0x20)
                else
                    // Display a space for code points in the private use area.
                    if CharUnicodeInfo.GetUnicodeCategory(chars[0]) = UnicodeCategory.PrivateUse then
                        printf " %c " (Convert.ToChar 0x20)
                    else if chars.Length > 1
                            && CharUnicodeInfo.GetUnicodeCategory(chars, 0) = UnicodeCategory.OtherNotAssigned then
                        printf " %c " (Convert.ToChar 0x20)
                    else printf " %s " chars

            match c with
            | 3u
            | 11u -> printf "-"
            | 7u -> printf "--"
            | _ -> ()

        Console.WriteLine()
        if (0u < r && r % 0x10u = 0u) then Console.WriteLine()



[<EntryPoint>]
let main args =
    // Get the current encoding so we can restore it.
    let originalOutputEncoding = Console.OutputEncoding

    try
        try
            let parsedArgs =
                match args.Length with
                | 2 ->
                    Some
                        {| setOutputEncodingToUnicode = true
                           rangeStart = uint.Parse(args[0], NumberStyles.HexNumber)
                           rangeEnd = uint.Parse(args[1], NumberStyles.HexNumber) |}
                | 3 ->
                    let parseHexNumberOrThrow (value: string) parameterName =
                        (uint.TryParse(value, NumberStyles.HexNumber, null))
                        |> function
                        | (false, _) ->
                            invalidArg parameterName (String.Format("{0} is not a valid hexadecimal number.", value))
                        | (true, value) -> value

                    let setOutputEncodingToUnicode =
                        match bool.TryParse args[2] with
                        | true, value -> value
                        | false, _ -> true

                    Some
                        {| setOutputEncodingToUnicode = setOutputEncodingToUnicode
                           rangeStart = parseHexNumberOrThrow args[0] "rangeStart"
                           rangeEnd = parseHexNumberOrThrow args[1] "rangeEnd" |}
                | _ ->
                    printfn "Usage: %s <%s> <%s> [%s]" (Environment.GetCommandLineArgs()[0]) "startingCodePointInHex"
                        "endingCodePointInHex" "<setOutputEncodingToUnicode?{true|false, default:false}>"
                    None

            match parsedArgs with
            | None -> ()
            | Some parsedArgs ->
                if parsedArgs.setOutputEncodingToUnicode then
                    // This won't work before .NET Framework 4.5.
                    try
                        // Set encoding using endianness of this system.
                        // We're interested in displaying individual Char objects, so
                        // we don't want a Unicode BOM or exceptions to be thrown on
                        // invalid Char values.
                        Console.OutputEncoding <- UnicodeEncoding(not BitConverter.IsLittleEndian, false)
                        printfn "\nOutput encoding set to UTF-16"

                    with :? IOException ->
                        printfn "Output encoding set to UTF-8"
                        Console.OutputEncoding <- UTF8Encoding()
                else
                    printfn "The console encoding is %s (code page %i)" (Console.OutputEncoding.EncodingName)
                        (Console.OutputEncoding.CodePage)

                displayRange parsedArgs.rangeStart parsedArgs.rangeEnd
        with :? ArgumentException as ex -> Console.WriteLine(ex.Message)
    finally
        // Restore console environment.
        Console.OutputEncoding <- originalOutputEncoding
    0

// If the example is run with the command line
//       DisplayChars 0400 04FF true
// the example displays the Cyrillic character set as follows:
//       Output encoding set to UTF-16
//       00400  Ѐ  Ё  Ђ  Ѓ - Є  Ѕ  І  Ї -- Ј  Љ  Њ  Ћ - Ќ  Ѝ  Ў  Џ
//       00410  А  Б  В  Г - Д  Е  Ж  З -- И  Й  К  Л - М  Н  О  П
//       00420  Р  С  Т  У - Ф  Х  Ц  Ч -- Ш  Щ  Ъ  Ы - Ь  Э  Ю  Я
//       00430  а  б  в  г - д  е  ж  з -- и  й  к  л - м  н  о  п
//       00440  р  с  т  у - ф  х  ц  ч -- ш  щ  ъ  ы - ь  э  ю  я
//       00450  ѐ  ё  ђ  ѓ - є  ѕ  і  ї -- ј  љ  њ  ћ - ќ  ѝ  ў  џ
//       00460  Ѡ  ѡ  Ѣ  ѣ - Ѥ  ѥ  Ѧ  ѧ -- Ѩ  ѩ  Ѫ  ѫ - Ѭ  ѭ  Ѯ  ѯ
//       00470  Ѱ  ѱ  Ѳ  ѳ - Ѵ  ѵ  Ѷ  ѷ -- Ѹ  ѹ  Ѻ  ѻ - Ѽ  ѽ  Ѿ  ѿ
//       00480  Ҁ  ҁ  ҂  ҃ - ҄  ҅  ҆  ҇ -- ҈  ҉  Ҋ  ҋ - Ҍ  ҍ  Ҏ  ҏ
//       00490  Ґ  ґ  Ғ  ғ - Ҕ  ҕ  Җ  җ -- Ҙ  ҙ  Қ  қ - Ҝ  ҝ  Ҟ  ҟ
//       004a0  Ҡ  ҡ  Ң  ң - Ҥ  ҥ  Ҧ  ҧ -- Ҩ  ҩ  Ҫ  ҫ - Ҭ  ҭ  Ү  ү
//       004b0  Ұ  ұ  Ҳ  ҳ - Ҵ  ҵ  Ҷ  ҷ -- Ҹ  ҹ  Һ  һ - Ҽ  ҽ  Ҿ  ҿ
//       004c0  Ӏ  Ӂ  ӂ  Ӄ - ӄ  Ӆ  ӆ  Ӈ -- ӈ  Ӊ  ӊ  Ӌ - ӌ  Ӎ  ӎ  ӏ
//       004d0  Ӑ  ӑ  Ӓ  ӓ - Ӕ  ӕ  Ӗ  ӗ -- Ә  ә  Ӛ  ӛ - Ӝ  ӝ  Ӟ  ӟ
//       004e0  Ӡ  ӡ  Ӣ  ӣ - Ӥ  ӥ  Ӧ  ӧ -- Ө  ө  Ӫ  ӫ - Ӭ  ӭ  Ӯ  ӯ
//       004f0  Ӱ  ӱ  Ӳ  ӳ - Ӵ  ӵ  Ӷ  ӷ -- Ӹ  ӹ  Ӻ  ӻ - Ӽ  ӽ  Ӿ  ӿ
// </Snippet4>
