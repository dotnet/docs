' <snippet10>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

' Interaction logic for Window1.xaml
Partial Public Class Window1
    Inherits Window

    Public Sub New()
        InitializeComponent()
    End Sub

    ' <snippet11>
    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Comment out the following line to disable visual
        ' styles for the hosted Windows Forms control.
        System.Windows.Forms.Application.EnableVisualStyles()

        ' Create a WindowsFormsHost element to host
        ' the Windows Forms control.
        Dim host As New System.Windows.Forms.Integration.WindowsFormsHost()

        ' Create a Windows Forms tab control.
        Dim tc As New System.Windows.Forms.TabControl()
        tc.TabPages.Add("Tab1")
        tc.TabPages.Add("Tab2")

        ' Assign the Windows Forms tab control as the hosted control.
        host.Child = tc

        ' Assign the host element to the parent Grid element.
        Me.grid1.Children.Add(host)

    End Sub
    ' </snippet11>

End Class
' </snippet10>