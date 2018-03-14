'<snippet20>
Imports System
Imports System.Reflection

'<snippet21>
<Assembly:AssemblyKeyFileAttribute("keyfile.snk")>
'</snippet21>
Namespace KeyFileAttrib
    Public Class Dummy
        Public Shared Sub Main()
            Console.WriteLine("KeyFileAttrib.Dummy.Main()")
        End Sub
    End Class
End Namespace
'</snippet20>
