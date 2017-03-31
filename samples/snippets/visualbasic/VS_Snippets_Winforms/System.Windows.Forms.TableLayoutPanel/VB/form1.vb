' <snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Layout
Imports System.Diagnostics

Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim tlpGrowStyle As TableLayoutPanelGrowStyle = _
    TableLayoutPanelGrowStyle.AddRows
 
    ' <snippet2>
    Private Sub enumerateChildrenBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles enumerateChildrenBtn.Click

        Dim c As Control
        For Each c In Me.TableLayoutPanel1.Controls

            Trace.WriteLine(c.ToString())

        Next

    End Sub
    ' </snippet2>

    ' <snippet3>
    Private Sub getColumnBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles getColumnBtn.Click

        Dim c As Control
        For Each c In Me.TableLayoutPanel1.Controls

            Trace.WriteLine(Me.TableLayoutPanel1.GetColumn(c))

        Next

    End Sub
    ' </snippet3>


    ' <snippet4>
    Private Sub getRowBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles getRowBtn.Click

        Dim c As Control
        For Each c In Me.TableLayoutPanel1.Controls

            Trace.WriteLine(Me.TableLayoutPanel1.GetRow(c))

        Next

    End Sub
    ' </snippet4>

    ' <snippet5>
    Private Sub getcontrolFromPosBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles getcontrolFromPosBtn.Click

        Dim i As Integer = 0
        Dim j As Integer = 0
        Trace.WriteLine(Me.TableLayoutPanel1.ColumnCount)
        Trace.WriteLine(Me.TableLayoutPanel1.RowCount)

        For i = 0 To Me.TableLayoutPanel1.ColumnCount
            For j = 0 To Me.TableLayoutPanel1.RowCount

                Dim c As Control = Me.TableLayoutPanel1.GetControlFromPosition(i, j)

                If c IsNot Nothing Then

                    Trace.WriteLine(c.ToString())

                End If
            Next
        Next

    End Sub
    ' </snippet5>

    ' <snippet12>
    Private Sub swapControlsBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles swapControlsBtn.Click

        Dim c1 As Control = Me.TableLayoutPanel1.GetControlFromPosition(0, 0)
        Dim c2 As Control = Me.TableLayoutPanel1.GetControlFromPosition(0, 1)

        If c1 IsNot Nothing And c2 IsNot Nothing Then

            Me.TableLayoutPanel1.SetColumn(c2, 0)
            Me.TableLayoutPanel1.SetColumn(c1, 1)

        End If

    End Sub
    ' </snippet12>

    ' <snippet13>
    Private Sub swapRowsBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles swapRowsBtn.Click

        Dim c1 As Control = Me.TableLayoutPanel1.GetControlFromPosition(0, 0)
        Dim c2 As Control = Me.TableLayoutPanel1.GetControlFromPosition(1, 0)

        If c1 IsNot Nothing And c2 IsNot Nothing Then

            Me.TableLayoutPanel1.SetRow(c2, 0)
            Me.TableLayoutPanel1.SetRow(c1, 1)

        End If


    End Sub
    ' </snippet13>

    ' <snippet6>
    Private Sub borderStyleOutsetRadioBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles borderStyleOutsetRadioBtn.CheckedChanged

        Me.TableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset

    End Sub

    Private Sub borderStyleNoneRadioBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles borderStyleNoneRadioBtn.CheckedChanged

        Me.TableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None

    End Sub

    Private Sub borderStyleInsetRadioBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles borderStyleInsetRadioBtn.CheckedChanged

        Me.TableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset

    End Sub
    ' </snippet6>

    ' <snippet7>
    Private Sub growStyleNoneBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles growStyleNoneBtn.CheckedChanged

        Me.tlpGrowStyle = TableLayoutPanelGrowStyle.FixedSize

    End Sub

    Private Sub growStyleAddRowBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles growStyleAddRowBtn.CheckedChanged

        Me.tlpGrowStyle = TableLayoutPanelGrowStyle.AddRows

    End Sub

    Private Sub growStyleAddColumnBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles growStyleAddColumnBtn.CheckedChanged

        Me.tlpGrowStyle = TableLayoutPanelGrowStyle.AddColumns

    End Sub

    Private Sub testGrowStyleBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles testGrowStyleBtn.Click

        Me.TableLayoutPanel1.GrowStyle = Me.tlpGrowStyle

        Try

            Me.TableLayoutPanel1.Controls.Add(New Button())

        Catch ex As ArgumentException

            Trace.WriteLine(ex.Message)

        End Try

    End Sub
    ' </snippet7>

    ' <snippet8>
    Private Sub toggleColumnStylesBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles toggleColumnStylesBtn.Click

        Dim styles As TableLayoutColumnStyleCollection = _
        Me.TableLayoutPanel1.ColumnStyles

        For Each style As ColumnStyle In styles

            If style.SizeType = SizeType.Absolute Then

                style.SizeType = SizeType.AutoSize

            ElseIf style.SizeType = SizeType.AutoSize Then

                style.SizeType = SizeType.Percent

                ' Set the column width to be a percentage
                ' of the TableLayoutPanel control's width.
                style.Width = 33

            Else

                ' Set the column width to 50 pixels.
                style.SizeType = SizeType.Absolute
                style.Width = 50

            End If

        Next

    End Sub
    ' </snippet8>

    ' <snippet9>
    Private Sub toggleRowStylesBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles toggleRowStylesBtn.Click

        Dim styles As TableLayoutRowStyleCollection = _
        Me.TableLayoutPanel1.RowStyles

        For Each style As RowStyle In styles

            If style.SizeType = SizeType.Absolute Then

                style.SizeType = SizeType.AutoSize

            ElseIf style.SizeType = SizeType.AutoSize Then

                style.SizeType = SizeType.Percent

                ' Set the row height to be a percentage
                ' of the TableLayoutPanel control's height.
                style.Height = 33

            Else

                ' Set the row height to 50 pixels.
                style.SizeType = SizeType.Absolute
                style.Height = 50

            End If

        Next

    End Sub
    ' </snippet9>

    ' <snippet10>
    Private Sub TableLayoutPanel1_PaintCell( _
    ByVal sender As Object, _
    ByVal e As System.Windows.Forms.TableLayoutCellPaintEventArgs) _
    Handles TableLayoutPanel1.CellPaint

        Dim g As Graphics = e.Graphics

        g.FillEllipse( _
        Brushes.ForestGreen, _
        New Rectangle( _
            e.ClipRectangle.X + 2, _
            e.ClipRectangle.Y + 2, _
            e.ClipRectangle.Width - 4, _
            e.ClipRectangle.Height - 4))



        g.DrawRectangle( _
        Pens.Red, _
        New Rectangle( _
            e.ClipRectangle.X + 2, _
            e.ClipRectangle.Y + 2, _
            e.ClipRectangle.Width - 4, _
            e.ClipRectangle.Height - 4))

    End Sub
    ' </snippet10>

    ' <snippet11>
    Private Sub toggleSpanBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles toggleSpanBtn.Click

        Dim c As Control = Me.TableLayoutPanel1.GetControlFromPosition(0, 0)

        If c IsNot Nothing Then

            Dim xSpan As Integer = Me.TableLayoutPanel1.GetColumnSpan(c)
            Dim ySpan As Integer = Me.TableLayoutPanel1.GetRowSpan(c)

            If xSpan > 1 Then

                xSpan = 1
                ySpan = 1

            Else

                xSpan = 2
                ySpan = 2

            End If

            Me.TableLayoutPanel1.SetColumnSpan(c, xSpan)
            Me.TableLayoutPanel1.SetRowSpan(c, ySpan)

        End If

    End Sub
    ' </snippet11>

    ' <snippet14>
    Private Sub toggleMarginsBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles toggleMarginsBtn.Click

        For Each c As Control In Me.TableLayoutPanel1.Controls

            If c.Margin.All > 5 Then

                Dim m As Padding = c.Margin
                m.All = 5
                c.Margin = m

            Else

                Dim m As Padding = c.Margin
                m.All = 10
                c.Margin = m

            End If

        Next

    End Sub
    ' </snippet14>

    ' <snippet15>
    Private Sub togglePaddingBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles togglePaddingBtn.Click

        If Me.TableLayoutPanel1.Padding.All > 5 Then

            Dim p As Padding = Me.TableLayoutPanel1.Padding
            p.All = 5
            Me.TableLayoutPanel1.Padding = p

        Else

            Dim p As Padding = Me.TableLayoutPanel1.Padding
            p.All = 10
            Me.TableLayoutPanel1.Padding = p

        End If

    End Sub
    ' </snippet15>

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents enumerateChildrenBtn As System.Windows.Forms.Button
    Friend WithEvents testGrowStyleBtn As System.Windows.Forms.Button
    Friend WithEvents getColumnBtn As System.Windows.Forms.Button
    Friend WithEvents getcontrolFromPosBtn As System.Windows.Forms.Button
    Friend WithEvents getRowBtn As System.Windows.Forms.Button
    Friend WithEvents swapControlsBtn As System.Windows.Forms.Button
    Friend WithEvents borderStyleNoneRadioBtn As System.Windows.Forms.RadioButton
    Friend WithEvents borderStyleOutsetRadioBtn As System.Windows.Forms.RadioButton
    Friend WithEvents borderStyleInsetRadioBtn As System.Windows.Forms.RadioButton
    Friend WithEvents growStyleNoneBtn As System.Windows.Forms.RadioButton
    Friend WithEvents growStyleAddRowBtn As System.Windows.Forms.RadioButton
    Friend WithEvents growStyleAddColumnBtn As System.Windows.Forms.RadioButton
    Friend WithEvents toggleColumnStylesBtn As System.Windows.Forms.Button
    Friend WithEvents DemoTableLayoutPanel1 As DemoTableLayoutPanel
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents toggleRowStylesBtn As System.Windows.Forms.Button
    Friend WithEvents toggleSpanBtn As System.Windows.Forms.Button
    Friend WithEvents swapRowsBtn As System.Windows.Forms.Button
    Friend WithEvents toggleMarginsBtn As System.Windows.Forms.Button
    Friend WithEvents togglePaddingBtn As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer



   

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.enumerateChildrenBtn = New System.Windows.Forms.Button
        Me.testGrowStyleBtn = New System.Windows.Forms.Button
        Me.getColumnBtn = New System.Windows.Forms.Button
        Me.getcontrolFromPosBtn = New System.Windows.Forms.Button
        Me.getRowBtn = New System.Windows.Forms.Button
        Me.swapControlsBtn = New System.Windows.Forms.Button
        Me.borderStyleNoneRadioBtn = New System.Windows.Forms.RadioButton
        Me.borderStyleOutsetRadioBtn = New System.Windows.Forms.RadioButton
        Me.borderStyleInsetRadioBtn = New System.Windows.Forms.RadioButton
        Me.growStyleNoneBtn = New System.Windows.Forms.RadioButton
        Me.growStyleAddRowBtn = New System.Windows.Forms.RadioButton
        Me.growStyleAddColumnBtn = New System.Windows.Forms.RadioButton
        Me.toggleColumnStylesBtn = New System.Windows.Forms.Button
        Me.DemoTableLayoutPanel1 = New DemoTableLayoutPanel
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.toggleRowStylesBtn = New System.Windows.Forms.Button
        Me.toggleSpanBtn = New System.Windows.Forms.Button
        Me.swapRowsBtn = New System.Windows.Forms.Button
        Me.toggleMarginsBtn = New System.Windows.Forms.Button
        Me.togglePaddingBtn = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.DemoTableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button4, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(123, 24)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(286, 230)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.Location = New System.Drawing.Point(105, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Location = New System.Drawing.Point(105, 155)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button3.Location = New System.Drawing.Point(105, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Button3"
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TableLayoutPanel1.SetColumnSpan(Me.Button4, 3)
        Me.Button4.Location = New System.Drawing.Point(26, 38)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(234, 30)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Button4"
        '
        'enumerateChildrenBtn
        '
        Me.enumerateChildrenBtn.AutoSize = True
        Me.enumerateChildrenBtn.Location = New System.Drawing.Point(629, 274)
        Me.enumerateChildrenBtn.Name = "enumerateChildrenBtn"
        Me.enumerateChildrenBtn.Size = New System.Drawing.Size(105, 23)
        Me.enumerateChildrenBtn.TabIndex = 1
        Me.enumerateChildrenBtn.Text = "Enumerate Children"
        '
        'testGrowStyleBtn
        '
        Me.testGrowStyleBtn.AutoSize = True
        Me.testGrowStyleBtn.Location = New System.Drawing.Point(67, 274)
        Me.testGrowStyleBtn.Name = "testGrowStyleBtn"
        Me.testGrowStyleBtn.Size = New System.Drawing.Size(88, 23)
        Me.testGrowStyleBtn.TabIndex = 2
        Me.testGrowStyleBtn.Text = "Test GrowStyle"
        '
        'getColumnBtn
        '
        Me.getColumnBtn.Location = New System.Drawing.Point(165, 274)
        Me.getColumnBtn.Name = "getColumnBtn"
        Me.getColumnBtn.TabIndex = 3
        Me.getColumnBtn.Text = "GetColumn"
        '
        'getcontrolFromPosBtn
        '
        Me.getcontrolFromPosBtn.AutoSize = True
        Me.getcontrolFromPosBtn.Location = New System.Drawing.Point(329, 274)
        Me.getcontrolFromPosBtn.Name = "getcontrolFromPosBtn"
        Me.getcontrolFromPosBtn.Size = New System.Drawing.Size(123, 23)
        Me.getcontrolFromPosBtn.TabIndex = 4
        Me.getcontrolFromPosBtn.Text = "GetControlFromPosition"
        '
        'getRowBtn
        '
        Me.getRowBtn.Location = New System.Drawing.Point(247, 274)
        Me.getRowBtn.Name = "getRowBtn"
        Me.getRowBtn.TabIndex = 5
        Me.getRowBtn.Text = "GetRow"
        '
        'swapControlsBtn
        '
        Me.swapControlsBtn.AutoSize = True
        Me.swapControlsBtn.Location = New System.Drawing.Point(459, 274)
        Me.swapControlsBtn.Name = "swapControlsBtn"
        Me.swapControlsBtn.Size = New System.Drawing.Size(81, 23)
        Me.swapControlsBtn.TabIndex = 6
        Me.swapControlsBtn.Text = "Swap Controls"
        '
        'borderStyleNoneRadioBtn
        '
        Me.borderStyleNoneRadioBtn.Location = New System.Drawing.Point(35, 26)
        Me.borderStyleNoneRadioBtn.Name = "borderStyleNoneRadioBtn"
        Me.borderStyleNoneRadioBtn.Size = New System.Drawing.Size(52, 30)
        Me.borderStyleNoneRadioBtn.TabIndex = 8
        Me.borderStyleNoneRadioBtn.Text = "None"
        '
        'borderStyleOutsetRadioBtn
        '
        Me.borderStyleOutsetRadioBtn.AutoSize = True
        Me.borderStyleOutsetRadioBtn.Location = New System.Drawing.Point(35, 62)
        Me.borderStyleOutsetRadioBtn.Name = "borderStyleOutsetRadioBtn"
        Me.borderStyleOutsetRadioBtn.Size = New System.Drawing.Size(52, 25)
        Me.borderStyleOutsetRadioBtn.TabIndex = 9
        Me.borderStyleOutsetRadioBtn.Text = "Outset"
        '
        'borderStyleInsetRadioBtn
        '
        Me.borderStyleInsetRadioBtn.Location = New System.Drawing.Point(35, 92)
        Me.borderStyleInsetRadioBtn.Name = "borderStyleInsetRadioBtn"
        Me.borderStyleInsetRadioBtn.Size = New System.Drawing.Size(52, 25)
        Me.borderStyleInsetRadioBtn.TabIndex = 10
        Me.borderStyleInsetRadioBtn.Text = "Inset"
        '
        'growStyleNoneBtn
        '
        Me.growStyleNoneBtn.AutoSize = True
        Me.growStyleNoneBtn.Location = New System.Drawing.Point(67, 304)
        Me.growStyleNoneBtn.Name = "growStyleNoneBtn"
        Me.growStyleNoneBtn.TabIndex = 13
        Me.growStyleNoneBtn.Text = "Fixed"
        '
        'growStyleAddRowBtn
        '
        Me.growStyleAddRowBtn.AutoSize = True
        Me.growStyleAddRowBtn.Location = New System.Drawing.Point(67, 335)
        Me.growStyleAddRowBtn.Name = "growStyleAddRowBtn"
        Me.growStyleAddRowBtn.TabIndex = 14
        Me.growStyleAddRowBtn.Text = "Add Rows"
        '
        'growStyleAddColumnBtn
        '
        Me.growStyleAddColumnBtn.AutoSize = True
        Me.growStyleAddColumnBtn.Location = New System.Drawing.Point(67, 366)
        Me.growStyleAddColumnBtn.Name = "growStyleAddColumnBtn"
        Me.growStyleAddColumnBtn.TabIndex = 15
        Me.growStyleAddColumnBtn.Text = "Add Columns"
        '
        'toggleColumnStylesBtn
        '
        Me.toggleColumnStylesBtn.Location = New System.Drawing.Point(69, 397)
        Me.toggleColumnStylesBtn.Name = "toggleColumnStylesBtn"
        Me.toggleColumnStylesBtn.Size = New System.Drawing.Size(118, 24)
        Me.toggleColumnStylesBtn.TabIndex = 16
        Me.toggleColumnStylesBtn.Text = "Toggle ColumnStyles"
        '
        'DemoTableLayoutPanel1
        '
        Me.DemoTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.DemoTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.DemoTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.DemoTableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.DemoTableLayoutPanel1.Controls.Add(Me.Button12)
        Me.DemoTableLayoutPanel1.Controls.Add(Me.Button10, 0, 1)
        Me.DemoTableLayoutPanel1.Controls.Add(Me.Button11, 1, 1)
        Me.DemoTableLayoutPanel1.Location = New System.Drawing.Point(446, 24)
        Me.DemoTableLayoutPanel1.Name = "DemoTableLayoutPanel1"
        Me.DemoTableLayoutPanel1.RowCount = 2
        Me.DemoTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.DemoTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.DemoTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.DemoTableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.DemoTableLayoutPanel1.Size = New System.Drawing.Size(256, 230)
        Me.DemoTableLayoutPanel1.TabIndex = 11
        '
        'Button12
        '
        Me.Button12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button12.Location = New System.Drawing.Point(90, 13)
        Me.Button12.Name = "Button12"
        Me.Button12.TabIndex = 9
        Me.Button12.Text = "Button12"
        '
        'Button10
        '
        Me.Button10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button10.Location = New System.Drawing.Point(90, 63)
        Me.Button10.Name = "Button10"
        Me.Button10.TabIndex = 12
        Me.Button10.Text = "Button10"
        '
        'Button11
        '
        Me.Button11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button11.Location = New System.Drawing.Point(90, 153)
        Me.Button11.Name = "Button11"
        Me.Button11.TabIndex = 8
        Me.Button11.Text = "Button11"
        '
        'toggleRowStylesBtn
        '
        Me.toggleRowStylesBtn.Location = New System.Drawing.Point(67, 440)
        Me.toggleRowStylesBtn.Name = "toggleRowStylesBtn"
        Me.toggleRowStylesBtn.Size = New System.Drawing.Size(120, 22)
        Me.toggleRowStylesBtn.TabIndex = 17
        Me.toggleRowStylesBtn.Text = "Toggle RowStyles"
        '
        'toggleSpanBtn
        '
        Me.toggleSpanBtn.Location = New System.Drawing.Point(247, 398)
        Me.toggleSpanBtn.Name = "toggleSpanBtn"
        Me.toggleSpanBtn.TabIndex = 18
        Me.toggleSpanBtn.Text = "Toggle Span"
        '
        'swapRowsBtn
        '
        Me.swapRowsBtn.Location = New System.Drawing.Point(458, 305)
        Me.swapRowsBtn.Name = "swapRowsBtn"
        Me.swapRowsBtn.Size = New System.Drawing.Size(82, 23)
        Me.swapRowsBtn.TabIndex = 19
        Me.swapRowsBtn.Text = "Swap Rows"
        '
        'toggleMarginsBtn
        '
        Me.toggleMarginsBtn.Location = New System.Drawing.Point(328, 397)
        Me.toggleMarginsBtn.Name = "toggleMarginsBtn"
        Me.toggleMarginsBtn.Size = New System.Drawing.Size(93, 24)
        Me.toggleMarginsBtn.TabIndex = 20
        Me.toggleMarginsBtn.Text = "Toggle Margins"
        '
        'togglePaddingBtn
        '
        Me.togglePaddingBtn.Location = New System.Drawing.Point(458, 396)
        Me.togglePaddingBtn.Name = "togglePaddingBtn"
        Me.togglePaddingBtn.Size = New System.Drawing.Size(94, 23)
        Me.togglePaddingBtn.TabIndex = 21
        Me.togglePaddingBtn.Text = "Toggle Padding"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(773, 489)
        Me.Controls.Add(Me.togglePaddingBtn)
        Me.Controls.Add(Me.toggleMarginsBtn)
        Me.Controls.Add(Me.swapRowsBtn)
        Me.Controls.Add(Me.toggleSpanBtn)
        Me.Controls.Add(Me.toggleRowStylesBtn)
        Me.Controls.Add(Me.toggleColumnStylesBtn)
        Me.Controls.Add(Me.growStyleAddColumnBtn)
        Me.Controls.Add(Me.growStyleAddRowBtn)
        Me.Controls.Add(Me.growStyleNoneBtn)
        Me.Controls.Add(Me.DemoTableLayoutPanel1)
        Me.Controls.Add(Me.borderStyleInsetRadioBtn)
        Me.Controls.Add(Me.borderStyleOutsetRadioBtn)
        Me.Controls.Add(Me.borderStyleNoneRadioBtn)
        Me.Controls.Add(Me.swapControlsBtn)
        Me.Controls.Add(Me.getRowBtn)
        Me.Controls.Add(Me.getcontrolFromPosBtn)
        Me.Controls.Add(Me.getColumnBtn)
        Me.Controls.Add(Me.testGrowStyleBtn)
        Me.Controls.Add(Me.enumerateChildrenBtn)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.DemoTableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend Shared ReadOnly Property GetInstance() As Form1
        Get
            If m_DefaultInstance Is Nothing OrElse m_DefaultInstance.IsDisposed() Then
                SyncLock m_SyncObject
                    If m_DefaultInstance Is Nothing OrElse m_DefaultInstance.IsDisposed() Then
                        m_DefaultInstance = New Form1
                    End If
                End SyncLock
            End If
            Return m_DefaultInstance
        End Get
    End Property

    Private Shared m_DefaultInstance As Form1
    Private Shared m_SyncObject As New Object
#End Region

    
  
End Class

' <snippet100>
Public Class DemoTableLayoutPanel
    Inherits TableLayoutPanel

    Protected Overrides Sub OnCellPaint( _
    ByVal e As System.Windows.Forms.TableLayoutCellPaintEventArgs)

        MyBase.OnCellPaint(e)

        Dim c As Control = Me.GetControlFromPosition(e.Column, e.Row)

        If c IsNot Nothing Then
            Dim g As Graphics = e.Graphics

            g.DrawRectangle( _
            Pens.Red, _
            e.CellBounds.Location.X + 1, _
            e.CellBounds.Location.Y + 1, _
            e.CellBounds.Width - 2, _
            e.CellBounds.Height - 2)

            g.FillRectangle( _
            Brushes.Blue, _
            e.CellBounds.Location.X + 1, _
            e.CellBounds.Location.Y + 1, _
            e.CellBounds.Width - 2, _
            e.CellBounds.Height - 2)
        End If

    End Sub

End Class
' </snippet100>
' </snippet1>