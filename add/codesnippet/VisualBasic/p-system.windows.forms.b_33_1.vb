    Private Sub PopulateDataViewAndFilter() 
        Dim set1 As New DataSet()
        
        ' Some xml data to populate the DataSet with.
        Dim musicXml As String = "<?xml version='1.0' encoding='UTF-8'?>" & _
            "<music>" & _
            "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" & _
            "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" & _
            "<recording><artist>Dave Matthews</artist><cd>Live at Red Rocks</cd></recording>" & _
            "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" & _
            "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" & _
            "</music>"
        
        ' Read the xml.
        Dim reader As New StringReader(musicXml)
        set1.ReadXml(reader)
        
        ' Get a DataView of the table contained in the dataset.
        Dim tables As DataTableCollection = set1.Tables
        Dim view1 As New DataView(tables(0))
        
        ' Create a DataGridView control and add it to the form.
        Dim datagridview1 As New DataGridView()
        datagridview1.AutoGenerateColumns = True
        Me.Controls.Add(datagridview1)
        
        ' Create a BindingSource and set its DataSource property to
        ' the DataView.
        Dim source1 As New BindingSource()
        source1.DataSource = view1
        
        ' Set the data source for the DataGridView.
        datagridview1.DataSource = source1
        
        ' The Filter string can include Boolean expressions.
        source1.Filter = "artist = 'Dave Matthews' OR cd = 'Tigerlily'"
    
    End Sub