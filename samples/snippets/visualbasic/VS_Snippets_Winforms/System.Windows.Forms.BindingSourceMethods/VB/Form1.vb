
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml
Imports System.IO



Class Form1
    Inherits Form
   
    Public Sub New() 
        ' PopulateDataViewAndFind()
        'PopulateDataViewAndSort()
        'PopulateDataViewAndFilter()
        PopulateDataViewAndAdvancedSort()
    
    End Sub
    
    '<snippet1>
    Private Sub PopulateDataViewAndFind() 
        Dim set1 As New DataSet()
        
        ' Some xml data to populate the DataSet with.
        Dim musicXml As String = "<?xml version='1.0' encoding='UTF-8'?>" & _
            "<music>" & _
            "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" & _
            "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" & _
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
        
        ' Set the Position property to the results of the Find method.
        Dim itemFound As Integer = source1.Find("artist", "Natalie Merchant")
        source1.Position = itemFound
    
    End Sub
    
    '</snippet1>
    '<snippet2>
    Private Sub PopulateDataViewAndSort() 
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
        
        source1.Sort = "cd"
    
    End Sub
    '</snippet2>

    '<snippet3>
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
    '</snippet3>

    '<snippet4>
    Private Sub PopulateDataViewAndAdvancedSort() 
        Dim set1 As New DataSet()
        
        ' Some xml data to populate the DataSet with.
        Dim musicXml As String = "<?xml version='1.0' encoding='UTF-8'?>" & _
            "<music>" & _
            "<recording><artist>Dave Matthews</artist><cd>Under the Table and Dreaming</cd></recording>" & _
            "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd></recording>" & _
            "<recording><artist>Dave Matthews</artist><cd>Live at Red Rocks</cd></recording>" & _
            "<recording><artist>U2</artist><cd>Joshua Tree</cd></recording>" & _
            "<recording><artist>U2</artist><cd>How to Dismantle an Atomic Bomb</cd></recording>" & _
            "<recording><artist>Natalie Merchant</artist><cd>Tigerlily</cd></recording>" & _
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
        
        source1.Sort = "artist ASC, cd ASC"
        '</snippet4>
    End Sub

    <StaThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

 '<snippet6>
    Private WithEvents bindingSource1 As New BindingSource()
    Private box1 As New TextBox()
   
    
    Private Sub PopulateBindingSourceWithFonts()
      
        bindingSource1.Add(New Font(FontFamily.Families(2), 8.0F))
        bindingSource1.Add(New Font(FontFamily.Families(4), 9.0F))
        bindingSource1.Add(New Font(FontFamily.Families(6), 10.0F))
        bindingSource1.Add(New Font(FontFamily.Families(8), 11.0F))
        bindingSource1.Add(New Font(FontFamily.Families(10), 12.0F))
        Dim view1 As New DataGridView()
        view1.DataSource = bindingSource1
        view1.AutoGenerateColumns = True
        view1.Dock = DockStyle.Top
        Me.Controls.Add(view1)
        box1.Dock = DockStyle.Bottom
        box1.Text = "Sample Text"
        Me.Controls.Add(box1)
        view1.Columns("Name").DisplayIndex = 0
        box1.DataBindings.Add("Text", bindingSource1, "Name")
        
    End Sub
     
    Sub bindingSource1_CurrentChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles bindingSource1.CurrentChanged
        box1.Font = CType(bindingSource1.Current, Font)
    End Sub
    '</snippet6>
   
End Class




