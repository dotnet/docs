' <Snippet1>
Imports System.Runtime.InteropServices

' The Demo class is has the AutoLayout attribute.
<StructLayoutAttribute(LayoutKind.Auto)> _
Public Class Demo
End Class 

Public Class Example
    Public Shared Sub Main()
        ' Get the Type object for the Demo class.
        Dim myType As Type = GetType(Demo)
        ' Get and display the IsAutoLayout property of the 
        ' Demo class.
        Console.WriteLine("The AutoLayout property for the Demo class is '{0}'.", _
            myType.IsAutoLayout.ToString())
    End Sub 
End Class 
' </Snippet1>
