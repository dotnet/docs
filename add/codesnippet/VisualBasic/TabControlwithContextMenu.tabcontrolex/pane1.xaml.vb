'This is a list of commonly used namespaces for a pane.

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Threading

Namespace TabControlEx
    ''' <summary>
    ''' Interaction logic for Pane1.xaml
    ''' </summary>

    Partial Public Class Pane1
        Inherits StackPanel
        Private target As System.Windows.UIElement
        '<Snippet2>
        Private Sub MyMenuHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<Snippet3>
            Dim cm As ContextMenu = CType(sender, ContextMenu)
            target = cm.PlacementTarget
            '</Snippet3>
            If e.Source Is red Then
                backgroundcolor.Background = Brushes.Red
                backgroundcolor.Header = "Background red"
            ElseIf e.Source Is blue Then
                backgroundcolor.Background = Brushes.LightBlue
                backgroundcolor.Header = "Background blue"
            ElseIf e.Source Is yellow Then
                backgroundcolor.Background = Brushes.Yellow
                backgroundcolor.Header = "Background yellow"
            End If
        End Sub
        '</Snippet2>
        Private Sub MyMenuHandler2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim cm As ContextMenu = CType(sender, ContextMenu)
            target = cm.PlacementTarget
            If e.Source Is green Then
                foregroundcolor.Foreground = Brushes.Green
                foregroundcolor.Header = "Foreground green"
            ElseIf e.Source Is purple Then
                foregroundcolor.Foreground = Brushes.Purple
                foregroundcolor.Header = "Foreground purple"
            ElseIf e.Source Is crimson Then
                foregroundcolor.Foreground = Brushes.Crimson
                foregroundcolor.Header = "Foreground crimson"
            End If
        End Sub

        Private Sub MyMenuHandler3(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim cm As ContextMenu = CType(sender, ContextMenu)
            target = cm.PlacementTarget
            If e.Source Is sixteen Then
                fontsize.FontSize = 16
                fontsize.Header = "Font Size 16"
            ElseIf e.Source Is twenty Then
                fontsize.FontSize = 20
                fontsize.Header = "Font Size 20"
            ElseIf e.Source Is twentyfour Then
                fontsize.FontSize = 24
                fontsize.Header = "Font Size 24"
            End If
        End Sub
    End Class
End Namespace