Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

Namespace InvokePatternTarget

    ' Interaction logic for Window1.xaml
    Partial Public Class Window1
        Inherits System.Windows.Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim targetButton As Button = DirectCast(sender, Button)
            MessageBox.Show(targetButton.Content + " invoked.")
        End Sub

    End Class
End Namespace
