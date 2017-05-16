'<snippet2>
Imports System
Imports System.Reflection

'<snippet3>
' Set version number for the assembly.
<Assembly:AssemblyVersionAttribute("4.3.2.1")>
' Set culture as German.
<Assembly:AssemblyCultureAttribute("de")>
'</snippet3>

'<snippet4>
<Assembly:AssemblyKeyFileAttribute("myKey.snk")>
<Assembly:AssemblyDelaySignAttribute(True)>
'</snippet4>

Namespace DummySpace
    Class DummyClass
        Public Shared Sub Main()
            Console.WriteLine("DummySpace.DummyClass.Main()")
        End Sub
    End Class
End Namespace
'</snippet2>
