'<snippet00>
'<snippet10>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class ToolStripSpringTextBox
    Inherits ToolStripTextBox

    Public Overrides Function GetPreferredSize( _
        ByVal constrainingSize As Size) As Size

        ' Use the default size if the text box is on the overflow menu
        ' or is on a vertical ToolStrip.
        If IsOnOverflow Or Owner.Orientation = Orientation.Vertical Then
            Return DefaultSize
        End If

        ' Declare a variable to store the total available width as 
        ' it is calculated, starting with the display width of the 
        ' owning ToolStrip.
        Dim width As Int32 = Owner.DisplayRectangle.Width

        ' Subtract the width of the overflow button if it is displayed. 
        If Owner.OverflowButton.Visible Then
            width = width - Owner.OverflowButton.Width - _
                Owner.OverflowButton.Margin.Horizontal()
        End If

        ' Declare a variable to maintain a count of ToolStripSpringTextBox 
        ' items currently displayed in the owning ToolStrip. 
        Dim springBoxCount As Int32 = 0

        For Each item As ToolStripItem In Owner.Items

            ' Ignore items on the overflow menu.
            If item.IsOnOverflow Then Continue For

            If TypeOf item Is ToolStripSpringTextBox Then
                ' For ToolStripSpringTextBox items, increment the count and 
                ' subtract the margin width from the total available width.
                springBoxCount += 1
                width -= item.Margin.Horizontal
            Else
                ' For all other items, subtract the full width from the total
                ' available width.
                width = width - item.Width - item.Margin.Horizontal
            End If
        Next

        ' If there are multiple ToolStripSpringTextBox items in the owning
        ' ToolStrip, divide the total available width between them. 
        If springBoxCount > 1 Then width = CInt(width / springBoxCount)

        ' If the available width is less than the default width, use the
        ' default width, forcing one or more items onto the overflow menu.
        If width < DefaultSize.Width Then width = DefaultSize.Width

        ' Retrieve the preferred size from the base class, but change the
        ' width to the calculated width. 
        Dim preferredSize As Size = MyBase.GetPreferredSize(constrainingSize)
        preferredSize.Width = width
        Return preferredSize

    End Function
End Class
'</snippet10>

'<snippet20>
Public Class Form1
    Inherits Form

    Public Sub New()
        Dim toolStrip1 As New ToolStrip()
        With toolStrip1
            .Dock = DockStyle.Top
            .Items.Add(New ToolStripLabel("Address"))
            .Items.Add(New ToolStripSpringTextBox())
            .Items.Add(New ToolStripButton("Go"))
        End With
        Controls.Add(toolStrip1)
        Text = "ToolStripSpringTextBox demo"
    End Sub

End Class

Public Class Program

    <STAThread()> Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    End Sub

End Class
'</snippet20>
'</snippet00>