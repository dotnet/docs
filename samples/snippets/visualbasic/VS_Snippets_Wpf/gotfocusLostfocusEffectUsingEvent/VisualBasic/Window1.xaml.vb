Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input

' Interaction logic for Window1.xaml
Namespace SDKSamples
    '<SnippetGotLostFocusSampleEventHandlers>
    Partial Public Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        'raised when Button gains focus. Changes the color of the Button to red.
        Private Sub OnGotFocusHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim tb As Button = CType(e.Source, Button)
            tb.Background = Brushes.Red
        End Sub

        'raised when Button loses focus. Changes the color back to white.
        Private Sub OnLostFocusHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim tb As Button = CType(e.Source, Button)
            tb.Background = Brushes.White
        End Sub
    End Class
    '</SnippetGotLostFocusSampleEventHandlers>
End Namespace

