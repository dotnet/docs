'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class ListViewTilingExample
    Inherits Form
    
    Private myImageList As ImageList

    Public Sub New()
        ' Initialize myListView.
        Dim myListView As New ListView()
        myListView.Dock = DockStyle.Fill
        myListView.View = View.Tile
        
        ' Initialize the tile size.
        myListView.TileSize = new Size(400, 45)
        
        ' Initialize the item icons. 
        myImageList = New ImageList()
        Dim myIcon as Icon = new Icon("book.ico")
        Try
            myImageList.Images.Add(myIcon)
        Finally
            myIcon.Dispose()
        End Try
        myIcon.Dispose()
        myImageList.ImageSize = New Size(32, 32)
        myListView.LargeImageList = myImageList
        
        ' Add column headers so the subitems will appear.
        myListView.Columns.AddRange(New ColumnHeader() _
            {New ColumnHeader(), New ColumnHeader(), New ColumnHeader()})
        
        ' Create items and add them to myListView.
        Dim item0 As New ListViewItem( New String() _
            {"Programming Windows", _
            "Petzold, Charles", _
            "1998"}, 0 )
        Dim item1 As New ListViewItem( New String() _
            {"Code: The Hidden Language of Computer Hardware and Software", _
            "Petzold, Charles", _
            "2000"}, 0 )
        Dim item2 As New ListViewItem( New String() _
            {"Programming Windows with C#", _
            "Petzold, Charles", _
            "2001"}, 0 )
        Dim item3 As New ListViewItem( New String() _
            {"Coding Techniques for Microsoft Visual Basic .NET", _
            "Connell, John", _
            "2001"}, 0 )
        Dim item4 As New ListViewItem( New String() _
            {"C# for Java Developers", _
            "Jones, Allen / Freeman, Adam", _
            "2002"}, 0 )
        Dim item5 As New ListViewItem( New String() _
            {"Microsoft .NET XML Web Services Step by Step", _
            "Jones, Allen / Freeman, Adam", _
            "2002"}, 0 )
        myListView.Items.AddRange( _
            New ListViewItem() {item0, item1, item2, item3, item4, item5})
        
        ' Initialize the form.
        Me.Controls.Add(myListView)
        Me.Size = new System.Drawing.Size(430, 330)
        Me.Text = "ListView Tiling Example"
    End Sub 'New
    
    ' Clean up any resources being used.        
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If (disposing) Then
            myImageList.Dispose()
        End If

        MyBase.Dispose(disposing)
    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New ListViewTilingExample())
    End Sub 'Main

End Class 'ListViewTilingExample 
'</Snippet1>