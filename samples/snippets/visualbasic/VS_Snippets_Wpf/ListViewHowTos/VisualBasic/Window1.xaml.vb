Imports System.Xml

Class Window1

    '<Snippet6>
    Private Sub ListViewItem_MouseDoubleClick(ByVal sender As Object, _
                                              ByVal e As MouseButtonEventArgs)

        Dim lvi As ListViewItem = CType(sender, ListViewItem)
        Dim book As XmlElement = CType(lvi.Content, XmlElement)

        If book.GetAttribute("Stock") = "out" Then
            MessageBox.Show("Time to order more copies of " + book("Title").InnerText)
        Else
            MessageBox.Show(book("Title").InnerText + " is available.")
        End If
    End Sub
    '</Snippet6>
End Class
