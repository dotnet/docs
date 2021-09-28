
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Input.StylusPlugIns


Namespace StylusControlSnippets

    '<Snippet14>
    Class InkControl
        Inherits Label
        '</Snippet14>

        Private dr As DynamicRenderer

        Private ip As InkPresenter


        '<Snippet17>
        Public Sub New()
            '</Snippet17>
            ' Add an InkPresenter for drawing.
            ip = New InkPresenter()
            Me.Content = ip

            '<Snippet18>
            ' Add a dynamic renderer that 
            ' draws ink as it "flows" from the stylus.
            dr = New DynamicRenderer()
            ip.AttachVisuals(dr.RootVisual, dr.DrawingAttributes)
            Me.StylusPlugIns.Add(dr)

        End Sub
        '</Snippet18>

        '<Snippet15>
    End Class
    '</Snippet15>
End Namespace 'StylusControlSnippets 

Namespace snippets2
    
    Class InkControl
        Inherits Label
        '<Snippet16>
        Private ip As InkPresenter

        Public Sub New()
            ' Add an InkPresenter for drawing.
            ip = New InkPresenter()
            Me.Content = ip

        End Sub
        '</Snippet16>
    End Class
End Namespace 'snippets2
