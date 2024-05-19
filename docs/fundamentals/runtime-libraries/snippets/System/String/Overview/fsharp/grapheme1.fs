module grapheme1.fs
// <Snippet2>
open System
open System.IO

do
    use sw = new StreamWriter(@".\graphemes.txt")
    let grapheme = "\u0061\u0308"
    sw.WriteLine grapheme

    let singleChar = "\u00e4"
    sw.WriteLine singleChar

    sw.WriteLine("{0} = {1} (Culture-sensitive): {2}", grapheme, singleChar, 
                String.Equals(grapheme, singleChar,
                                StringComparison.CurrentCulture))
    sw.WriteLine("{0} = {1} (Ordinal): {2}", grapheme, singleChar,
                String.Equals(grapheme, singleChar,
                                StringComparison.Ordinal))
    sw.WriteLine("{0} = {1} (Normalized Ordinal): {2}", grapheme, singleChar,
                String.Equals(grapheme.Normalize(),
                                singleChar.Normalize(),
                                StringComparison.Ordinal))
// The example produces the following output:
//       ä
//       ä
//       ä = ä (Culture-sensitive): True
//       ä = ä (Ordinal): False
//       ä = ä (Normalized Ordinal): True
// </Snippet2>
