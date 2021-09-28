Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace ExampleNamespace
Partial Public Class ExamplePage
'<SnippetButtonWithCodeBehindHandler>
Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
    Dim b As Button = e.Source
    b.Foreground = Brushes.Red
End Sub
'</SnippetButtonWithCodeBehindHandler>

'<SnippetNameCode>
 Private Sub RemoveThis(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
     Dim fe As FrameworkElement = e.Source
     If (buttonContainer.Children.Contains(fe)) Then
         buttonContainer.Children.Remove(fe)
     End If
End Sub
'</SnippetNameCode>


End Class
End Namespace