Imports System     
Imports System.Windows     
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace SDKSample

    Partial Public Class Window1
        Inherits Window

        ' <SnippetTextBoxBase3>
        Private Sub initValues(ByVal sender As Object, ByVal e As EventArgs)
            myTB1.Text = "ExtentHeight is currently " + myTextBox.ExtentHeight.ToString()
            myTB2.Text = "ExtentWidth is currently " + myTextBox.ExtentWidth.ToString()
            myTB3.Text = "HorizontalOffset is currently " + myTextBox.HorizontalOffset.ToString()
            myTB4.Text = "VerticalOffset is currently " + myTextBox.VerticalOffset.ToString()
            myTB5.Text = "ViewportHeight is currently " + myTextBox.ViewportHeight.ToString()
            myTB6.Text = "ViewportWidth is currently " + myTextBox.ViewportWidth.ToString()
            radiobtn1.IsChecked = True
            ' </SnippetTextBoxBase3>
        End Sub

        ' <SnippetTextBoxBase4>
        Private Sub copyText(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.Copy()
        End Sub
        ' </SnippetTextBoxBase4>

        ' <SnippetTextBoxBase5>
        Private Sub cutText(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.Cut()
        End Sub
        ' </SnippetTextBoxBase5>

        ' <SnippetTextBoxBase6>
        Private Sub pasteSelection(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.Paste()
        End Sub
        ' </SnippetTextBoxBase6>

        ' <SnippetTextBoxBase7>
        Private Sub selectAll(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.SelectAll()
        End Sub
        ' </SnippetTextBoxBase7>

        ' <SnippetTextBoxBase8>
        Private Sub undoAction(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If myTextBox.CanUndo = True Then
                myTextBox.Undo()
            Else : Return
            End If
        End Sub
        ' </SnippetTextBoxBase8>

        ' <SnippetTextBoxBase9>
        Private Sub redoAction(ByVal sender As Object, ByVal e As RoutedEventArgs)

            If myTextBox.CanRedo = True Then
                myTextBox.Redo()
            Else : Return
            End If
        End Sub
        ' </SnippetTextBoxBase9>

        ' <SnippetTextBoxBase10>
        Private Sub selectChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.AppendText("Selection Changed event in myTextBox2 has just occurred.")
        End Sub
        ' </SnippetTextBoxBase10>

        ' <SnippetTextBoxBase11>
        Private Sub tChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
            myTextBox.AppendText("Text content of myTextBox2 has changed.")
        End Sub
        ' </SnippetTextBoxBase11>

        ' <SnippetTextBoxBase12>
        Private Sub wrapOff(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.TextWrapping = TextWrapping.NoWrap
        End Sub
        ' </SnippetTextBoxBase12>

        Private Sub wrapOn(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.TextWrapping = TextWrapping.Wrap
        End Sub

        Private Sub clearTB1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.Clear()
        End Sub

        Private Sub clearTB2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox2.Clear()
        End Sub

        ' <SnippetTextBoxBase13>
        Private Sub lineDown(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.LineDown()
        End Sub
        ' </SnippetTextBoxBase13>

        ' <SnippetTextBoxBase14>
        Private Sub lineLeft(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.LineLeft()
        End Sub
        ' </SnippetTextBoxBase14>

        ' <SnippetTextBoxBase15>
        Private Sub lineRight(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.LineRight()
        End Sub
        ' </SnippetTextBoxBase15>

        ' <SnippetTextBoxBase16>
        Private Sub lineUp(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.LineUp()
        End Sub
        ' </SnippetTextBoxBase16>

        ' <SnippetTextBoxBase17>
        Private Sub pageDown(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.PageDown()
        End Sub
        ' </SnippetTextBoxBase17>

        ' <SnippetTextBoxBase18>
        Private Sub pageLeft(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.PageLeft()
        End Sub
        ' </SnippetTextBoxBase18>

        ' <SnippetTextBoxBase19>
        Private Sub pageRight(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.PageRight()
        End Sub
        ' </SnippetTextBoxBase19>

        ' <SnippetTextBoxBase20>
        Private Sub pageUp(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.PageUp()
        End Sub
        ' </SnippetTextBoxBase20>

        ' <SnippetTextBoxBase21>
        Private Sub scrollHome(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.ScrollToHome()
        End Sub
        ' </SnippetTextBoxBase21>

        ' <SnippetTextBoxBase22>
        Private Sub scrollEnd(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myTextBox.ScrollToEnd()
        End Sub
        ' </SnippetTextBoxBase22>

    End Class
End Namespace
