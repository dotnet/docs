Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design

Namespace ActiveDesignerEventArgsExample
    _
    Class Module1

        Shared Sub Main()
        End Sub
        
        '<Snippet1>
        Public Function CreateActiveDesignerEventArgs(ByVal losingFocus As IDesignerHost, ByVal gainingFocus As IDesignerHost) As ActiveDesignerEventArgs
            Dim e As New ActiveDesignerEventArgs(losingFocus, gainingFocus)
            Return e
        End Function
        '</Snippet1>

    End Class
End Namespace 'ActiveDesignerEventArgsExample
