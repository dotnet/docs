'<Snippet13>
' Compile the source for this as follows:
' vbc /r:System.dll /r:System.Design.dll /r:System.Drawing.dll /debug+ /r:System.Web.dll /t:library /out:SimpleControlDesignersVB.dll SimpleControlDesigners.vb
'</Snippet13>


'<Snippet1>
'<Snippet2>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Web.UI
Imports System.Web.UI.Design
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB.Controls
End Namespace
'</Snippet2>

Namespace Samples.AspNet.VB.Brief.Controls
	'<Snippet3>
    Public Class SimpleCompositeControl
        Inherits CompositeControl
	End Class
	'</Snippet3>

	'<Snippet8>
    Public Class SimpleCompositeControl2
        Inherits SimpleCompositeControl
	End Class
	'</Snippet8>

	'<Snippet10>
	Public Class SimpleContainerControl
		Inherits WebControl
		Implements INamingContainer
	End Class
	'</Snippet10>

End Namespace

Namespace Samples.AspNet.VB.Controls
	'<Snippet7>
    <Designer(GetType(SimpleCompositeControlDesigner))> _
    Public Class SimpleCompositeControl
        Inherits CompositeControl
		'</Snippet7>

		'<Snippet4>
        Dim _prompt As String = "Please enter your date of birth: "
        Overridable Property Prompt() As String
            Get
                Dim o As Object
                o = ViewState("Prompt")
                If o Is Nothing Then
                    Return _prompt
                Else
                    Return CType(o, String)
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Prompt") = value
            End Set
        End Property

        Overridable Property DOB() As DateTime
            Get
                Dim o As Object
                o = ViewState("DOB")
                If o Is Nothing Then
                    Return DateTime.Now
                Else
                    Return CType(o, DateTime)
                End If
            End Get
            Set(ByVal value As DateTime)
                ViewState("DOB") = value
            End Set
        End Property
		'</Snippet4>

		'<Snippet5>
        Protected Overrides Sub CreateChildControls()
            Dim lab As New Label

            lab.Text = Prompt
            lab.ForeColor = System.Drawing.Color.Red
            Me.Controls.Add(lab)

            Dim lit As New Literal()
            lit.Text = "<br />"
            Me.Controls.Add(lit)

            Dim tb As New TextBox()
            tb.ID = "tb1"
            tb.Text = DOB.ToString()
            Me.Controls.Add(tb)

            MyBase.CreateChildControls()
        End Sub
		'</Snippet5>
    End Class

	'<Snippet6>
    Public Class SimpleCompositeControlDesigner
        Inherits CompositeControlDesigner
        ' Set this property to prevent the designer from being resized.
        Public Overrides ReadOnly Property AllowResize() As Boolean
            Get
                Return False
            End Get
        End Property
    End Class
	'</Snippet6>

	'<Snippet9>
    <Designer(GetType(CompositeControlDesigner))> _
    Public Class SimpleCompositeControl2
        Inherits SimpleCompositeControl
    End Class
	'</Snippet9>

	'<Snippet12>
    <Designer(GetType(SimpleContainerControlDesigner))> _
    <ParseChildren(False)> _
    Public Class SimpleContainerControl
        Inherits WebControl
        Implements INamingContainer
    End Class
	'</Snippet12>

	'<Snippet11>
    Public Class SimpleContainerControlDesigner
        Inherits ContainerControlDesigner

        Dim _style As Style

        ' Add the caption by default.
        Public Overrides ReadOnly Property FrameCaption() As String
            Get
                Return "A Simple ContainerControlDesigner"
            End Get
        End Property

        Public Overrides ReadOnly Property Framestyle() As Style
            Get
                If _style Is Nothing Then
                    _style = New Style()
                    _style.Font.Name = "Verdana"
                    _style.Font.Size = New FontUnit("XSmall")
                    _style.BackColor = Color.LightBlue
                    _style.ForeColor = Color.Black
                End If

                Return _style
            End Get
        End Property

    End Class
	'</Snippet11>

End Namespace
'</Snippet1>