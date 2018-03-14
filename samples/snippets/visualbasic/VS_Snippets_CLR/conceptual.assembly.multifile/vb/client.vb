'<snippet3>
Imports System
Imports myStringer

Class MainClientApp
    ' Static method Main is the entry point method.
    Public Shared Sub Main()
        Dim myStringInstance As New Stringer()
        Console.WriteLine("Client code executes")
        myStringInstance.StringerMethod()
    End Sub
End Class
'</snippet3>

#If False
'<snippet4>
vbc /addmodule:Stringer.netmodule /t:module Client.vb
'</snippet4>

'<snippet5>
vbc /t:module Stringer.vb
vbc Client.vb /addmodule:Stringer.netmodule
'</snippet5>

'<snippet6>
vbc /out:Client.exe Client.vb /out:Stringer.netmodule Stringer.vb
'</snippet6>
#End If
