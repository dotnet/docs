Imports System.Windows.Xps.Packaging
Imports System.IO

Namespace SDKSample

    Partial Public Class DocumentViewerWindow
        Inherits System.Windows.Window

        Public Sub New()
            InitializeComponent()

            Dim xpsDocument As XpsDocument = New XpsDocument("documents/XpsDocument.xps", FileAccess.Read)
            Me.documentViewer.Document = xpsDocument.GetFixedDocumentSequence()

        End Sub

    End Class

End Namespace