Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

'<snippet11>
Imports System.Windows.Forms
'</snippet11>

' Interaction logic for MainWindow.xaml
Partial Public Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()
    End Sub

    '<snippet10>
    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Create the interop host control.
        Dim host As New System.Windows.Forms.Integration.WindowsFormsHost()

        ' Create the MaskedTextBox control.
        Dim mtbDate As New MaskedTextBox("00/00/0000")

        ' Assign the MaskedTextBox control as the host control's child.
        host.Child = mtbDate

        ' Add the interop host control to the Grid
        ' control's collection of child controls.
        Me.grid1.Children.Add(host)

    End Sub
    '</snippet10>

End Class
