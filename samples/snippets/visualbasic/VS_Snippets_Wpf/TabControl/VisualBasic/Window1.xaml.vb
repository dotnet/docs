Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Collections.ObjectModel
Imports System.Collections.Generic


Namespace SDKSample

    '@ <summary>
    '@ Interaction logic for Window1_xaml.xaml
    '@ </summary>
    Partial Class Window1
        Inherits Window
        Dim tabcon As TabControl
        Dim ti1, ti2, ti3 As TabItem

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnClick(ByVal Sender As Object, ByVal e As RoutedEventArgs)
            '<Snippet4>
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
            '</Snippet4>
        End Sub

    End Class





End Namespace
