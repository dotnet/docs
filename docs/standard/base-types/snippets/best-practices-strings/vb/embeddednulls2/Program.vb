Module Program
    Sub Main()
        Dim str1 As String = "Aa"
        Dim str2 As String = "A" & New String(Convert.ToChar(0), 3) & "a"

        Console.WriteLine($"Comparing '{str1}' ({ShowBytes(str1)}) and '{str2}' ({ShowBytes(str2)}):")
        Console.WriteLine("   With String.Compare:")
        Console.WriteLine($"      Ordinal: {String.Compare(str1, str2, StringComparison.Ordinal)}")
        Console.WriteLine("   With String.Equals:")
        Console.WriteLine($"      Ordinal: {String.Equals(str1, str2, StringComparison.Ordinal)}")
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
    '    Comparing 'Aa' (00 41 00 61) and 'A   a' (00 41 00 00 00 00 00 00 00 61):
    '       With String.Compare:
    '          Ordinal: 97
    '       With String.Equals:
    '          Ordinal: False
End Module
