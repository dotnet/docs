'<snippet1>
Imports System.Runtime.CompilerServices

<Assembly: StringFreezingAttribute()> 

Module Program

    Dim frozenString = "This is a frozen string after Ngen is run."

    Sub Main(ByVal args() As String)
        Console.WriteLine("The FixedAddressValueTypeAttribute attribute was applied.")
    End Sub


End Module
'</snippet1>