Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml


Public Class Form1
    Inherits Form

    Dim ListView1 As New ListView()
    Dim ImageList1 As New ImageList()

    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub


    ' 1b35a80a-edd8-495f-a807-a28c4aae52c6
    ' How to: Add and Remove Items with the Windows Forms ListView Control
    Public Sub Method11()
        ' <snippet11>
        ' Adds a new item with ImageIndex 3
        ListView1.Items.Add("List item text", 3)

        ' </snippet11>
    End Sub
    Public Sub Method12()
        ' <snippet12>
        ' Removes the first item in the list.
        ListView1.Items.RemoveAt(0)
        ' Clears all items:
        ListView1.Items.Clear()

        ' </snippet12>
    End Sub
    ' 610416a1-8da4-436c-af19-5f19e654769b
    ' How to: Group Items in a Windows Forms ListView Control
    Public Sub Method21()
        ' <snippet21>
        ' Adds a new group that has a left-aligned header
        ListView1.Groups.Add(New ListViewGroup("Group 1", _
         HorizontalAlignment.Left))
        ' </snippet21>
    End Sub
    Public Sub Method22()
        ' <snippet22>
        ' Removes the first group in the collection.
        ListView1.Groups.RemoveAt(0)
        ' Clears all groups:
        ListView1.Groups.Clear()
        ' </snippet22>
    End Sub
    Public Sub Method23()
        ' <snippet23>
        ' Adds the first item to the first group
        ListView1.Items.Item(0).Group = ListView1.Groups(0)
        ' </snippet23>
    End Sub
    ' 79174274-12ee-4a5d-80db-6ec02976d010
    ' How to: Add Columns to the Windows Forms ListView Control
    Public Sub Method31()
        ' <snippet31>
        ' Set to details view
        ListView1.View = View.Details
        ' Add a column with width 20 and left alignment
        ListView1.Columns.Add("File type", 20, HorizontalAlignment.Left)

        ' </snippet31>
    End Sub
    ' 9d577542-8595-429b-99e5-078770ec9d35
    ' How to: Display Icons for the Windows Forms ListView Control
    Public Sub Method41()
        ' <snippet41>
        ListView1.SmallImageList = ImageList1

        ' </snippet41>
    End Sub
    Public Sub Method42()
        ' <snippet42>
        ' Sets the first list item to display the 4th image.
        ListView1.Items(0).ImageIndex = 3

        ' </snippet42>
    End Sub
    ' c20e67a3-2d94-413d-9fcf-ecbd0fe251da
    ' How to: Enable Tile View in a Windows Forms ListView Control
    Public Sub Method51()
        ' <snippet51>
        ListView1.View = View.Tile
        ' </snippet51>
    End Sub
    ' e465f044-cde7-4fd9-a687-788a73a0f554
    ' How to: Display Subitems in Columns with the Windows Forms ListView Control
    Public Sub Method61()
        ' <snippet61>
        ' Adds two subitems to the first list item
        ListView1.Items(0).SubItems.Add("John Smith")
        ListView1.Items(0).SubItems.Add("Accounting")

        ' </snippet61>
    End Sub
End Class

