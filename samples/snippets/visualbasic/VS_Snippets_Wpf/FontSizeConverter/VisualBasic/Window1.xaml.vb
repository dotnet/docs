Imports System     
Imports System.Windows     
Imports System.Windows.Controls     
Imports System.Windows.Documents     
Imports System.Windows.Navigation     
Imports System.Windows.Media     

namespace FontSizeConverter

    Partial Public Class Window1
        Inherits Window

        ' <Snippet1>
        Private Sub changeSize(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)

            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim myFontSizeConverter As System.Windows.FontSizeConverter = New System.Windows.FontSizeConverter()
            text1.FontSize = CType(myFontSizeConverter.ConvertFromString(li.Content.ToString()), Double)
        End Sub

        Private Sub changeFamily(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)
            Dim li2 As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            text1.FontFamily = New System.Windows.Media.FontFamily(li2.Content.ToString())
        End Sub
        ' </Snippet1>
    End Class
    End Namespace
