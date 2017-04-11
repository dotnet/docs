Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Collections.ObjectModel
Imports System.Collections.Generic


Namespace SDKSample

    '@ <summary>
    '@ Interaction logic for Window1_xaml.xaml
    '@ </summary>
    Partial Class Window1
        Public Sub Window1()
            InitializeComponent()

        End Sub
        Private Sub DisplayPopup(ByVal Sender As Object, ByVal e As RoutedEventArgs)

            myPopupText.Text = myTextBox.Text
            myPopup.IsOpen = True
            myPopup.StaysOpen = False

        End Sub
        Private Sub setColors(ByVal Sender As Object, _
                              ByVal e As TextChangedEventArgs)

            If (myTextBox.IsFocused) Then
                myTextBox.Foreground = Brushes.Brown
            End If

        End Sub

        '<SnippetCreatePopupCode>   

        Private Sub CreatePopup(ByVal Sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetCreatePopup>
            Dim codePopup As Popup = New Popup()
            Dim popupText As TextBlock = New TextBlock()
            popupText.Text = "Popup Text"
            popupText.Background = Brushes.LightBlue
            popupText.Foreground = Brushes.Blue
            codePopup.Child = popupText
            '</SnippetCreatePopup>
            aStackPanel.Children.Add(codePopup)
            codePopup.IsOpen = True
        End Sub
        '</SnippetCreatePopupCode>

    End Class

End Namespace
