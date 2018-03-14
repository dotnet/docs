//<snippet1>
using System;
using System.Globalization;

class Sample {
    public static void Main() {
    String str1 = "change";
    String str2 = "dollar";
    String relation = null;

    relation = symbol( String.Compare(str1, str2, false, new CultureInfo("en-US")) );
    Console.WriteLine("For en-US: {0} {1} {2}", str1, relation, str2);

    relation = symbol( String.Compare(str1, str2, false, new CultureInfo("cs-CZ")) );
    Console.WriteLine("For cs-CZ: {0} {1} {2}", str1, relation, str2);
    }

    private static String symbol(int r) {
    String s = "=";
    if      (r < 0) s = "<";
    else if (r > 0) s = ">";
    return s;
    }
}
/*
This example produces the following results.
For en-US: change < dollar
For cs-CZ: change > dollar
*/
//</snippet1>