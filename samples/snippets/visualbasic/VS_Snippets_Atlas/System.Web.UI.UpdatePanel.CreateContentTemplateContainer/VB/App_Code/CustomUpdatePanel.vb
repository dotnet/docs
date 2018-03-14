' <Snippet2>
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace SamplesVB
    Public Class CustomUpdatePanel : Inherits System.Web.UI.UpdatePanel

        Public CustomUpdatePanel()

        Private _groupingText As String

        Public Property GroupingText() As String
            Get
                Return _groupingText
            End Get
            Set(ByVal value As String)
                _groupingText = value
            End Set
        End Property

        Protected Overrides Function CreateContentTemplateContainer() As Control
            Dim myContentTemplateContainer As MyContentTemplateContainer
            myContentTemplateContainer = New MyContentTemplateContainer(_groupingText)
            Dim myControl As Control
            myControl = myContentTemplateContainer
            Return myControl
        End Function

        Private NotInheritable Class MyContentTemplateContainer : Inherits Control

            Private _displayText As String
            Public Sub New(ByVal groupingText As String)
                _displayText = groupingText
            End Sub

            Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

                writer.RenderBeginTag(HtmlTextWriterTag.Fieldset)
                writer.RenderBeginTag(HtmlTextWriterTag.Legend)
                writer.Write(_displayText)
                writer.RenderEndTag()
                MyBase.Render(writer)
                writer.RenderEndTag()
            End Sub

        End Class
    End Class
End Namespace

' </Snippet2>
