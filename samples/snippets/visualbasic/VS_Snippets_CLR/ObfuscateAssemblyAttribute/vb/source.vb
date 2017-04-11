'<Snippet1>
Imports System
Imports System.Reflection

<Assembly: ObfuscateAssemblyAttribute(False, _
    StripAfterObfuscation:=False)>
'</Snippet1>

Public Class Type1

    <ObfuscationAttribute(Exclude:=True)> _
    Public Sub MethodA()
    End Sub

    Public Shared Sub Main()
    End Sub

End Class
