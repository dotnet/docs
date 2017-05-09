'<SnippetDataBindingCODEBEHIND>
Imports System.Windows

Namespace SDKSample

    Partial Public Class DataBindingWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' Create Person data source
            Dim person As Person = New Person()

            ' Make data source available for binding
            Me.DataContext = person

        End Sub

    End Class

End Namespace
'</SnippetDataBindingCODEBEHIND>