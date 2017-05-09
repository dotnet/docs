'<snippet1>
' Assembly building example in the .NET Framework.
Imports System

Namespace myStringer
    Public Class Stringer
        Public Sub StringerMethod()
            System.Console.WriteLine("This is a line from StringerMethod.")
        End Sub
    End Class
End Namespace
'</snippet1>

#If False
'<snippet2>
vbc /t:module Stringer.vb
'</snippet2>
#End If
