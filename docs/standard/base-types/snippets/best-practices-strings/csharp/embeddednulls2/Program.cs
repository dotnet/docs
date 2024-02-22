string str1 = "Aa";
string str2 = "A" + new String('\u0000', 3) + "a";

Console.WriteLine($"Comparing '{str1}' ({ShowBytes(str1)}) and '{str2}' ({ShowBytes(str2)}):");
Console.WriteLine("   With String.Compare:");
Console.WriteLine($"      Ordinal: {string.Compare(str1, str2, StringComparison.Ordinal)}");
Console.WriteLine("   With String.Equals:");
Console.WriteLine($"      Ordinal: {string.Equals(str1, str2, StringComparison.Ordinal)}");

string ShowBytes(string str)
{
    string hexString = string.Empty;
    for (int ctr = 0; ctr < str.Length; ctr++)
    {
        string result = Convert.ToInt32(str[ctr]).ToString("X4");
        result = " " + result.Substring(0, 2) + " " + result.Substring(2, 2);
        hexString += result;
    }
    return hexString.Trim();
}

// The example displays the following output:
//    Comparing 'Aa' (00 41 00 61) and 'A   a' (00 41 00 00 00 00 00 00 00 61):
//       With String.Compare:
//          Ordinal: 97
//       With String.Equals:
//          Ordinal: False
