Namespace SDKSample

    Partial Public Class DataTemplateWindow
        Inherits System.Windows.Window

        Public Sub New()
            InitializeComponent()

            Me.DataContext = New Tasks()

        End Sub

    End Class

End Namespace