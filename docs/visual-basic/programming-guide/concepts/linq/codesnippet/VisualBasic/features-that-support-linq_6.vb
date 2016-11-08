    ' Import System.Runtime.CompilerServices to use the Extension attribute.
    <Extension()>
        Public Sub Print(ByVal str As String)
        Console.WriteLine(str)
    End Sub