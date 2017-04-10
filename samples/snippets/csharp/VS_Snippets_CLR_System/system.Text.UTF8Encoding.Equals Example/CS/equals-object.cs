// <Snippet1>
using System;
using System.Text;

class UTF8EncodingExample {
    public static void Main() {
        UTF8Encoding utf8 = new UTF8Encoding();
        UTF8Encoding utf8true = new UTF8Encoding(true);
        UTF8Encoding utf8truetrue = new UTF8Encoding(true, true);
        UTF8Encoding utf8falsetrue = new UTF8Encoding(false, true);
        
        DescribeEquivalence(utf8.Equals(utf8));
        DescribeEquivalence(utf8.Equals(utf8true));
        DescribeEquivalence(utf8.Equals(utf8truetrue));
        DescribeEquivalence(utf8.Equals(utf8falsetrue));
        
        DescribeEquivalence(utf8true.Equals(utf8));
        DescribeEquivalence(utf8true.Equals(utf8true));
        DescribeEquivalence(utf8true.Equals(utf8truetrue));
        DescribeEquivalence(utf8true.Equals(utf8falsetrue));
        
        DescribeEquivalence(utf8truetrue.Equals(utf8));
        DescribeEquivalence(utf8truetrue.Equals(utf8true));
        DescribeEquivalence(utf8truetrue.Equals(utf8truetrue));
        DescribeEquivalence(utf8truetrue.Equals(utf8falsetrue));
        
        DescribeEquivalence(utf8falsetrue.Equals(utf8));
        DescribeEquivalence(utf8falsetrue.Equals(utf8true));
        DescribeEquivalence(utf8falsetrue.Equals(utf8truetrue));
        DescribeEquivalence(utf8falsetrue.Equals(utf8falsetrue));
    }

    public static void DescribeEquivalence(Boolean isEquivalent) {
        Console.WriteLine(
            "{0} equivalent encoding.", (isEquivalent ? "An" : "Not an")
        );
    }
}
// </Snippet1>
