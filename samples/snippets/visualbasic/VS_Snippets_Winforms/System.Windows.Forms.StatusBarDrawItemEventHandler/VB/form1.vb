Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeStatusBarPanels()
        InitializeSimpleStatusBar()

        InitializeComponent()

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

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        Me.SuspendLayout()

        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)

        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
    '<snippet1>
    ' Initialize a single-panel status bar.  This is done
    ' by setting the Text property and setting ShowPanels to False.
    Private Sub InitializeSimpleStatusBar()

        ' Declare the StatusBar control
        Dim simpleStatusBar As New StatusBar

        ' Set the ShowPanels property to False.
        simpleStatusBar.ShowPanels = False

        ' Set the text.
        simpleStatusBar.Text = "This is a single-panel status bar"

        ' Set the width and anchor the StatusBar
        simpleStatusBar.Width = 200
        simpleStatusBar.Anchor = AnchorStyles.Top

        ' Add the StatusBar to the form.
        Me.Controls.Add(simpleStatusBar)

    End Sub
    '</snippet1>
    '<snippet2>
    Private StatusBar1 As StatusBar

    Private Sub InitializeStatusBarPanels()
        StatusBar1 = New StatusBar

        ' Create two StatusBarPanel objects.
        Dim panel1 As New StatusBarPanel
        Dim panel2 As New StatusBarPanel

        ' Set the style of the panels.  
        ' panel1 will be owner-drawn.
        panel1.Style = StatusBarPanelStyle.OwnerDraw

        ' The panel2 object will be drawn by the operating system.
        panel2.Style = StatusBarPanelStyle.Text

        ' Set the text of both panels to the same date string.
        panel1.Text = DateTime.Today.ToShortDateString()
        panel2.Text = DateTime.Today.ToShortDateString()

        ' Add both panels to the StatusBar.
        StatusBar1.Panels.Add(panel1)
        StatusBar1.Panels.Add(panel2)

        ' Make panels visible by setting the ShowPanels 
        ' property to True.
        StatusBar1.ShowPanels = True

        ' Use the AddHandler syntax to handle the DrawItem event
        ' for the owner-drawn panel.
        AddHandler StatusBar1.DrawItem, _
            New StatusBarDrawItemEventHandler( _
            AddressOf DrawCustomStatusBarPanel)
        Me.Controls.Add(StatusBar1)
    End Sub

    ' Draw the panel.
    Private Sub DrawCustomStatusBarPanel(ByVal sender As Object, _
        ByVal e As StatusBarDrawItemEventArgs)

        ' Draw a blue background in the owner-drawn panel.
        e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds)

        ' Create a StringFormat object to align text in the panel.
        Dim textFormat As New StringFormat

        ' Center the text in the middle of the line.
        textFormat.LineAlignment = StringAlignment.Center

        ' Align the text to the left.
        textFormat.Alignment = StringAlignment.Far

        ' Draw the panel's text in dark blue using the Panel 
        ' and Bounds properties of the StatusBarEventArgs object 
        ' and the StringFormat object.
        e.Graphics.DrawString(e.Panel.Text, StatusBar1.Font, _
              Brushes.DarkBlue, New RectangleF(e.Bounds.X, e.Bounds.Y, _
              e.Bounds.Width, e.Bounds.Height), textFormat)

    End Sub
    '</snippet2>

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub


End Class
