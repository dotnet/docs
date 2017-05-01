' This sample shows how to create a custom button column/cell that allows specific 
' button cells to be disabled. This is done by rendering the disabled buttons in 
' the overridden Paint method with ButtonRenderer.

' Snippet0 (entire sample) will go in How to: Disable Buttons in a Button Column 
'    in the Windows Forms DataGridView Control
' Snippet5 will go in DataGridView.CurrentCellDirtyStateChanged, CommitEdit and
'    CellValueChanged
' Snippet20 will go in DataGridViewButtonCell.Paint() (and/or DataGridViewCell.Paint?)
' Snippet20 will also go in DataGridViewCell.BorderWidths()


' <Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Class Form1
    Inherits Form
    Private WithEvents dataGridView1 As New DataGridView()

    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

    Public Sub New()
        Me.AutoSize = True
    End Sub

    Public Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        Dim column0 As New DataGridViewCheckBoxColumn()
        Dim column1 As New DataGridViewDisableButtonColumn()
        column0.Name = "CheckBoxes"
        column1.Name = "Buttons"
        dataGridView1.Columns.Add(column0)
        dataGridView1.Columns.Add(column1)

        dataGridView1.RowCount = 8
        dataGridView1.AutoSize = True
        dataGridView1.AllowUserToAddRows = False
        dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = _
            DataGridViewContentAlignment.MiddleCenter

        ' Set the text for each button.
        Dim i As Integer
        For i = 0 To dataGridView1.RowCount - 1
            dataGridView1.Rows(i).Cells("Buttons").Value = _
                "Button " + i.ToString()
        Next i

        Me.Controls.Add(dataGridView1)

    End Sub

    ' <Snippet5>
    ' This event handler manually raises the CellValueChanged event
    ' by calling the CommitEdit method.
    Sub dataGridView1_CurrentCellDirtyStateChanged( _
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles dataGridView1.CurrentCellDirtyStateChanged

        If dataGridView1.IsCurrentCellDirty Then
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    ' If a check box cell is clicked, this event handler disables  
    ' or enables the button in the same row as the clicked cell.
    Public Sub dataGridView1_CellValueChanged(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellValueChanged

        If dataGridView1.Columns(e.ColumnIndex).Name = "CheckBoxes" Then
            Dim buttonCell As DataGridViewDisableButtonCell = _
                CType(dataGridView1.Rows(e.RowIndex).Cells("Buttons"), _
                DataGridViewDisableButtonCell)

            Dim checkCell As DataGridViewCheckBoxCell = _
                CType(dataGridView1.Rows(e.RowIndex).Cells("CheckBoxes"), _
                DataGridViewCheckBoxCell)
            buttonCell.Enabled = Not CType(checkCell.Value, [Boolean])

            dataGridView1.Invalidate()
        End If
    End Sub
    ' </Snippet5>

    ' If the user clicks on an enabled button cell, this event handler  
    ' reports that the button is enabled.
    Sub dataGridView1_CellClick(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellClick

        If dataGridView1.Columns(e.ColumnIndex).Name = "Buttons" Then
            Dim buttonCell As DataGridViewDisableButtonCell = _
                CType(dataGridView1.Rows(e.RowIndex).Cells("Buttons"), _
                DataGridViewDisableButtonCell)

            If buttonCell.Enabled Then
                MsgBox(dataGridView1.Rows(e.RowIndex). _
                    Cells(e.ColumnIndex).Value.ToString() + _
                    " is enabled")
            End If
        End If
    End Sub

End Class

' <Snippet10>
Public Class DataGridViewDisableButtonColumn
    Inherits DataGridViewButtonColumn

    Public Sub New()
        Me.CellTemplate = New DataGridViewDisableButtonCell()
    End Sub
End Class
' </Snippet10>

Public Class DataGridViewDisableButtonCell
    Inherits DataGridViewButtonCell

    Private enabledValue As Boolean
    Public Property Enabled() As Boolean
        Get
            Return enabledValue
        End Get
        Set(ByVal value As Boolean)
            enabledValue = value
        End Set
    End Property

    ' Override the Clone method so that the Enabled property is copied.
    Public Overrides Function Clone() As Object
        Dim Cell As DataGridViewDisableButtonCell = _
            CType(MyBase.Clone(), DataGridViewDisableButtonCell)
        Cell.Enabled = Me.Enabled
        Return Cell
    End Function

    ' <Snippet15>
    ' By default, enable the button cell.
    Public Sub New()
        Me.enabledValue = True
    End Sub
    ' </Snippet15>

    ' <Snippet20>
    Protected Overrides Sub Paint(ByVal graphics As Graphics, _
        ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, _
        ByVal rowIndex As Integer, _
        ByVal elementState As DataGridViewElementStates, _
        ByVal value As Object, ByVal formattedValue As Object, _
        ByVal errorText As String, _
        ByVal cellStyle As DataGridViewCellStyle, _
        ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, _
        ByVal paintParts As DataGridViewPaintParts)

        ' The button cell is disabled, so paint the border,  
        ' background, and disabled button for the cell.
        If Not Me.enabledValue Then

            ' Draw the background of the cell, if specified.
            If (paintParts And DataGridViewPaintParts.Background) = _
                DataGridViewPaintParts.Background Then

                Dim cellBackground As New SolidBrush(cellStyle.BackColor)
                graphics.FillRectangle(cellBackground, cellBounds)
                cellBackground.Dispose()
            End If

            ' Draw the cell borders, if specified.
            If (paintParts And DataGridViewPaintParts.Border) = _
                DataGridViewPaintParts.Border Then

                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, _
                    advancedBorderStyle)
            End If

            ' Calculate the area in which to draw the button.
            Dim buttonArea As Rectangle = cellBounds
            Dim buttonAdjustment As Rectangle = _
                Me.BorderWidths(advancedBorderStyle)
            buttonArea.X += buttonAdjustment.X
            buttonArea.Y += buttonAdjustment.Y
            buttonArea.Height -= buttonAdjustment.Height
            buttonArea.Width -= buttonAdjustment.Width

            ' Draw the disabled button.                
            ButtonRenderer.DrawButton(graphics, buttonArea, _
                PushButtonState.Disabled)

            ' Draw the disabled button text. 
            If TypeOf Me.FormattedValue Is String Then
                TextRenderer.DrawText(graphics, CStr(Me.FormattedValue), _
                    Me.DataGridView.Font, buttonArea, SystemColors.GrayText)
            End If

        Else
            ' The button cell is enabled, so let the base class 
            ' handle the painting.
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, _
                elementState, value, formattedValue, errorText, _
                cellStyle, advancedBorderStyle, paintParts)
        End If
    End Sub
    ' </Snippet20>

End Class
' </Snippet0>