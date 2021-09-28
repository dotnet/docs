
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



'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Partial Class Window1
    Inherits System.Windows.Window

    Public Sub New()
        InitializeComponent()

    End Sub


    Private Sub submit_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        MessageBox.Show("Hello, " + firstName.Text + " " + lastName.Text)

    End Sub
End Class

