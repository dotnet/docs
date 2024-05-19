
Module Program
    Sub Main()
        Dim str1 As String = "Aa"
        Dim str2 As String = "A" & New String(Convert.ToChar(0), 3) & "a"

        Console.WriteLine($"Comparing '{str1}' ({ShowBytes(str1)}) and '{str2}' ({ShowBytes(str2)}):")
        Console.WriteLine("   With String.Compare:")
        Console.WriteLine($"      Current Culture: {String.Compare(str1, str2, StringComparison.CurrentCulture)}")
        Console.WriteLine($"      Invariant Culture: {String.Compare(str1, str2, StringComparison.InvariantCulture)}")
        Console.WriteLine("   With String.Equals:")
        Console.WriteLine($"      Current Culture: {String.Equals(str1, str2, StringComparison.CurrentCulture)}")
        Console.WriteLine($"      Invariant Culture: {String.Equals(str1, str2, StringComparison.InvariantCulture)}")
    End Sub

    Function ShowBytes(str As String) As String
        Dim hexString As String = String.Empty

        For ctr As Integer = 0 To str.Length - 1
            Dim result As String = Convert.ToInt32(str.Chars(ctr)).ToString("X4")
            result = String.Concat(" ", result.Substring(0, 2), " ", result.Substring(2, 2))
            hexString &= result
        Next

        Return hexString.Trim()
    End Function

    ' The example displays the following output:
    '     Comparing 'Aa' (00 41 00 61) and 'Aa' (00 41 00 00 00 00 00 00 00 61):
    '        With String.Compare:
    '           Current Culture: 0
    '           Invariant Culture: 0
    '        With String.Equals:
    '           Current Culture: True
    '           Invariant Culture: True
End Module
