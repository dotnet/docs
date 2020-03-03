Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.GetLinksFromFramesButton = New System.Windows.Forms.Button
        Me.ShowModalDialogButton = New System.Windows.Forms.Button
        Me.OpenNewWindowOverBrowserButton = New System.Windows.Forms.Button
        Me.SetWindowStatusButton = New System.Windows.Forms.Button
        Me.ResetFramesButton = New System.Windows.Forms.Button
        Me.BalanceWindowButton = New System.Windows.Forms.Button
        Me.NewOrderButton = New System.Windows.Forms.Button
        Me.OpenThreeWindowsButton = New System.Windows.Forms.Button
        Me.WindowOpenOnExeButton = New System.Windows.Forms.Button
        Me.DisplayWindow1Button = New System.Windows.Forms.Button
        Me.DisplayWindow2Button = New System.Windows.Forms.Button
        Me.EnableClickScrollButton = New System.Windows.Forms.Button
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.WindowTimeout = New System.Windows.Forms.Timer(Me.components)
        Me.ResizeWindowButton = New System.Windows.Forms.Button
        Me.SuppressScriptErrorsButton = New System.Windows.Forms.Button
        Me.OpenRestrictedWindowButton = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.GetLinksFromFramesButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.ShowModalDialogButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.OpenNewWindowOverBrowserButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.SetWindowStatusButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.ResetFramesButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.BalanceWindowButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.NewOrderButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.OpenThreeWindowsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.WindowOpenOnExeButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.DisplayWindow1Button)
        Me.FlowLayoutPanel1.Controls.Add(Me.DisplayWindow2Button)
        Me.FlowLayoutPanel1.Controls.Add(Me.EnableClickScrollButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.ResizeWindowButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.SuppressScriptErrorsButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.OpenRestrictedWindowButton)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(919, 133)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'GetLinksFromFramesButton
        '
        Me.GetLinksFromFramesButton.Location = New System.Drawing.Point(3, 3)
        Me.GetLinksFromFramesButton.Name = "GetLinksFromFramesButton"
        Me.GetLinksFromFramesButton.Size = New System.Drawing.Size(202, 23)
        Me.GetLinksFromFramesButton.TabIndex = 0
        Me.GetLinksFromFramesButton.Text = "Get Links From Frames"
        '
        'ShowModalDialogButton
        '
        Me.ShowModalDialogButton.Location = New System.Drawing.Point(211, 3)
        Me.ShowModalDialogButton.Name = "ShowModalDialogButton"
        Me.ShowModalDialogButton.Size = New System.Drawing.Size(170, 23)
        Me.ShowModalDialogButton.TabIndex = 1
        Me.ShowModalDialogButton.Text = "Show Modal Dialog"
        '
        'OpenNewWindowOverBrowserButton
        '
        Me.OpenNewWindowOverBrowserButton.Location = New System.Drawing.Point(387, 3)
        Me.OpenNewWindowOverBrowserButton.Name = "OpenNewWindowOverBrowserButton"
        Me.OpenNewWindowOverBrowserButton.Size = New System.Drawing.Size(207, 23)
        Me.OpenNewWindowOverBrowserButton.TabIndex = 2
        Me.OpenNewWindowOverBrowserButton.Text = "Open New Window Over Browser"
        '
        'SetWindowStatusButton
        '
        Me.SetWindowStatusButton.Location = New System.Drawing.Point(600, 3)
        Me.SetWindowStatusButton.Name = "SetWindowStatusButton"
        Me.SetWindowStatusButton.Size = New System.Drawing.Size(170, 23)
        Me.SetWindowStatusButton.TabIndex = 3
        Me.SetWindowStatusButton.Text = "Set Window Status"
        '
        'ResetFramesButton
        '
        Me.ResetFramesButton.Location = New System.Drawing.Point(3, 32)
        Me.ResetFramesButton.Name = "ResetFramesButton"
        Me.ResetFramesButton.Size = New System.Drawing.Size(165, 23)
        Me.ResetFramesButton.TabIndex = 4
        Me.ResetFramesButton.Text = "Reset Frames"
        '
        'BalanceWindowButton
        '
        Me.BalanceWindowButton.Location = New System.Drawing.Point(174, 32)
        Me.BalanceWindowButton.Name = "BalanceWindowButton"
        Me.BalanceWindowButton.Size = New System.Drawing.Size(152, 23)
        Me.BalanceWindowButton.TabIndex = 5
        Me.BalanceWindowButton.Text = "Balance Window"
        '
        'NewOrderButton
        '
        Me.NewOrderButton.Location = New System.Drawing.Point(332, 32)
        Me.NewOrderButton.Name = "NewOrderButton"
        Me.NewOrderButton.Size = New System.Drawing.Size(188, 23)
        Me.NewOrderButton.TabIndex = 6
        Me.NewOrderButton.Text = "New Order"
        '
        'OpenThreeWindowsButton
        '
        Me.OpenThreeWindowsButton.Location = New System.Drawing.Point(526, 32)
        Me.OpenThreeWindowsButton.Name = "OpenThreeWindowsButton"
        Me.OpenThreeWindowsButton.Size = New System.Drawing.Size(190, 23)
        Me.OpenThreeWindowsButton.TabIndex = 7
        Me.OpenThreeWindowsButton.Text = "Open Three Windows"
        '
        'WindowOpenOnExeButton
        '
        Me.WindowOpenOnExeButton.Location = New System.Drawing.Point(722, 32)
        Me.WindowOpenOnExeButton.Name = "WindowOpenOnExeButton"
        Me.WindowOpenOnExeButton.Size = New System.Drawing.Size(185, 23)
        Me.WindowOpenOnExeButton.TabIndex = 8
        Me.WindowOpenOnExeButton.Text = "Window Open on EXE"
        '
        'DisplayWindow1Button
        '
        Me.DisplayWindow1Button.Location = New System.Drawing.Point(3, 61)
        Me.DisplayWindow1Button.Name = "DisplayWindow1Button"
        Me.DisplayWindow1Button.Size = New System.Drawing.Size(125, 23)
        Me.DisplayWindow1Button.TabIndex = 9
        Me.DisplayWindow1Button.Text = "Display Window 1"
        '
        'DisplayWindow2Button
        '
        Me.DisplayWindow2Button.Location = New System.Drawing.Point(134, 61)
        Me.DisplayWindow2Button.Name = "DisplayWindow2Button"
        Me.DisplayWindow2Button.Size = New System.Drawing.Size(141, 23)
        Me.DisplayWindow2Button.TabIndex = 10
        Me.DisplayWindow2Button.Text = "Display Window 2"
        '
        'EnableClickScrollButton
        '
        Me.EnableClickScrollButton.Location = New System.Drawing.Point(281, 61)
        Me.EnableClickScrollButton.Name = "EnableClickScrollButton"
        Me.EnableClickScrollButton.Size = New System.Drawing.Size(150, 23)
        Me.EnableClickScrollButton.TabIndex = 11
        Me.EnableClickScrollButton.Text = "Enable Click Scroll"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 133)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(919, 421)
        Me.WebBrowser1.TabIndex = 1
        '
        'WindowTimeout
        '
        '
        'ResizeWindowButton
        '
        Me.ResizeWindowButton.Location = New System.Drawing.Point(437, 61)
        Me.ResizeWindowButton.Name = "ResizeWindowButton"
        Me.ResizeWindowButton.Size = New System.Drawing.Size(174, 23)
        Me.ResizeWindowButton.TabIndex = 12
        Me.ResizeWindowButton.Text = "Resize Window"
        '
        'SuppressScriptErrorsButton
        '
        Me.SuppressScriptErrorsButton.Location = New System.Drawing.Point(617, 61)
        Me.SuppressScriptErrorsButton.Name = "SuppressScriptErrorsButton"
        Me.SuppressScriptErrorsButton.Size = New System.Drawing.Size(193, 23)
        Me.SuppressScriptErrorsButton.TabIndex = 13
        Me.SuppressScriptErrorsButton.Text = "Suppress Script Errors"
        '
        'OpenRestrictedWindowButton
        '
        Me.OpenRestrictedWindowButton.Location = New System.Drawing.Point(3, 90)
        Me.OpenRestrictedWindowButton.Name = "OpenRestrictedWindowButton"
        Me.OpenRestrictedWindowButton.Size = New System.Drawing.Size(198, 23)
        Me.OpenRestrictedWindowButton.TabIndex = 14
        Me.OpenRestrictedWindowButton.Text = "Open Restricted Window"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(919, 554)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GetLinksFromFramesButton As System.Windows.Forms.Button
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ShowModalDialogButton As System.Windows.Forms.Button
    Friend WithEvents OpenNewWindowOverBrowserButton As System.Windows.Forms.Button
    Friend WithEvents SetWindowStatusButton As System.Windows.Forms.Button
    Friend WithEvents ResetFramesButton As System.Windows.Forms.Button
    Friend WithEvents BalanceWindowButton As System.Windows.Forms.Button
    Friend WithEvents WindowTimeout As System.Windows.Forms.Timer
    Friend WithEvents NewOrderButton As System.Windows.Forms.Button
    Friend WithEvents OpenThreeWindowsButton As System.Windows.Forms.Button
    Friend WithEvents WindowOpenOnExeButton As System.Windows.Forms.Button
    Friend WithEvents DisplayWindow1Button As System.Windows.Forms.Button
    Friend WithEvents DisplayWindow2Button As System.Windows.Forms.Button
    Friend WithEvents EnableClickScrollButton As System.Windows.Forms.Button
    Friend WithEvents ResizeWindowButton As System.Windows.Forms.Button
    Friend WithEvents SuppressScriptErrorsButton As System.Windows.Forms.Button
    Friend WithEvents OpenRestrictedWindowButton As System.Windows.Forms.Button

End Class
