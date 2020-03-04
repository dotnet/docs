Imports System.ComponentModel

Class Window1

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim dt As AdventureWorksLT2008DataSet.CustomerDataTable = GetData()
        DG1.DataContext = dt
    End Sub

    Public Function GetData() As AdventureWorksLT2008DataSet.CustomerDataTable
        Dim custadapter As New AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter()
        Dim custdata As New AdventureWorksLT2008DataSet.CustomerDataTable()
        custadapter.Fill(custdata)

        Return custdata
    End Function

End Class

'<Snippet2> 
Public Class ConvertItemToIndex
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As System.Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
        Try
            'Get the CollectionView from the DataGrid that is using the converter 
            Dim dg As DataGrid = DirectCast(Application.Current.MainWindow.FindName("DG1"), DataGrid)
            Dim cv As CollectionView = DirectCast(dg.Items, CollectionView)
            'Get the index of the item from the CollectionView 
            Dim rowindex As Integer = cv.IndexOf(value) + 1

            Return rowindex.ToString()

        Catch e As Exception
            Throw New NotImplementedException(e.Message)
        End Try
    End Function

    Public Function ConvertBack(value As Object, targetType As System.Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class
'</Snippet2> 
