Class Window1 

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim dt As AdventureWorksLT2008DataSet.CustomerDataTable = GetData()

        DG1.DataContext = dt

    End Sub

    Public Function GetData() As AdventureWorksLT2008DataSet.CustomerDataTable
        Dim custadapter As AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter = New AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter()
        Dim custdata As New AdventureWorksLT2008DataSet.CustomerDataTable()
        custadapter.Fill(custdata)

        Return custdata
    End Function

    '<Snippet2>
    'Access and update columns during autogeneration
    Private Sub DG1_AutoGeneratingColumn(ByVal sender As Object, ByVal e As DataGridAutoGeneratingColumnEventArgs)
        Dim headername As String = e.Column.Header.ToString()
        'Cancel the column you don't want to generate
        If headername = "MiddleName" Then
            e.Cancel = True
        End If

        'update column details when generating
        If headername = "FirstName" Then
            e.Column.Header = "First Name"
        ElseIf headername = "LastName" Then
            e.Column.Header = "Last Name"
        ElseIf headername = "EmailAddress" Then
            e.Column.Header = "Email"
        End If
    End Sub
    '</Snippet2>
End Class
