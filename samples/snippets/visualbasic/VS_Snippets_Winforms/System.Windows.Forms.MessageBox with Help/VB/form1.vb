'<Snippet1>
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
'</Snippet1>

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    <StaThread()> _
    Shared Sub Main()
        Application.Run(New Form1())
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

    Private WithEvents Button1 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(164, 117)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend Shared ReadOnly Property GetInstance() As Form1
        Get
            If m_DefaultInstance Is Nothing OrElse m_DefaultInstance.IsDisposed() Then
                SyncLock GetType(Form1)
                    If m_DefaultInstance Is Nothing OrElse m_DefaultInstance.IsDisposed() Then
                        m_DefaultInstance = New Form1
                    End If
                End SyncLock
            End If
            Return m_DefaultInstance
        End Get
    End Property

    Private Shared m_DefaultInstance As Form1

#End Region


    '<Snippet2>
    ' Display a message box with a Help button. Show a custom Help window
    ' by handling the HelpRequested event.
    Private Function AlertMessageWithCustomHelpWindow() As DialogResult

        ' Handle the HelpRequested event for the following message.
        AddHandler Me.HelpRequested, AddressOf Me.Form1_HelpRequested

        Me.Tag = "Message with Help button."

        ' Show a message box with OK and Help buttons.
        Dim r As DialogResult = MessageBox.Show("Message with Help button.", _
                                              "Help Caption", MessageBoxButtons.OK, _
                                              MessageBoxIcon.Question, _
                                              MessageBoxDefaultButton.Button1, _
                                              0, True)

        ' Remove the HelpRequested event handler to keep the event
        ' from being handled for other message boxes.
        RemoveHandler Me.HelpRequested, AddressOf Me.Form1_HelpRequested

        ' Return the dialog box result.
        Return r
    End Function

    Private Sub Form1_HelpRequested(ByVal sender As System.Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs)

        ' Create a custom Help window in response to the HelpRequested event.
        Dim helpForm As Form = New Form

        ' Set up the form position, size, and title caption.
        With helpForm
            .StartPosition = FormStartPosition.Manual
            .Size = New Size(200, 400)
            .DesktopLocation = New Point(Me.DesktopBounds.X + _
                                         Me.Size.Width, Me.DesktopBounds.Top)
            .Text = "Help Form"
        End With

        ' Create a label to contain the Help text.
        Dim helpLabel As Label = New Label

        ' Add the label to the form and set its text.
        helpForm.Controls.Add(helpLabel)
        helpLabel.Dock = DockStyle.Fill

        ' Use the sender parameter to identify the context of the Help request.
        ' The parameter must be cast to the Control type to get the Tag property.
        Dim senderControl As Control = CType(sender, Control)

        helpLabel.Text = "Help information shown in response to user action on the '" & _
                          CStr(senderControl.Tag) & "' message."

        ' Set the Help form to be owned by the main form. This helps
        ' to ensure that the Help form is disposed of.
        Me.AddOwnedForm(helpForm)

        ' Show the custom Help window.
        helpForm.Show()

        ' Indicate that the HelpRequested event is handled.
        hlpevent.Handled = True
    End Sub
    '</Snippet2>

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim d As DialogResult = AlertMessageWithCustomHelpWindow()

        '<Snippet3>
        ' Display a message box with a help button. 
        ' The Help button opens the Mspaint.chm Help file.
        Dim r1 As DialogResult = MessageBox.Show("Message with Help file.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, _
                                           0, _
                                           "mspaint.chm")
        '</Snippet3>

        '<Snippet4>
        ' Display a message box parented to the main form. 
        ' The Help button opens the Mspaint.chm Help file.
        Dim r2 As DialogResult = MessageBox.Show(Me, "Message with Help file.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, _
                                           0, _
                                           "mspaint.chm")
        '</Snippet4>

        '<Snippet5>
        ' Display a message box. The Help button opens 
        ' the Mspaint.chm Help file and shows the Help contents 
        ' on the Index tab.
        Dim r3 As DialogResult = MessageBox.Show("Message with Help file and Help navigator.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, _
                                           0, "mspaint.chm", _
                                           HelpNavigator.Index)

        '</Snippet5>

        '<Snippet6>
        ' Display message box parented to the main form. 
        ' The Help button opens the Mspaint.chm Help file
        ' and shows the Help contents on the Index tab.
        Dim r4 As DialogResult = MessageBox.Show(Me, _
                                              "Message with Help file and Help navigator.", _
                                              "Help Caption", MessageBoxButtons.OK, _
                                              MessageBoxIcon.Question, _
                                              MessageBoxDefaultButton.Button1, _
                                              0, "mspaint.chm", _
                                              HelpNavigator.Index)

        '</Snippet6>

        '<Snippet7>
        ' Display a message box. The Help button opens the Mspaint.chm Help file, 
        ' shows index with the "ovals" keyword selected, and displays the
        ' associated topic.
        Dim r5 As DialogResult = MessageBox.Show("Message with Help file and Help navigator with additional parameter.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, _
                                           0, "mspaint.chm", _
                                           HelpNavigator.KeywordIndex, "ovals")

        '</Snippet7>

        '<Snippet8>
        ' Display message box parented to the main form. 
        ' The Help button opens the Mspaint.chm Help file, 
        ' shows index with the "ovals" keyword selected, and displays the
        ' associated topic.
        Dim r6 As DialogResult = MessageBox.Show(Me, _
                                           "Message with Help file and Help navigator with additional parameter.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, _
                                           0, "mspaint.chm", _
                                           HelpNavigator.KeywordIndex, "ovals")

        '</Snippet8>

        '<Snippet9>
        ' Display a message box. The Help button opens the Mspaint.chm Help file, 
        ' and the "mspaint.chm::/paint_brush.htm" Help keyword shows the 
        ' associated topic.
        Dim r7 As DialogResult = MessageBox.Show("Message with Help file and keyword.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, 0, _
                                           "mspaint.chm", _
                                           "mspaint.chm::/paint_brush.htm")
        '</Snippet9>

        '<Snippet10>
        ' Display message box parented to the main form. 
        ' The Help button opens the Mspaint.chm Help file, 
        ' and the "mspaint.chm::/paint_brush.htm" Help keyword shows the 
        ' associated topic.
        Dim r8 As DialogResult = MessageBox.Show(Me, "Message with Help file and keyword.", _
                                           "Help Caption", MessageBoxButtons.OK, _
                                           MessageBoxIcon.Question, _
                                           MessageBoxDefaultButton.Button1, 0, _
                                           "mspaint.chm", _
                                           "mspaint.chm::/paint_brush.htm")
        '</Snippet10>

    End Sub


End Class
