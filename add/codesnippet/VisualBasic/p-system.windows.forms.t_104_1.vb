Public Class Form1
    Inherits Form

    Private menuStrip1 As New MenuStrip()
    Private mainToolStripMenuItem As New ToolStripMenuItem()
    Private toolStripMenuItem1 As New ToolStripMenuItem()
    Private toolStripRadioButtonMenuItem1 As New ToolStripRadioButtonMenuItem()
    Private toolStripRadioButtonMenuItem2 As New ToolStripRadioButtonMenuItem()
    Private toolStripRadioButtonMenuItem3 As New ToolStripRadioButtonMenuItem()
    Private toolStripRadioButtonMenuItem4 As New ToolStripRadioButtonMenuItem()
    Private toolStripRadioButtonMenuItem5 As New ToolStripRadioButtonMenuItem()
    Private toolStripRadioButtonMenuItem6 As New ToolStripRadioButtonMenuItem()

    Public Sub New()

        Me.mainToolStripMenuItem.Text = "main"
        toolStripRadioButtonMenuItem1.Text = "option 1"
        toolStripRadioButtonMenuItem2.Text = "option 2"
        toolStripRadioButtonMenuItem3.Text = "option 2-1"
        toolStripRadioButtonMenuItem4.Text = "option 2-2"
        toolStripRadioButtonMenuItem5.Text = "option 3-1"
        toolStripRadioButtonMenuItem6.Text = "option 3-2"
        toolStripMenuItem1.Text = "toggle"
        toolStripMenuItem1.CheckOnClick = True

        mainToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() { _
            toolStripRadioButtonMenuItem1, toolStripRadioButtonMenuItem2, _
            toolStripMenuItem1})
        toolStripRadioButtonMenuItem2.DropDownItems.AddRange( _
            New ToolStripItem() {toolStripRadioButtonMenuItem3, _
            toolStripRadioButtonMenuItem4})
        toolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() { _
            toolStripRadioButtonMenuItem5, toolStripRadioButtonMenuItem6})

        menuStrip1.Items.AddRange(New ToolStripItem() {mainToolStripMenuItem})
        Controls.Add(menuStrip1)
        MainMenuStrip = menuStrip1
        Text = "ToolStripRadioButtonMenuItem demo"
    End Sub
End Class

Public Class Program

    <STAThread()> Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    End Sub

End Class