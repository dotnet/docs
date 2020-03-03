Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Private Sub HorizontallyTileMyWindows(sender As Object, e As System.EventArgs)
        ' Tile all child forms horizontally.
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    
    
    Private Sub VerticallyTileMyWindows(sender As Object, e As System.EventArgs)
        ' Tile all child forms vertically.
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    
    
    Private Sub CascadeMyWindows(sender As Object, e As System.EventArgs)
        ' Cascade all MDI child windows.
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    ' </Snippet1>
End Class

