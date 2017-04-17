'<SnippetFlowDocumentReaderCODEBEHIND>
Imports System.Windows 'Window
Imports System.Windows.Documents 'FlowDocument
Imports System.IO 'FileStream, FileMode
Imports System.Windows.Markup 'XamlReader

Namespace SDKSample

    Public Class FlowDocumentReaderWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Using stream1 As FileStream = New FileStream("AFlowDocument.xaml", _
                FileMode.Open, FileAccess.Read)
                Dim document1 As FlowDocument = _
                    TryCast(XamlReader.Load(stream1), FlowDocument)
                Me.flowDocumentReader.Document = document1
            End Using
        End Sub

    End Class

End Namespace
'</SnippetFlowDocumentReaderCODEBEHIND>