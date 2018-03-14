Imports System     
Imports System.Windows     
Imports System.Windows.Media     
Imports System.Windows.Controls     
Imports System.Windows.Documents     

namespace Height_MinHeight_MaxHeight

	'@ <summary>
	'@ Interaction logic for Window1.xaml
	'@ </summary>

    Partial Public Class Window1
        Inherits Window

        ' <Snippet3>
        Private Sub changeHeight(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)
            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim sz1 As Double = Double.Parse(li.Content.ToString())
            rect1.Height = sz1
            rect1.UpdateLayout()
            txt1.Text = "ActualHeight is set to " + rect1.ActualHeight.ToString
            txt2.Text = "Height is set to " + rect1.Height.ToString
            txt3.Text = "MinHeight is set to " + rect1.MinHeight.ToString
            txt4.Text = "MaxHeight is set to " + rect1.MaxHeight.ToString
        End Sub
        Private Sub changeMinHeight(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)

            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim sz1 As Double = Double.Parse(li.Content.ToString())
            rect1.MinHeight = sz1
            rect1.UpdateLayout()
            txt1.Text = "ActualHeight is set to " + rect1.ActualHeight.ToString
            txt2.Text = "Height is set to " + rect1.Height.ToString
            txt3.Text = "MinHeight is set to " + rect1.MinHeight.ToString
            txt4.Text = "MaxHeight is set to " + rect1.MaxHeight.ToString
        End Sub
        Private Sub changeMaxHeight(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)

            Dim li As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim sz1 As Double = Double.Parse(li.Content.ToString())
            rect1.MaxHeight = sz1
            rect1.UpdateLayout()
            txt1.Text = "ActualHeight is set to " + rect1.ActualHeight.ToString
            txt2.Text = "Height is set to " + rect1.Height.ToString
            txt3.Text = "MinHeight is set to " + rect1.MinHeight.ToString
            txt4.Text = "MaxHeight is set to " + rect1.MaxHeight.ToString
        End Sub
        ' </Snippet3>

        Private Sub clipRect(ByVal sender As Object, ByVal args As RoutedEventArgs)

            myCanvas.ClipToBounds = True
            txt5.Text = "Canvas.ClipToBounds is set to " + myCanvas.ClipToBounds.ToString
        End Sub
        Private Sub unclipRect(ByVal sender As Object, ByVal args As RoutedEventArgs)

            myCanvas.ClipToBounds = False
            txt5.Text = "Canvas.ClipToBounds is set to " + myCanvas.ClipToBounds.ToString
        End Sub
    End Class
    End Namespace
