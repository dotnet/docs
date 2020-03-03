' <snippet1>
Imports System.Web.UI
Imports System.Web.UI.Adapters
Imports System.Web.UI.WebControls

Public Class CustomControl
    Inherits Control

    ' Add your custom control code.

End Class

Public Class CustomControlAdapter
    Inherits ControlAdapter

    ' Return a strongly-typed reference to your custom control.
    Public Shadows ReadOnly Property Control() As CustomControl
        Get
            Return CType(MyBase.Control, CustomControl)
        End Get
    End Property

    ' Override other ControlAdapter member as necessary. 

End Class
' </snippet1>

Module MainMod
    Sub Main()
    End Sub
End Module 'MainMod
