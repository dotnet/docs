Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Collections

Namespace SDKSample
    Public Partial Class DPClearValue
        '<SnippetIterateLocalValuesAndClear>        
        Private Sub RestoreDefaultProperties(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim uic As UIElementCollection = Sandbox.Children
            For Each uie As Shape In uic
                Dim locallySetProperties As LocalValueEnumerator = uie.GetLocalValueEnumerator()
                While locallySetProperties.MoveNext()
                    Dim propertyToClear As DependencyProperty = locallySetProperties.Current.Property
                    If Not propertyToClear.ReadOnly Then
                        uie.ClearValue(propertyToClear)
                    End If
                End While
            Next
        End Sub
        '</SnippetIterateLocalValuesAndClear>
        Private Sub MakeEverythingRed(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim uic As UIElementCollection = Sandbox.Children
            For Each uie As Shape In uic
                uie.Fill = New SolidColorBrush(Colors.Red)
            Next
        End Sub
    End Class
End Namespace