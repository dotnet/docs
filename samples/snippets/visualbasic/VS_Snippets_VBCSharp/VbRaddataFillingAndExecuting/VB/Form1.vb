Public Class Form1

    Private Sub CustomersBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.CustomersTableAdapter1.Update(Me.NorthwindDataSet1.Customers)
    End Sub


    '<Snippet1>
    Private Sub Form1_Load() Handles MyBase.Load

        'TODO: This line of code loads data into the 'NorthwindDataSet1.Customers' table.
        'You can move, or remove it, as needed.

        Me.CustomersTableAdapter1.Fill(Me.NorthwindDataSet1.Customers)
    End Sub
    '</Snippet1>


    '<Snippet2>
    Private Sub ReadXmlButton_Click() Handles ReadXmlButton.Click

        Dim filePath As String = "Complete path where you saved the XML file"

        AuthorsDataSet.ReadXml(filePath)

        DataGridView1.DataSource = AuthorsDataSet
        DataGridView1.DataMember = "authors"
    End Sub
    '</Snippet2>


    '<Snippet3>
    Private Sub ShowSchemaButton_Click() Handles ShowSchemaButton.Click

        Dim swXML As New System.IO.StringWriter()
        AuthorsDataSet.WriteXmlSchema(swXML)
        TextBox1.Text = swXML.ToString
    End Sub
    '</Snippet3>

End Class
