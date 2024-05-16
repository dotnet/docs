string strA = "Владимир";
string strB = "ВЛАДИМИР";

// <OrdinalIgnoreCase>
string.Compare(strA, strB, StringComparison.OrdinalIgnoreCase);
// </OrdinalIgnoreCase>
Console.WriteLine(string.Compare(strA, strB, StringComparison.OrdinalIgnoreCase));

// <Ordinal>
string.Compare(strA.ToUpperInvariant(), strB.ToUpperInvariant(), StringComparison.Ordinal);
// </Ordinal>
Console.WriteLine(string.Compare(strA.ToUpperInvariant(), strB.ToUpperInvariant(), StringComparison.Ordinal));
