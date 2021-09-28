' Visual Basic .NET Document
Option Strict On

' <Snippet19>
Module Example
    Public Sub Main()
        Dim str1 As String = "Aa"
        Dim str2 As String = "A" + New String(Convert.ToChar(0), 3) + "a"
        Console.WriteLine("Comparing '{0}' ({1}) and '{2}' ({3}):", _
                          str1, ShowBytes(str1), str2, ShowBytes(str2))
        Console.WriteLine("   With String.Compare:")
        Console.WriteLine("      Current Culture: {0}", _
                          String.Compare(str1, str2, StringComparison.CurrentCulture))
        Console.WriteLine("      Invariant Culture: {0}", _
                          String.Compare(str1, str2, StringComparison.InvariantCulture))

        Console.WriteLine("   With String.Equals:")
        Console.WriteLine("      Current Culture: {0}", _
                          String.Equals(str1, str2, StringComparison.CurrentCulture))
        Console.WriteLine("      Invariant Culture: {0}", _
                          String.Equals(str1, str2, StringComparison.InvariantCulture))
    End Sub

    Private Function ShowBytes(str As String) As String
        Dim hexString As String = String.Empty
        For ctr As Integer = 0 To str.Length - 1
            Dim result As String = String.Empty
            result = Convert.ToInt32(str.Chars(ctr)).ToString("X4")
            result = " " + result.Substring(0, 2) + " " + result.Substring(2, 2)
            hexString += result
        Next
        Return hexString.Trim()
    End Function
End Module
' </Snippet19>
