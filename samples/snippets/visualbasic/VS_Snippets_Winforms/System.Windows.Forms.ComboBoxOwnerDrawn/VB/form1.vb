' This example demonstrates creating an owner-drawn ComboBox control. 
' The DrawMode property is set to OwnerDrawnVariable. It also demonstrates
' using the ComboBox.DropDownWidth and ComboBox.DropDownStyle properties
' and handling the ComboBox.MeasureItem and ComboBox.DrawItem events for
' an owner-drawn ComboBox with variable item size.

Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        InitializeComboBox()
    End Sub

    Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    '<snippet1>

    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Private animals() As String
  
    ' This method initializes the owner-drawn combo box.
    ' The drop-down width is set much wider than the size of the combo box
    ' to accomodate the large items in the list.  The drop-down style is set to 
    ' ComboBox.DropDown, which requires the user to click on the arrow to 
    ' see the list.
    Private Sub InitializeComboBox()
        Me.ComboBox1 = New ComboBox
        Me.ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ComboBox1.Location = New System.Drawing.Point(10, 20)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(100, 120)
        Me.ComboBox1.DropDownWidth = 250
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.DropDownStyle = ComboBoxStyle.DropDown
        animals = New String() {"Elephant", "c r o c o d i l e", "lion"}
        ComboBox1.DataSource = animals
        Me.Controls.Add(Me.ComboBox1)
    End Sub

    ' If you set the Draw property to DrawMode.OwnerDrawVariable, 
    ' you must handle the MeasureItem event. This event handler 
    ' will set the height and width of each item before it is drawn. 
     Private Sub ComboBox1_MeasureItem(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MeasureItemEventArgs) _
            Handles ComboBox1.MeasureItem

        Select Case e.Index
            Case 0
                e.ItemHeight = 45
            Case 1
                e.ItemHeight = 20
            Case 2
                e.ItemHeight = 35
        End Select
        e.ItemWidth = 260

    End Sub

    ' You must handle the DrawItem event for owner-drawn combo boxes.  
    ' This event handler changes the color, size and font of an 
    ' item based on its position in the array.
    Private Sub ComboBox1_DrawItem(ByVal sender As Object,  _ 
        ByVal e As System.Windows.Forms.DrawItemEventArgs) _
        Handles ComboBox1.DrawItem

        Dim size As Single
        Dim myFont As System.Drawing.Font
        Dim family As FontFamily

        Dim animalColor As New System.Drawing.Color
        Select Case e.Index
            Case 0
                size = 30
                animalColor = System.Drawing.Color.Gray
                family = FontFamily.GenericSansSerif
            Case 1
                size = 10
                animalColor = System.Drawing.Color.LawnGreen
                family = FontFamily.GenericMonospace
            Case 2
                size = 15
                animalColor = System.Drawing.Color.Tan
                family = FontFamily.GenericSansSerif
        End Select

        ' Draw the background of the item.
        e.DrawBackground()

        ' Create a square filled with the animals color. Vary the size
        ' of the rectangle based on the length of the animals name.
        Dim rectangle As Rectangle = New Rectangle(2, e.Bounds.Top + 2, _
            e.Bounds.Height, e.Bounds.Height - 4)
        e.Graphics.FillRectangle(New SolidBrush(animalColor), rectangle)

        ' Draw each string in the array, using a different size, color,
        ' and font for each item.
        myFont = New Font(family, size, FontStyle.Bold)
        e.Graphics.DrawString(animals(e.Index), myFont, System.Drawing.Brushes.Black, _
            New RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, _ 
            e.Bounds.Width, e.Bounds.Height))

        ' Draw the focus rectangle if the mouse hovers over an item.
        e.DrawFocusRectangle()
    End Sub

    '</snippet1>
End Class


