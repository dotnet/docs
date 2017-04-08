Imports System     
Imports System.Windows     
Imports System.Windows.Controls     
Imports System.Windows.Documents     

namespace GridLengthConverter_grid

	'@ <summary>
	'@ Interaction logic for Window1.xaml
	'@ </summary>

    Partial Public Class Window1
        Inherits Window


        Private Sub changeRowVal(ByVal sender As Object, ByVal args As RoutedPropertyChangedEventArgs(Of Double))

            txt2.Text = "Current Grid Row is " + hs2.Value.ToString()
        End Sub

        ' <Snippet1>
        Private Sub changeColVal(ByVal sender As Object, ByVal args As RoutedPropertyChangedEventArgs(Of Double))

            txt1.Text = "Current Grid Column is " + hs1.Value.ToString()
        End Sub

        Private Sub changeCol(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)

            Dim li1 As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim myGridLengthConverter As System.Windows.GridLengthConverter = New System.Windows.GridLengthConverter()
            If (hs1.Value = 0) Then

                Dim gl1 As GridLength = CType(myGridLengthConverter.ConvertFromString(li1.Content.ToString()), GridLength)
                col1.Width = gl1

            ElseIf (hs1.Value = 1) Then

                Dim gl2 As GridLength = CType(myGridLengthConverter.ConvertFromString(li1.Content.ToString()), GridLength)
                col2.Width = gl2

            ElseIf (hs1.Value = 2) Then

                Dim gl3 As GridLength = CType(myGridLengthConverter.ConvertFromString(li1.Content.ToString()), GridLength)
                col3.Width = gl3
            End If
        End Sub
        ' </Snippet1>
        Private Sub changeRow(ByVal sender As Object, ByVal args As SelectionChangedEventArgs)

            Dim li2 As ListBoxItem = CType(CType(sender, ListBox).SelectedItem, ListBoxItem)
            Dim myGridLengthConverter2 As System.Windows.GridLengthConverter = New System.Windows.GridLengthConverter()


            If (hs2.Value = 0) Then

                Dim gl4 As GridLength = CType(myGridLengthConverter2.ConvertFromString(li2.Content.ToString()), GridLength)
                row1.Height = gl4
            ElseIf (hs2.Value = 1) Then

                Dim gl5 As GridLength = CType(myGridLengthConverter2.ConvertFromString(li2.Content.ToString()), GridLength)
                row2.Height = gl5
            ElseIf (hs2.Value = 2) Then

                Dim gl6 As GridLength = CType(myGridLengthConverter2.ConvertFromString(li2.Content.ToString()), GridLength)
                row3.Height = gl6
            End If

        End Sub

        Private Sub setMinWidth(ByVal sender As Object, ByVal args As RoutedEventArgs)

            col1.MinWidth = 100
            col2.MinWidth = 100
            col3.MinWidth = 100
        End Sub
        Private Sub setMaxWidth(ByVal sender As Object, ByVal args As RoutedEventArgs)

            col1.MaxWidth = 125
            col2.MaxWidth = 125
            col3.MaxWidth = 125
        End Sub
        Private Sub setMinHeight(ByVal sender As Object, ByVal args As RoutedEventArgs)

            row1.MinHeight = 50
            row2.MinHeight = 50
            row3.MinHeight = 50
        End Sub
        Private Sub setMaxHeight(ByVal sender As Object, ByVal args As RoutedEventArgs)

            row1.MaxHeight = 75
            row2.MaxHeight = 75
            row3.MaxHeight = 75
        End Sub

    End Class
    End Namespace
