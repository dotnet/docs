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
        Dim ctadapter As AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter = New AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter()
        Dim dt As New AdventureWorksLT2008DataSet.CustomerDataTable()
        ctadapter.Fill(dt)


        Dim custstatus As OrderStatus() = {OrderStatus.[New], OrderStatus.Received, OrderStatus.None, OrderStatus.Shipped, OrderStatus.[New], OrderStatus.Processing, _
        OrderStatus.Received, OrderStatus.None, OrderStatus.Shipped, OrderStatus.[New]}
        Dim IsMember As Boolean() = {True, True, False, True, False, True, _
        True, False, True, False}


        Dim customers As New ObservableCollection(Of Customer)()

        Dim i As Integer
        For i = 0 To 9
            Dim r As DataRow = dt.Rows(i)
            Dim c As New Customer()
            c.FirstName = DirectCast(r("FirstName"), String)
            c.LastName = DirectCast(r("LastName"), String)
            c.Email = New Uri("mailto:" & DirectCast(r("EmailAddress"), String))
            c.IsMember = IsMember(i)
            c.Status = custstatus(i)
            customers.Add(c)
        Next


        '<SnippetGetDataEnd>
        Return customers
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

    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
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

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        Dim email As New Uri(DirectCast(value, String))
        Return email
    End Function
End Class
'</SnippetHyperlink3>
