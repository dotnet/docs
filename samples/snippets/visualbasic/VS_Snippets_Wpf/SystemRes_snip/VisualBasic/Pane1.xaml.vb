'This is a list of commonly used namespaces for a pane.

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media

Namespace ButtonResources
    ''' <summary>
    ''' Interaction logic for Pane1.xaml
    ''' </summary>

    Partial Public Class Pane1
        Inherits StackPanel
        Private Sub OnClick1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetFontResourcesCode>
            Dim btn As New Button()
            btn.Content = "SystemFonts"
            btn.Background = SystemColors.ControlDarkDarkBrush
            btn.FontSize = SystemFonts.IconFontSize
            btn.FontWeight = SystemFonts.MessageFontWeight
            btn.FontFamily = SystemFonts.CaptionFontFamily
            cv1.Children.Add(btn)
            '</SnippetFontResourcesCode>
        End Sub

        Private Sub OnClick2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetParameterResourcesCode>
            Dim btn As New Button()
            btn.Content = "SystemParameters"
            btn.FontSize = 8
            btn.Background = SystemColors.ControlDarkDarkBrush
            btn.Height = SystemParameters.CaptionHeight
            btn.Width = SystemParameters.IconGridWidth
            cv2.Children.Add(btn)
            '</SnippetParameterResourcesCode>
        End Sub
    End Class
End Namespace