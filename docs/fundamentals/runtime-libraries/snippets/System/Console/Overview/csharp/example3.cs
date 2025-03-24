// dump a range of Unicode characters as a 16x16 array
// <Snippet4>
using System;
using System.IO;
using System.Globalization;
using System.Text;

public static class DisplayChars
{
    private static void Main(string[] args)
    {
        uint rangeStart = 0;
        uint rangeEnd = 0;
        bool setOutputEncodingToUnicode = true;
        // Get the current encoding so we can restore it.
        Encoding originalOutputEncoding = Console.OutputEncoding;

        try
        {
            switch (args.Length)
            {
                case 2:
                    rangeStart = uint.Parse(args[0], NumberStyles.HexNumber);
                    rangeEnd = uint.Parse(args[1], NumberStyles.HexNumber);
                    setOutputEncodingToUnicode = true;
                    break;
                case 3:
                    if (!uint.TryParse(args[0], NumberStyles.HexNumber, null, out rangeStart))
                        throw new ArgumentException(string.Format("{0} is not a valid hexadecimal number.", args[0]));

                    if (!uint.TryParse(args[1], NumberStyles.HexNumber, null, out rangeEnd))
                        throw new ArgumentException(string.Format("{0} is not a valid hexadecimal number.", args[1]));

                    _ = bool.TryParse(args[2], out setOutputEncodingToUnicode);
                    break;
                default:
                    Console.WriteLine($"Usage: {Environment.GetCommandLineArgs()[0]} <{"startingCodePointInHex"}> <{"endingCodePointInHex"}> [{"<setOutputEncodingToUnicode?{true|false}]");
                    return;
            }

            if (setOutputEncodingToUnicode)
            {
                try
                {
                    // Set encoding using endianness of this system.
                    // We're interested in displaying individual Char objects, so
                    // we don't want a Unicode BOM or exceptions to be thrown on
                    // invalid Char values.
                    Console.OutputEncoding = new UnicodeEncoding(!BitConverter.IsLittleEndian, false);
                    Console.WriteLine("\nOutput encoding set to UTF-16");
                }
                catch (IOException)
                {
                    Console.OutputEncoding = new UTF8Encoding();
                    Console.WriteLine("Output encoding set to UTF-8");
                }
            }
            else
            {
                Console.WriteLine($"The console encoding is {Console.OutputEncoding.EncodingName} (code page {Console.OutputEncoding.CodePage})");
            }
            DisplayRange(rangeStart, rangeEnd);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // Restore console environment.
            Console.OutputEncoding = originalOutputEncoding;
        }
    }

    public static void DisplayRange(uint start, uint end)
    {
        const uint upperRange = 0x10FFFF;
        const uint surrogateStart = 0xD800;
        const uint surrogateEnd = 0xDFFF;

        if (end <= start)
        {
            uint t = start;
            start = end;
            end = t;
        }

        // Check whether the start or end range is outside of last plane.
        if (start > upperRange)
            throw new ArgumentException(string.Format("0x{0:X5} is outside the upper range of Unicode code points (0x{1:X5})",
                                                      start, upperRange));
        if (end > upperRange)
            throw new ArgumentException(string.Format("0x{0:X5} is outside the upper range of Unicode code points (0x{0:X5})",
                                                      end, upperRange));

        // Since we're using 21-bit code points, we can't use U+D800 to U+DFFF.
        if ((start < surrogateStart & end > surrogateStart) || (start >= surrogateStart & start <= surrogateEnd))
            throw new ArgumentException(string.Format("0x{0:X5}-0x{1:X5} includes the surrogate pair range 0x{2:X5}-0x{3:X5}",
                                                      start, end, surrogateStart, surrogateEnd));
        uint last = RoundUpToMultipleOf(0x10, end);
        uint first = RoundDownToMultipleOf(0x10, start);

        uint rows = (last - first) / 0x10;

        for (uint r = 0; r < rows; ++r)
        {
            // Display the row header.
            Console.Write("{0:x5} ", first + 0x10 * r);

            for (uint c = 0; c < 0x10; ++c)
            {
                uint cur = (first + 0x10 * r + c);
                if (cur < start)
                {
                    Console.Write($" {(char)(0x20)} ");
                }
                else if (end < cur)
                {
                    Console.Write($" {(char)(0x20)} ");
                }
                else
                {
                    // the cast to int is safe, since we know that val <= upperRange.
                    String chars = Char.ConvertFromUtf32((int)cur);
                    // Display a space for code points that are not valid characters.
                    if (CharUnicodeInfo.GetUnicodeCategory(chars[0]) ==
                                                    UnicodeCategory.OtherNotAssigned)
                        Console.Write($" {(char)(0x20)} ");
                    // Display a space for code points in the private use area.
                    else if (CharUnicodeInfo.GetUnicodeCategory(chars[0]) ==
                                                   UnicodeCategory.PrivateUse)
                        Console.Write($" {(char)(0x20)} ");
                    // Is surrogate pair a valid character?
                    // Note that the console will interpret the high and low surrogate
                    // as separate (and unrecognizable) characters.
                    else if (chars.Length > 1 && CharUnicodeInfo.GetUnicodeCategory(chars, 0) ==
                                                 UnicodeCategory.OtherNotAssigned)
                        Console.Write($" {(char)(0x20)} ");
                    else
                        Console.Write($" {chars} ");
                }

                switch (c)
                {
                    case 3:
                    case 11:
                        Console.Write("-");
                        break;
                    case 7:
                        Console.Write("--");
                        break;
                }
            }

            Console.WriteLine();
            if (0 < r && r % 0x10 == 0)
                Console.WriteLine();
        }
    }

    private static uint RoundUpToMultipleOf(uint b, uint u)
    {
        return RoundDownToMultipleOf(b, u) + b;
    }

    private static uint RoundDownToMultipleOf(uint b, uint u)
    {
        return u - (u % b);
    }
}
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
