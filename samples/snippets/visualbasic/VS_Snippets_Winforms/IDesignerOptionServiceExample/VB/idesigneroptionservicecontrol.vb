'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' This control demonstrates retrieving the standard 
' designer option service values in design mode.
Public Class IDesignerOptionServiceControl
    Inherits System.Windows.Forms.UserControl
    Private designerOptionService As IDesignerOptionService

    Public Sub New()
        Me.BackColor = Color.Beige
        Me.Size = New Size(404, 135)
    End Sub

    Public Overrides Property Site() As System.ComponentModel.ISite
        Get
            Return MyBase.Site
        End Get
        Set(ByVal Value As System.ComponentModel.ISite)
            MyBase.Site = Value

            ' If siting component, attempt to obtain an IDesignerOptionService.
            If (MyBase.Site IsNot Nothing) Then
                designerOptionService = CType(Me.GetService(GetType(IDesignerOptionService)), IDesignerOptionService)
            End If
        End Set
    End Property

    ' Displays control information and current IDesignerOptionService 
    ' values, if available.
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawString("IDesignerOptionServiceControl", New Font("Arial", 9), New SolidBrush(Color.Blue), 4, 4)
        If Me.DesignMode Then
            e.Graphics.DrawString("Currently in design mode", New Font("Arial", 8), New SolidBrush(Color.Black), 4, 18)
        Else
            e.Graphics.DrawString("Not in design mode. Cannot access IDesignerOptionService.", New Font("Arial", 8), New SolidBrush(Color.Red), 4, 18)
        End If
        If (MyBase.Site IsNot Nothing) AndAlso (designerOptionService IsNot Nothing) Then
            e.Graphics.DrawString("IDesignerOptionService provides access to the table of option values listed when", New Font("Arial", 8), New SolidBrush(Color.Black), 4, 38)
            e.Graphics.DrawString("the Windows Forms Designer\General tab of the Tools\Options menu is selected.", New Font("Arial", 8), New SolidBrush(Color.Black), 4, 50)

            e.Graphics.DrawString("Table of standard value names and current values", New Font("Arial", 8), New SolidBrush(Color.Red), 4, 76)

            ' Displays a table of the standard value names and current values.
            Dim ypos As Integer = 90

            ' <snippet2>
            ' Obtains and shows the size of the standard design-mode grid square.
            Dim size As Size = CType(designerOptionService.GetOptionValue("WindowsFormsDesigner\General", "GridSize"), Size)
            ' </snippet2>
            e.Graphics.DrawString("GridSize", New Font("Arial", 8), New SolidBrush(Color.Black), 4, ypos)
            e.Graphics.DrawString(size.ToString(), New Font("Arial", 8), New SolidBrush(Color.Black), 100, ypos)
            ypos += 12

            ' Obtaisn and shows whether the design mode surface grid is enabled.
            Dim showGrid As Boolean = CBool(designerOptionService.GetOptionValue("WindowsFormsDesigner\General", "ShowGrid"))
            e.Graphics.DrawString("ShowGrid", New Font("Arial", 8), New SolidBrush(Color.Black), 4, ypos)
            e.Graphics.DrawString(showGrid.ToString(), New Font("Arial", 8), New SolidBrush(Color.Black), 100, ypos)
            ypos += 12

            ' Obtains and shows whether components should be aligned with the surface grid.
            Dim snapToGrid As Boolean = CBool(designerOptionService.GetOptionValue("WindowsFormsDesigner\General", "SnapToGrid"))
            e.Graphics.DrawString("SnapToGrid", New Font("Arial", 8), New SolidBrush(Color.Black), 4, ypos)
            e.Graphics.DrawString(snapToGrid.ToString(), New Font("Arial", 8), New SolidBrush(Color.Black), 100, ypos)
        End If
    End Sub

End Class
'</Snippet1>
