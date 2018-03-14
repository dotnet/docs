Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Populate_ListBox()

        'Add any initialization after the InitializeComponent() call

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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As FunButton
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Button1 = New FunButton
        Button1.Text = "CLICK"
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'ListBox1
        Me.Button1.Location = New System.Drawing.Point(40, 40)
        '
        Me.ListBox1.Location = New System.Drawing.Point(88, 112)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 1
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
    '
    ' Add this method to a form containing a ListBox control named ListBox1.
    ' Call the method in the constructor or Load method of the form.


    '<snippet1>

    ' The following method displays the default font, 
    ' background color and foreground color values for the ListBox  
    ' control. The values are displayed in the ListBox, itself.

    Private Sub Populate_ListBox()
        ListBox1.Dock = DockStyle.Bottom

        ' Display the values in the read-only properties 
        ' DefaultBackColor, DefaultFont, DefaultForecolor.
        ListBox1.Items.Add("Default BackColor: " & ListBox.DefaultBackColor.ToString)
        ListBox1.Items.Add("Default Font: " & ListBox.DefaultFont.ToString)
        ListBox1.Items.Add("Default ForeColor:" & ListBox.DefaultForeColor.ToString)

    End Sub
    '</snippet1>
End Class

' To use this example create a new form and paste this class 
' forming the same file, after the form class in the same file.  
' Add a button of type FunButton to the form. 


'<snippet2>
Public Class FunButton
    Inherits Button

    Protected Overrides Sub OnMouseHover(ByVal e As System.EventArgs)

        ' Get the font size in Points, add one to the
        ' size, and reset the button's font to the larger
        ' size.
        Dim fontSize As Single = Font.SizeInPoints
        fontSize += 1
        Dim buttonSize As System.Drawing.Size = Size
        Me.Font = New System.Drawing.Font _
            (Font.FontFamily, fontSize, Font.Style)

        ' Increase the size width and height of the button 
        ' by 5 points each.
        Size = New System.Drawing.Size _
            (Size.Width + 5, Size.Height + 5)

        ' Call myBase.OnMouseHover to activate the delegate.
        MyBase.OnMouseHover(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)

        ' Make the cursor the Hand cursor when the mouse moves 
        ' over the button.
        Cursor = Cursors.Hand

        ' Call MyBase.OnMouseMove to activate the delegate.
        MyBase.OnMouseMove(e)
    End Sub
    '</snippet2>

      <System.STAThreadAttribute()>Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
