Imports System     
Imports System.Windows     
Imports System.Windows.Controls     
Imports System.Windows.Documents     
Imports System.Windows.Navigation     
Imports System.Windows.Media     

Namespace ThicknessConverter

    Partial Public Class Window1
        Inherits Window

        ' <Snippet1>
        Private Sub changeThickness(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)

            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim myThicknessConverter As System.Windows.ThicknessConverter = New System.Windows.ThicknessConverter()
            Dim th1 As Thickness = CType(myThicknessConverter.ConvertFromString(li.Content.ToString()), Thickness)
            border1.BorderThickness = th1
            bThickness.Text = "Border.BorderThickness =" + li.Content.ToString()
        End Sub
        ' </Snippet1>

        Private Sub changeColor(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)

            Dim li2 As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim myBrushConverter As BrushConverter = New BrushConverter()
            border1.BorderBrush = CType(myBrushConverter.ConvertFromString(CType(li2.Content, String)), Brush)
            bColor.Text = "Border.Borderbrush =" + li2.Content.ToString()
        End Sub
    End Class
End Namespace
