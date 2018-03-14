'<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace ControlDesignerExample
    _
    ' ExampleControlDesigner is an example control designer that 
    ' demonstrates basic functions of a ControlDesigner.
    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Public Class ExampleControlDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner

        ' This boolean state reflects whether the mouse is over the control.
        Private mouseover As Boolean = False
        ' This color is a private field for the OutlineColor property.
        Private lineColor As Color = Color.White

        ' This color is used to outline the control when the mouse is 
        ' over the control.
        Public Property OutlineColor() As Color
            Get
                Return lineColor
            End Get
            Set(ByVal Value As Color)
                lineColor = Value
            End Set
        End Property

        Public Sub New()
        End Sub

        ' Sets a value and refreshes the control's display when the 
        ' mouse position enters the area of the control.
        Protected Overrides Sub OnMouseEnter()
            Me.mouseover = True
            Me.Control.Refresh()
        End Sub

        ' Sets a value and refreshes the control's display when the 
        ' mouse position enters the area of the control.		
        Protected Overrides Sub OnMouseLeave()
            Me.mouseover = False
            Me.Control.Refresh()
        End Sub

        ' Draws an outline around the control when the mouse is 
        ' over the control.	
        Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
            If Me.mouseover Then
                pe.Graphics.DrawRectangle(New Pen(New SolidBrush(Me.lineColor), 6), 0, 0, Me.Control.Size.Width, Me.Control.Size.Height)
            End If
        End Sub

        '<Snippet2>
        ' Adds a property to this designer's control at design time 
        ' that indicates the outline color to use.
        ' The DesignOnlyAttribute ensures that the OutlineColor
        ' property is not serialized by the designer.
        Protected Overrides Sub PreFilterProperties(ByVal properties As System.Collections.IDictionary)
            Dim pd As PropertyDescriptor = TypeDescriptor.CreateProperty( _
            GetType(ExampleControlDesigner), _
            "OutlineColor", _
            GetType(System.Drawing.Color), _
            New Attribute() {New DesignOnlyAttribute(True)})

            properties.Add("OutlineColor", pd)
        End Sub
        '</Snippet2>
    End Class

    ' This example control demonstrates the ExampleControlDesigner.
    <DesignerAttribute(GetType(ExampleControlDesigner))> _
     Public Class ExampleControl
        Inherits System.Windows.Forms.UserControl
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            components = New System.ComponentModel.Container()
        End Sub

        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If (components IsNot Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class

End Namespace
'</Snippet1>