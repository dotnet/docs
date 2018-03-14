
'<snippet1>
Imports System
Imports System.Runtime.CompilerServices



<Assembly: SuppressIldasmAttribute()> 


Class Program

    Shared Sub Main(ByVal args() As String)
        Console.WriteLine("The SuppressIldasmAttribute is applied to this assembly.")

    End Sub
End Class

'</snippet1>