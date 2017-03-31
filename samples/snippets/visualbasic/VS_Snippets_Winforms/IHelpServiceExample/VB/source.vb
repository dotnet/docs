'<Snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace IHelpServiceSample

    Public Class HelpDesigner
        Inherits System.Windows.Forms.Design.ControlDesigner

        Public Sub New()
        End Sub 'New

        Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
            Get
                Return New DesignerVerbCollection(New DesignerVerb() {New DesignerVerb("Add IHelpService Help Keyword", AddressOf Me.addKeyword), New DesignerVerb("Remove IHelpService Help Keyword", AddressOf Me.removeKeyword)})
            End Get
        End Property

        Private Sub addKeyword(ByVal sender As Object, ByVal e As EventArgs)
            Dim hs As IHelpService = CType(Me.Control.Site.GetService(GetType(IHelpService)), IHelpService)
            hs.AddContextAttribute("keyword", "IHelpService", HelpKeywordType.F1Keyword)
        End Sub 'addKeyword

        Private Sub removeKeyword(ByVal sender As Object, ByVal e As EventArgs)
            Dim hs As IHelpService = CType(Me.Control.Site.GetService(GetType(IHelpService)), IHelpService)
            hs.RemoveContextAttribute("keyword", "IHelpService")
        End Sub 'removeKeyword
    End Class 'HelpDesigner

    <Designer(GetType(HelpDesigner))> _
    Public Class HelpTestControl
        Inherits System.Windows.Forms.UserControl

        Public Sub New()
            Me.Size = New Size(320, 100)
            Me.BackColor = Color.White
        End Sub 'New

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim brush As New SolidBrush(Color.Blue)
            e.Graphics.DrawString("IHelpService Example Designer Control", New Font(FontFamily.GenericMonospace, 10), brush, 5, 5)
            e.Graphics.DrawString("Right-click this component for", New Font(FontFamily.GenericMonospace, 8), brush, 5, 25)
            e.Graphics.DrawString("add/remove Help context keyword commands.", New Font(FontFamily.GenericMonospace, 8), brush, 5, 35)
            e.Graphics.DrawString("Press F1 while this component is", New Font(FontFamily.GenericMonospace, 8), brush, 5, 55)
            e.Graphics.DrawString("selected to raise Help topics for", New Font(FontFamily.GenericMonospace, 8), brush, 5, 65)
            e.Graphics.DrawString("the current keyword or keywords", New Font(FontFamily.GenericMonospace, 8), brush, 5, 75)
        End Sub 'OnPaint
    End Class 'HelpTestControl
End Namespace 'IHelpServiceSample
'</Snippet1>