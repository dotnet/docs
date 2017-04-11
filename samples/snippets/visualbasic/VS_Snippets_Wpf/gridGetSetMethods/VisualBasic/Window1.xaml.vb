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

        Dim rowDef1 As New RowDefinition
        Dim colDef1 As New ColumnDefinition

        ' <Snippet2>
        Private Sub setCol0(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Grid.SetColumn(rect1, 0)
            txt1.Text = "Rectangle is in Column " + Grid.GetColumn(rect1).ToString()
        End Sub

        Private Sub setCol1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Grid.SetColumn(rect1, 1)
            txt1.Text = "Rectangle is in Column " + Grid.GetColumn(rect1).ToString()
        End Sub

        Private Sub setCol2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Grid.SetColumn(rect1, 2)
            txt1.Text = "Rectangle is in Column " + Grid.GetColumn(rect1).ToString()
        End Sub

        Private Sub setRow0(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Grid.SetRow(rect1, 0)
            txt2.Text = "Rectangle is in Row " + Grid.GetRow(rect1).ToString()
        End Sub

        Private Sub setRow1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Grid.SetRow(rect1, 1)
            txt2.Text = "Rectangle is in Row " + Grid.GetRow(rect1).ToString()
        End Sub

        Private Sub setRow2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Grid.SetRow(rect1, 2)
            txt2.Text = "Rectangle is in Row " + Grid.GetRow(rect1).ToString()
        End Sub

        Private Sub setColspan(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Grid.SetColumnSpan(rect1, 3)
            txt3.Text = "ColumnSpan is set to " + Grid.GetColumnSpan(rect1).ToString()
        End Sub
        Private Sub setRowspan(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Grid.SetRowSpan(rect1, 3)
            txt4.Text = "RowSpan is set to " + Grid.GetRowSpan(rect1).ToString()
        End Sub
        '</Snippet2>

        Private Sub clearAll(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Grid.SetColumn(rect1, 0)
            Grid.SetRow(rect1, 0)
            Grid.SetColumnSpan(rect1, 1)
            Grid.SetRowSpan(rect1, 1)
            txt1.Text = "Rectangle is in Column 0"
            txt2.Text = "Rectangle is in Row 0"
            txt3.Text = "ColumnSpan is set to 1 (default)"
            txt4.Text = "RowSpan is set to 1 (default)"
        End Sub

    End Class
End Namespace
