' <Snippet1>

Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Collections
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls

Namespace ControlDesignerSamples.VB

    ' <Snippet2>
    ' <Snippet3>

    ' Define a simple composite control, derived from the 
    ' System.Web.UI.WebControls.CompositeControl class.

    <Designer(GetType(SimpleContainerControlDesigner)), _
     ParseChildren(False)> _
    Public Class SimpleContainerControl
        Inherits CompositeControl

    End Class

    ' </Snippet3>
    ' <Snippet4>

    ' Define the designer for the simple composite control.
    ' The designer derives from System.Web.UI.Design.ContainerControlDesigner.
    ' The designer defines the style and caption for the frame around the 
    ' editable region of the control in the design surface.
    Public Class SimpleContainerControlDesigner
        Inherits ContainerControlDesigner

        Private _style As Style = Nothing

        ' Define the caption text for the frame in the design surface.
        Public Overrides ReadOnly Property FrameCaption() As String
            Get
                Return "- My simple container control -"
            End Get
        End Property


        ' Define the style of the frame around the control in the design surface.
        Public Overrides ReadOnly Property FrameStyle() As Style
            Get
                If _style Is Nothing Then

                    _style = New Style()
                    _style.Font.Name = "Verdana"
                    _style.Font.Size = New FontUnit("XSmall")
                    _style.BackColor = Color.LavenderBlush
                    _style.ForeColor = Color.DarkBlue
                End If

                Return _style
            End Get
        End Property


    End Class
    ' </Snippet4>
    ' </Snippet2>

End Namespace
' </Snippet1>