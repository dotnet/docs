' Per Kitg, from cut QuickStart (vswhidbey 160832)
'<Snippet1>
Imports System
Imports System.Reflection

<assembly:AssemblyDelaySignAttribute(true)>
<assembly:AssemblyKeyFileAttribute("TestPublicKey.snk")>

Namespace DelaySign

    Public class Test
    End Class

End Namespace
'</Snippet1>
