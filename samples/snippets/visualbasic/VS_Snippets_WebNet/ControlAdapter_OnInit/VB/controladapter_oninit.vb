' <snippet1>
Imports System
Imports System.Web.UI
Imports System.Web.UI.Adapters

Public Class CustomControlAdapter
    Inherits ControlAdapter

    ' Override the ControlAdapter default OnInit implementation.
    Protected Overrides Sub OnInit(ByVal e As EventArgs)

        ' Make the control invisible.
        Control.Visible = False

        ' Call the base method, which calls OnInit of the control, 
        ' which raises the control Init event.
        MyBase.OnInit(e)

    End Sub 'OnInit
End Class 'CustomControlAdapter
' </snippet1>

Module MainMod
    Sub Main()
    End Sub
End Module 'MainMod