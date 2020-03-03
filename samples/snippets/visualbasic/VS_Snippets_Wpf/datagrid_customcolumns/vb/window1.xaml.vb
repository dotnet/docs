'<SnippetUsing>
'Additional using statements
Imports System.Data
Imports System.Collections.ObjectModel
Imports System.Diagnostics
'</SnippetUsing>

'<SnippetTop>
Class Window1
    '</SnippetTop>
    '<SnippetAll2>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        'GetData() creates a collection of Customer data from a database
        Dim custdata As ObservableCollection(Of Customer) = GetData()

        'Bind the DataGrid to the customer data
        DG1.DataContext = custdata

    End Sub
    '</SnippetAll2>

    '<SnippetCustomerClass>
    'Defines the customer object
    Public Class Customer
        Public Property FirstName() As String
        Public Property LastName() As String
        Public Property Email() As Uri
        Public Property IsMember() As Boolean
        Public Property Status() As OrderStatus
    End Class
    '</SnippetCustomerClass>

    '<SnippetGetDataTop>
    Public Function GetData() As ObservableCollection(Of Customer)
        '</SnippetGetDataTop>
        Using ctadapter As New AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter()
            Dim dt As New AdventureWorksLT2008DataSet.CustomerDataTable()
            ctadapter.Fill(dt)


            Dim custstatus As OrderStatus() = {OrderStatus.[New], OrderStatus.Received, OrderStatus.None, OrderStatus.Shipped, OrderStatus.[New], OrderStatus.Processing,
            OrderStatus.Received, OrderStatus.None, OrderStatus.Shipped, OrderStatus.[New]}
            Dim IsMember As Boolean() = {True, True, False, True, False, True,
            True, False, True, False}


            Dim customers As New ObservableCollection(Of Customer)()

            For i = 0 To 9
                Dim r As DataRow = dt.Rows(i)
                Dim c As New Customer With {
                    .FirstName = DirectCast(r("FirstName"), String),
                    .LastName = DirectCast(r("LastName"), String),
                    .Email = New Uri("mailto:" & DirectCast(r("EmailAddress"), String)),
                    .IsMember = IsMember(i),
                    .Status = custstatus(i)
                }
                customers.Add(c)
            Next


            '<SnippetGetDataEnd>
            Return customers
        End Using
    End Function
    '</SnippetGetDataEnd>

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    '<SnippetAllEnd> 
End Class
'</SnippetAllEnd> 

'<SnippetEnum>
Public Enum OrderStatus
    None
    [New]
    Processing
    Shipped
    Received
End Enum
'</SnippetEnum>

'<SnippetHyperlink3>
'Converts the mailto uri to a string with just the customer alias
Public Class EmailConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As System.Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
        If value IsNot Nothing Then
            Dim email As String = value.ToString()
            Dim index As Integer = email.IndexOf("@")
            Dim [alias] As String = email.Substring(7, index - 7)
            Return [alias]
        Else
            Dim email As String = ""
            Return email
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As System.Type, parameter As Object, culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        Dim email As New Uri(DirectCast(value, String))
        Return email
    End Function
End Class
'</SnippetHyperlink3>
