//<snippet1>
using System;

public class ReplaceTest {
    public static void Main() {

        string errString = "This docment uses 3 other docments to docment the docmentation";

        Console.WriteLine("The original string is:{0}'{1}'{0}", Environment.NewLine, errString);

        // Correct the spelling of "document".

        string correctString = errString.Replace("docment", "document");

        Console.WriteLine("After correcting the string, the result is:{0}'{1}'",
                Environment.NewLine, correctString);
    }
}
//
// This code example produces the following output:
//
// The original string is:
// 'This docment uses 3 other docments to docment the docmentation'
//
// After correcting the string, the result is:
// 'This document uses 3 other documents to document the documentation'
//
//</snippet1>