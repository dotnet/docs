
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO



Public Class Form1
    Inherits Form
    
    Public Sub New() 
        ExtractAssociatedIconEx()
    
    End Sub
    ' <snippet1>
    Private listView1 As ListView
    Private imageList1 As ImageList
    
    
    Public Sub ExtractAssociatedIconEx()

        ' Initialize the ListView, ImageList and Form.
        listView1 = New ListView()
        imageList1 = New ImageList()
        listView1.Location = New Point(37, 12)
        listView1.Size = New Size(161, 242)
        listView1.SmallImageList = imageList1
        listView1.View = View.SmallIcon
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.listView1)
        Me.Text = "Form1"

        ' Get the c:\ directory.
        Dim dir As New System.IO.DirectoryInfo("c:\")

        Dim item As ListViewItem
        listView1.BeginUpdate()
        Dim file As System.IO.FileInfo
        For Each file In dir.GetFiles()

            ' Set a default icon for the file.
            Dim iconForFile As Icon = SystemIcons.WinLogo

            item = New ListViewItem(file.Name, 1)

            ' Check to see if the image collection contains an image
            ' for this extension, using the extension as a key.
            If Not (imageList1.Images.ContainsKey(file.Extension)) Then

                ' If not, add the image to the image list.
                iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(file.FullName)
                imageList1.Images.Add(file.Extension, iconForFile)
            End If
            item.ImageKey = file.Extension
            listView1.Items.Add(item)

        Next file
        listView1.EndUpdate()
    End Sub
 ' </snippet1>
End Class