Imports System     
Imports System.Windows     
Imports System.Windows.Controls     
Imports System.Windows.Documents     
Imports System.Windows.Navigation     
Imports System.Text     

namespace ScrollViewer_Methods

    Partial Public Class Window1
        Inherits Window


        Private FillText As String = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat."

        Private Sub onLoad(ByVal sender As Object, ByVal args As RoutedEventArgs)

            Dim myStringBuilder As StringBuilder = New StringBuilder(400)

            For i As Integer = 1 To 100
                myStringBuilder.Append(FillText)

            Next


            txt1.Text = myStringBuilder.ToString()

        End Sub
        ' <Snippet2>
        Private Sub svLineUp(ByVal sender As Object, ByVal args As RoutedEventArgs)

            sv1.LineUp()
        End Sub
        Private Sub svLineDown(ByVal sender As Object, ByVal args As RoutedEventArgs)

            sv1.LineDown()
        End Sub
        ' </Snippet2>
        Private Sub svLineRight(ByVal sender As Object, ByVal args As RoutedEventArgs)

            sv1.LineRight()
        End Sub
        Private Sub svLineLeft(ByVal sender As Object, ByVal args As RoutedEventArgs)

            sv1.LineLeft()
        End Sub
        Private Sub svPageUp(ByVal sender As Object, ByVal args As RoutedEventArgs)

            sv1.PageUp()
        End Sub
        Private Sub svPageDown(ByVal sender As Object, ByVal args As RoutedEventArgs)

            sv1.PageDown()
        End Sub
        Private Sub svPageRight(ByVal sender As Object, ByVal args As RoutedEventArgs)

            sv1.PageRight()
        End Sub
        Private Sub svPageLeft(ByVal sender As Object, ByVal args As RoutedEventArgs)

            sv1.PageLeft()
        End Sub

    End Class
    End Namespace
