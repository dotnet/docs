Imports System.Windows
Imports System.Windows.Controls

Namespace WCSamples
    Public Partial Class IndexOf_vb
        ' <Snippet2>
    	Dim c_counter as Integer = 0
        Private Sub FindIndex(ByVal sender As Object, ByVal args As RoutedEventArgs)
            Try
                Dim newText As TextBlock = New TextBlock()
                c_counter = c_counter + 1
                ' Add this element to the UIElementCollection of the DockPanel element.
                MainDisplayPanel.Children.Add(newText)
                ' Add a text node under the Text element. This text is displayed. 
                newText.Text = "New element #" & CStr(c_counter)
                DockPanel.SetDock(newText, Dock.Top)
                ' Display the Index number of the new element.    
                TxtDisplay.Text = "The Index of the new element is " & MainDisplayPanel.Children.IndexOf(newText)
            Catch ex As System.Exception
                System.Windows.MessageBox.Show(ex.Message)
            End Try
        End Sub
        ' </Snippet2>
	End Class
End Namespace
