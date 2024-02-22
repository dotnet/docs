string str1 = "Aa";
string str2 = "A" + new string('\u0000', 3) + "a";

Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-us");

Console.WriteLine($"Comparing '{str1}' ({ShowBytes(str1)}) and '{str2}' ({ShowBytes(str2)}):");
Console.WriteLine("   With String.Compare:");
Console.WriteLine($"      Current Culture: {string.Compare(str1, str2, StringComparison.CurrentCulture)}");
Console.WriteLine($"      Invariant Culture: {string.Compare(str1, str2, StringComparison.InvariantCulture)}");
Console.WriteLine("   With String.Equals:");
Console.WriteLine($"      Current Culture: {string.Equals(str1, str2, StringComparison.CurrentCulture)}");
Console.WriteLine($"      Invariant Culture: {string.Equals(str1, str2, StringComparison.InvariantCulture)}");

string ShowBytes(string value)
{
   string hexString = string.Empty;
   for (int index = 0; index < value.Length; index++)
   {
      string result = Convert.ToInt32(value[index]).ToString("X4");
      result = string.Concat(" ", result.Substring(0,2), " ", result.Substring(2, 2));
      hexString += result;
   }
   return hexString.Trim();
}

// The example displays the following output:
//     Comparing 'Aa' (00 41 00 61) and 'Aa' (00 41 00 00 00 00 00 00 00 61):
//        With String.Compare:
//           Current Culture: 0
//           Invariant Culture: 0
//        With String.Equals:
//           Current Culture: True
//           Invariant Culture: True
