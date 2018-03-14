// <Snippet1>
using System;
using System.Text;

class UnicodeEncodingExample {
    public static void Main() {

        // Create a UnicodeEncoding without parameters.
        UnicodeEncoding unicode = new UnicodeEncoding();

        // Create a UnicodeEncoding to support little-endian byte ordering
        // and include the Unicode byte order mark.
        UnicodeEncoding unicodeLittleEndianBOM = 
            new UnicodeEncoding(false, true);
        // Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
        DescribeEquivalence(unicode.Equals(unicodeLittleEndianBOM));

        // Create a UnicodeEncoding to support little-endian byte ordering
        // and not include the Unicode byte order mark.
        UnicodeEncoding unicodeLittleEndianNoBOM =
            new UnicodeEncoding(false, false);
        // Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
        DescribeEquivalence(unicode.Equals(unicodeLittleEndianNoBOM));

        // Create a UnicodeEncoding to support big-endian byte ordering
        // and include the Unicode byte order mark.
        UnicodeEncoding unicodeBigEndianBOM =
            new UnicodeEncoding(true, true);
        // Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
        DescribeEquivalence(unicode.Equals(unicodeBigEndianBOM));

        // Create a UnicodeEncoding to support big-endian byte ordering
        // and not include the Unicode byte order mark.
        UnicodeEncoding unicodeBigEndianNoBOM =
            new UnicodeEncoding(true, false);
        // Compare this UnicodeEncoding to the UnicodeEncoding without parameters.
        DescribeEquivalence(unicode.Equals(unicodeBigEndianNoBOM));
    }

    public static void DescribeEquivalence(Boolean isEquivalent) {
        Console.WriteLine(
            "{0} equivalent encoding.", (isEquivalent ? "An" : "Not an")
        );
    }
}
// </Snippet1>
