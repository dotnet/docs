' This entire sample can go in DataGridViewAdvancedBorderStyle class overview.
'  - Snippet10 can go in DataGridView.EnableHeadersVisualStyles property (state in the
'    Example intro that EnableVisualStyles() was called for the app itself, so setting
'    this property to false overrides that).
'  - Snippet12 can go in DataGridView.AdjustedTopLeftHeaderBorderStyle property
'  - Snippet15 can go in DataGridView.AdjustColumnHeaderBorderStyle()
'  - Snippet20 can go in DataGridViewCell.AdjustCellBorderStyle()
'  - Snippet30 can go in DataGridViewRow.AdjustRowHeaderBorderStyle()

' <Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms


Namespace DataGridViewAdvancedBorderStyleSample

    Class Form1
        Inherits Form

        <STAThreadAttribute()> _
        Public Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub

        Public Sub New()
            Me.AutoSize = True
            Me.Controls.Add(New CustomDataGridView())
            Me.Text = "DataGridView advanced border styles demo"
        End Sub
    End Class

    Public Class CustomDataGridView
        Inherits DataGridView

        ' <Snippet10>
        Public Sub New()
            With Me
                .RowTemplate = New DataGridViewCustomRow()
                .Columns.Add(New DataGridViewCustomColumn())
                .Columns.Add(New DataGridViewCustomColumn())
                .Columns.Add(New DataGridViewCustomColumn())
                .RowCount = 4
                .EnableHeadersVisualStyles = False
                .AutoSize = True
            End With
        End Sub
        ' </Snippet10>

        ' <Snippet12>
        Public Overrides ReadOnly Property AdjustedTopLeftHeaderBorderStyle() _
            As DataGridViewAdvancedBorderStyle
            Get
                Dim newStyle As New DataGridViewAdvancedBorderStyle()
                With newStyle
                    .Top = DataGridViewAdvancedCellBorderStyle.None
                    .Left = DataGridViewAdvancedCellBorderStyle.None
                    .Bottom = DataGridViewAdvancedCellBorderStyle.Outset
                    .Right = DataGridViewAdvancedCellBorderStyle.OutsetDouble
                End With
                Return newStyle
            End Get
        End Property
        ' </Snippet12>

        ' <Snippet15>
        Public Overrides Function AdjustColumnHeaderBorderStyle( _
            ByVal dataGridViewAdvancedBorderStyleInput As DataGridViewAdvancedBorderStyle, _
            ByVal dataGridViewAdvancedBorderStylePlaceHolder As DataGridViewAdvancedBorderStyle, _
            ByVal firstDisplayedColumn As Boolean, ByVal lastVisibleColumn As Boolean) _
            As DataGridViewAdvancedBorderStyle

            ' Customize the left border of the first column header and the
            ' bottom border of all the column headers. Use the input style for 
            ' all other borders.
            If firstDisplayedColumn Then
                dataGridViewAdvancedBorderStylePlaceHolder.Left = _
                    DataGridViewAdvancedCellBorderStyle.OutsetDouble
            Else
                dataGridViewAdvancedBorderStylePlaceHolder.Left = _
                    DataGridViewAdvancedCellBorderStyle.None
            End If

            With dataGridViewAdvancedBorderStylePlaceHolder
                .Bottom = DataGridViewAdvancedCellBorderStyle.Single
                .Right = dataGridViewAdvancedBorderStyleInput.Right
                .Top = dataGridViewAdvancedBorderStyleInput.Top
            End With

            Return dataGridViewAdvancedBorderStylePlaceHolder
        End Function
    End Class
    ' </Snippet15>

    Public Class DataGridViewCustomColumn
        Inherits DataGridViewColumn

        Public Sub New()
            Me.CellTemplate = New DataGridViewCustomCell()
        End Sub
    End Class

    Public Class DataGridViewCustomCell
        Inherits DataGridViewTextBoxCell

        ' <Snippet20>
        Public Overrides Function AdjustCellBorderStyle( _
            ByVal dataGridViewAdvancedBorderStyleInput As DataGridViewAdvancedBorderStyle, _
            ByVal dataGridViewAdvancedBorderStylePlaceHolder As DataGridViewAdvancedBorderStyle, _
            ByVal singleVerticalBorderAdded As Boolean, _
            ByVal singleHorizontalBorderAdded As Boolean, _
            ByVal firstVisibleColumn As Boolean, _
            ByVal firstVisibleRow As Boolean) As DataGridViewAdvancedBorderStyle

            ' Customize the top border of cells in the first row and the 
            ' right border of cells in the first column. Use the input style 
            ' for all other borders.
            If firstVisibleColumn Then
                dataGridViewAdvancedBorderStylePlaceHolder.Left = _
                    DataGridViewAdvancedCellBorderStyle.OutsetDouble
            Else
                dataGridViewAdvancedBorderStylePlaceHolder.Left = _
                    DataGridViewAdvancedCellBorderStyle.None
            End If

            If firstVisibleRow Then
                dataGridViewAdvancedBorderStylePlaceHolder.Top = _
                    DataGridViewAdvancedCellBorderStyle.InsetDouble
            Else
                dataGridViewAdvancedBorderStylePlaceHolder.Top = _
                    DataGridViewAdvancedCellBorderStyle.None
            End If

            With dataGridViewAdvancedBorderStylePlaceHolder
                .Right = dataGridViewAdvancedBorderStyleInput.Right
                .Bottom = dataGridViewAdvancedBorderStyleInput.Bottom
            End With

            Return dataGridViewAdvancedBorderStylePlaceHolder
        End Function
    End Class
    ' </Snippet20>

    Public Class DataGridViewCustomRow
        Inherits DataGridViewRow

        ' <Snippet30>
        Public Overrides Function AdjustRowHeaderBorderStyle( _
            ByVal dataGridViewAdvancedBorderStyleInput As DataGridViewAdvancedBorderStyle, _
            ByVal dataGridViewAdvancedBorderStylePlaceHolder As DataGridViewAdvancedBorderStyle, _
            ByVal singleVerticalBorderAdded As Boolean, _
            ByVal singleHorizontalBorderAdded As Boolean, _
            ByVal isFirstDisplayedRow As Boolean, _
            ByVal isLastDisplayedRow As Boolean) As DataGridViewAdvancedBorderStyle

            ' Customize the top border of the first row header and the
            ' right border of all the row headers. Use the input style for 
            ' all other borders.
            If isFirstDisplayedRow Then
                dataGridViewAdvancedBorderStylePlaceHolder.Top = _
                    DataGridViewAdvancedCellBorderStyle.InsetDouble
            Else
                dataGridViewAdvancedBorderStylePlaceHolder.Top = _
                    DataGridViewAdvancedCellBorderStyle.None
            End If

            With dataGridViewAdvancedBorderStylePlaceHolder
                .Right = DataGridViewAdvancedCellBorderStyle.OutsetDouble
                .Left = dataGridViewAdvancedBorderStyleInput.Left
                .Bottom = dataGridViewAdvancedBorderStyleInput.Bottom
            End With

            Return dataGridViewAdvancedBorderStylePlaceHolder
        End Function
    End Class
    '</Snippet30>

End Namespace
'</Snippet0>