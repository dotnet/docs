' Visual Basic .NET Document
Option Strict On

' <Snippet9>
<Assembly: CLSCompliant(True)>

Public Class Numbers
    Public Shared Function GetTenPrimes() As UInt32()
        Return {1ui, 2ui, 3ui, 5ui, 7ui, 11ui, 13ui, 17ui, 19ui}
    End Function

    Public Shared Function GetFivePrimes() As Object()
        Dim arr() As Object = {1, 2, 3, 5ui, 7ui}
        Return arr
    End Function
End Class
' Compilation produces a compiler warning like the following:
'    warning BC40027: Return type of function 'GetTenPrimes' is not CLS-compliant.
'    
'       Public Shared Function GetTenPrimes() As UInt32()
'                              ~~~~~~~~~~~~
' </Snippet9>

Module Example
    Public Sub Main()
        For Each obj In Numbers.GetFivePrimes()
            Console.WriteLine("{0} ({1})", obj, obj.GetType().Name)
        Next
    End Sub
End Module

