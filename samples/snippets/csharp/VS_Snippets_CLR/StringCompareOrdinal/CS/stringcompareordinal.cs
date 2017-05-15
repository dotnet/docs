//<Snippet1>
using System;
using System.Globalization;

class Test 
{
	public static void Main(String[] args) 
	{
	String strLow = "abc";
	String strCap = "ABC";
	String result = "equal to ";
	int x = 0;
	int pos = 1;

// The Unicode codepoint for 'b' is greater than the codepoint for 'B'.
	x = String.CompareOrdinal(strLow, pos, strCap, pos, 1);
	if (x < 0) result = "less than";
	if (x > 0) result = "greater than";
	Console.WriteLine("CompareOrdinal(\"{0}\"[{2}], \"{1}\"[{2}]):", strLow, strCap, pos);
	Console.WriteLine("   '{0}' is {1} '{2}'", strLow[pos], result, strCap[pos]);

// In U.S. English culture, 'b' is linguistically less than 'B'.
	x = String.Compare(strLow, pos, strCap, pos, 1, false, new CultureInfo("en-US"));
	if (x < 0) result = "less than";
	else if (x > 0) result = "greater than";
	Console.WriteLine("Compare(\"{0}\"[{2}], \"{1}\"[{2}]):", strLow, strCap, pos);
	Console.WriteLine("   '{0}' is {1} '{2}'", strLow[pos], result, strCap[pos]);
	}
}
//</Snippet1>	