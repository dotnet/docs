Imports System
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Controls
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Threading

Namespace TabControl
    ''' <summary>
    ''' Interaction logic for Pane1.xaml
    ''' </summary>

    Partial Public Class Pane1
        Inherits StackPanel

        Private tabcon As System.Windows.Controls.TabControl
        Private ti1, ti2, ti3 As System.Windows.Controls.TabItem

        Private Sub OnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<Snippet2>
            tabcon = New System.Windows.Controls.TabControl()
            ti1 = New TabItem()
            ti1.Header = "Background"
            tabcon.Items.Add(ti1)
            ti2 = New TabItem()
            ti2.Header = "Foreground"
            tabcon.Items.Add(ti2)
            ti3 = New TabItem()
            ti3.Header = "FontFamily"
            tabcon.Items.Add(ti3)

            cv2.Children.Add(tabcon)
            '</Snippet2>
        End Sub
        Private Sub OnSelectionChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetTabItemPlacement>
            If tabItem1.TabStripPlacement = Dock.Left Then
                btnPlacement.Content = "TabItems are placed on the left"
            End If
            '</SnippetTabItemPlacement>
        End Sub
    End Class
End Namespace