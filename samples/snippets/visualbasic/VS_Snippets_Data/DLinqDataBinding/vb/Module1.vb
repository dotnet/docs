Imports System.Windows.Forms
Imports System.Linq



Module Module1

    Sub Main()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet1>
        Dim dataGrid1 As New DataGrid()
        Dim dataGrid2 As New DataGrid()
        Dim dataGrid3 As New DataGrid()

        Dim custQuery = _
            From cust In db.Customers _
            Select cust

        dataGrid1.DataSource = custQuery
        dataGrid2.DataSource = custQuery
        dataGrid2.DataMember = "Orders"

        Dim bs = _
            New BindingSource()
        bs.DataSource = custQuery
        dataGrid3.DataSource = bs
        ' </Snippet1>


    End Sub

    Sub method2()
        Dim db As New Northwnd("c:\northwnd.mdf")

        ' <Snippet2>
        Dim listView1 As New ListView()
        Dim custQuery2 = _
        From cust In db.Customers _
        Select cust

        Dim ItemsSource As New ListViewItem
        ItemsSource = custQuery2
        ' </Snippet2>


    End Sub

End Module
