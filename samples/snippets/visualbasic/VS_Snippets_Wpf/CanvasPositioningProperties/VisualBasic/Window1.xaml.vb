Imports System     
Imports System.Windows     
Imports System.Windows.Controls     
Imports System.Windows.Documents     

Namespace SDKSample

    '@ <summary>
    '@ Interaction logic for Window1.xaml
    '@ </summary>

    Partial Public Class Window1
        Inherits Window

	'<Snippet2>
        Private Sub ChangeLeft(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim myLengthConverter As New LengthConverter
            Dim db1 As Double = CType(myLengthConverter.ConvertFromString(li.Content.ToString()), Double)
            Canvas.SetLeft(text1, db1)
            Dim st1 As String = CType(myLengthConverter.ConvertToString(Canvas.GetLeft(text1)), String)
            canvasLeft.Text = "Canvas.Left = " + st1
        End Sub
	'</Snippet2>
        Private Sub ChangeRight(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
            Dim li2 As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim myLengthConverter As New LengthConverter
            Dim db2 As Double = CType(myLengthConverter.ConvertFromString(li2.Content.ToString()), Double)
            Canvas.SetRight(text1, db2)
            Dim st1 As String = CType(myLengthConverter.ConvertToString(Canvas.GetRight(text1)), String)
            canvasRight.Text = "Canvas.Right = " + st1
        End Sub
        Private Sub ChangeTop(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
            Dim li3 As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim myLengthConverter As New LengthConverter
            Dim db3 As Double = CType(myLengthConverter.ConvertFromString(li3.Content.ToString()), Double)
            Canvas.SetTop(text1, db3)
            Dim st1 As String = CType(myLengthConverter.ConvertToString(Canvas.GetTop(text1)), String)
            canvasTop.Text = "Canvas.Top = " + st1
        End Sub
        Private Sub ChangeBottom(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
            Dim li4 As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim myLengthConverter As New LengthConverter
            Dim db4 As Double = CType(myLengthConverter.ConvertFromString(li4.Content.ToString()), Double)
            Canvas.SetTop(text1, db4)
            Dim st1 As String = CType(myLengthConverter.ConvertToString(Canvas.GetBottom(text1)), String)
            canvasBottom.Text = "Canvas.Bottom = " + st1
        End Sub
    End Class
End Namespace
