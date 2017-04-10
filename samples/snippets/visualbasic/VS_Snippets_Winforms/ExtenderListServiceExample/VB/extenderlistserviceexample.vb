 '<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

' This control lists any active extender providers.
Public Class ExtenderListServiceControl
   Inherits System.Windows.Forms.UserControl
   Private extenderListService As IExtenderListService
   Private extenderNames() As String
   
   Public Sub New()
      extenderNames = New String(-1) {}
      Me.Width = 600
    End Sub

    ' Queries the IExtenderListService when the control is sited 
    ' in design mode.
    Public Overrides Property Site() As System.ComponentModel.ISite
        Get
            Return MyBase.Site
        End Get
        Set(ByVal Value As System.ComponentModel.ISite)
            MyBase.Site = Value
            If Me.DesignMode Then
                extenderListService = CType(Me.GetService(GetType(IExtenderListService)), IExtenderListService)
                If (extenderListService IsNot Nothing) Then
                    Dim extenders As IExtenderProvider() = extenderListService.GetExtenderProviders()
                    extenderNames = New String(extenders.Length) {}
                    Dim i As Integer
                    For i = 0 To extenders.Length - 1
                        Dim types As Type() = Type.GetTypeArray(extenders)
                        extenderNames(i) = "ExtenderProvider #" + i.ToString() + ":  " + types(i).FullName
                    Next i
                End If
            Else
                extenderListService = Nothing
                extenderNames = New String(-1) {}
            End If
        End Set
    End Property

    ' Draws a list of any active extender providers
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If extenderNames.Length = 0 Then
            e.Graphics.DrawString("No active extender providers", New Font("Arial", 9), New SolidBrush(Color.Black), 10, 10)
        Else
            e.Graphics.DrawString("List of types of active extender providers", New Font("Arial", 9), New SolidBrush(Color.Black), 10, 10)
        End If
        Dim i As Integer
        For i = 0 To extenderNames.Length - 1
            e.Graphics.DrawString(extenderNames(i), New Font("Arial", 8), New SolidBrush(Color.Black), 10, 25 + i * 10)
        Next i
    End Sub

End Class
'</Snippet1>