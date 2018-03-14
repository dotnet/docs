Imports System
Imports System.Runtime.InteropServices

'
' Some interface
'
<Guid("1F948D8D-D9ED-4CCC-BB61-5C1730E39EE9"), _
InterfaceType(ComInterfaceType.InterfaceIsDual)> _
Interface ISomeIFace

End Interface

Public Class MyObject
    Implements ISomeIFace
End Class

Public Class DispatchWrapperTest
    ' <Snippet1>
    Sub MyMethod(o As Object)
        ' handle object ...
    End Sub

    Public Sub DoWrap()
        Dim o As Object = new MyObject()
        MyMethod(o)                      ' passes o as VT_UNKNOWN
        MyMethod(new DispatchWrapper(o)) ' passes o as VT_DISPATCH

        '...
    End Sub
    ' </Snippet1>

    Public Shared Sub Main()
    End Sub
End Class