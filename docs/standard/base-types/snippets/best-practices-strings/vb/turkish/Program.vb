'<main>
Imports System.Globalization
Imports System.Threading

Module Program
    Sub Main()
        Dim name As String = "Bill"

        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")
        Console.WriteLine($"Culture = {Thread.CurrentThread.CurrentCulture.DisplayName}")
        Console.WriteLine($"   Is 'Bill' the same as 'BILL'? {name.Equals("BILL", StringComparison.OrdinalIgnoreCase)}")
        Console.WriteLine($"   Does 'Bill' start with 'BILL'? {name.StartsWith("BILL", True, Nothing)}")
        Console.WriteLine()

        Thread.CurrentThread.CurrentCulture = New CultureInfo("tr-TR")
        Console.WriteLine($"Culture = {Thread.CurrentThread.CurrentCulture.DisplayName}")
        Console.WriteLine($"   Is 'Bill' the same as 'BILL'? {name.Equals("BILL", StringComparison.OrdinalIgnoreCase)}")
        Console.WriteLine($"   Does 'Bill' start with 'BILL'? {name.StartsWith("BILL", True, Nothing)}")
    End Sub

End Module

' The example displays the following output:
'
'     Culture = English (United States)
'        Is 'Bill' the same as 'BILL'? True
'        Does 'Bill' start with 'BILL'? True
'     
'     Culture = Turkish (Turkey)
'        Is 'Bill' the same as 'BILL'? True
'        Does 'Bill' start with 'BILL'? False
'</main>

Class Example2
    '<culture_sensitive>
    Public Shared Function IsFileURI(path As String) As Boolean
        Return path.StartsWith("FILE:", True, Nothing)
    End Function
    '</culture_sensitive>
End Class

Class Example3
    '<ordinal>
    Public Shared Function IsFileURI(path As String) As Boolean
        Return path.StartsWith("FILE:", StringComparison.OrdinalIgnoreCase)
    End Function
    '</ordinal>
End Class
