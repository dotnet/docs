Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
    Public Partial Class FEMarginProgrammatic
'<SnippetHandler>
        Private Sub OnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)

            ' Get the current value of the property.
            Dim marginThickness As Thickness
            marginThickness = btn1.Margin
            ' If the current leftlength value of margin is set to 10 then change it to a new value.
            ' Otherwise change it back to 10.
            If marginThickness.Left = 10 Then
                btn1.Margin = New Thickness(60)
            Else
                btn1.Margin = New Thickness(10)
            End If
        End Sub
'</SnippetHandler>
    End Class
End Namespace
