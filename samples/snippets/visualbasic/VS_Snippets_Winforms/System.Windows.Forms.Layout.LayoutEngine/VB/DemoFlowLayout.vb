'<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.Layout

' <snippet2>
' This class demonstrates a simple custom layout panel.
' It overrides the LayoutEngine property of the Panel
' control to provide a custom layout engine. 
Public Class DemoFlowPanel
    Inherits Panel

    Private layoutEng As DemoFlowLayout

    Public Sub New()
    End Sub

    Public Overrides ReadOnly Property LayoutEngine() As LayoutEngine
        Get
            If layoutEng Is Nothing Then
                layoutEng = New DemoFlowLayout()
            End If

            Return layoutEng
        End Get
    End Property
End Class
' </snippet2>

' <snippet3>
' This class demonstrates a simple custom layout engine.
Public Class DemoFlowLayout
   Inherits LayoutEngine

    ' <snippet4>
    Public Overrides Function Layout( _
    ByVal container As Object, _
    ByVal layoutEventArgs As LayoutEventArgs) As Boolean

        Dim parent As Control = container

        ' Use DisplayRectangle so that parent.Padding is honored.
        Dim parentDisplayRectangle As Rectangle = parent.DisplayRectangle
        Dim nextControlLocation As Point = parentDisplayRectangle.Location

        Dim c As Control
        For Each c In parent.Controls

            ' Only apply layout to visible controls.
            If c.Visible <> True Then
                Continue For
            End If

            ' Respect the margin of the control:
            ' shift over the left and the top.
            nextControlLocation.Offset(c.Margin.Left, c.Margin.Top)

            ' Set the location of the control.
            c.Location = nextControlLocation

            ' Set the autosized controls to their 
            ' autosized heights.
            If c.AutoSize Then
                c.Size = c.GetPreferredSize(parentDisplayRectangle.Size)
            End If

            ' Move X back to the display rectangle origin.
            nextControlLocation.X = parentDisplayRectangle.X

            ' Increment Y by the height of the control 
            ' and the bottom margin.
            nextControlLocation.Y += c.Height + c.Margin.Bottom
        Next c

        ' Optional: Return whether or not the container's 
        ' parent should perform layout as a result of this 
        ' layout. Some layout engines return the value of 
        ' the container's AutoSize property.
        Return False

    End Function
    ' </snippet4>
End Class
'</snippet3>
'</snippet1>