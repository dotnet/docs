' <snippet1>

' <snippet2>
Imports System
Imports System.Windows.Forms
' </snippet2>

Public Class Form1
    Inherits System.Windows.Forms.Form

    ' <snippet3>
    Private Sub wrapContentsCheckBox_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles wrapContentsCheckBox.CheckedChanged

        Me.FlowLayoutPanel1.WrapContents = Me.wrapContentsCheckBox.Checked

    End Sub
    ' </snippet3>

    ' <snippet4>
    Private Sub flowTopDownBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles flowTopDownBtn.CheckedChanged

        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown

    End Sub

    Private Sub flowBottomUpBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles flowBottomUpBtn.CheckedChanged

        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.BottomUp

    End Sub

    Private Sub flowLeftToRight_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles flowLeftToRight.CheckedChanged

        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight

    End Sub

    Private Sub flowRightToLeftBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles flowRightToLeftBtn.CheckedChanged

        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft

    End Sub
    ' </snippet4>

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
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
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents wrapContentsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents flowTopDownBtn As System.Windows.Forms.RadioButton
    Friend WithEvents flowBottomUpBtn As System.Windows.Forms.RadioButton
    Friend WithEvents flowLeftToRight As System.Windows.Forms.RadioButton
    Friend WithEvents flowRightToLeftBtn As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.wrapContentsCheckBox = New System.Windows.Forms.CheckBox
        Me.flowTopDownBtn = New System.Windows.Forms.RadioButton
        Me.flowBottomUpBtn = New System.Windows.Forms.RadioButton
        Me.flowLeftToRight = New System.Windows.Forms.RadioButton
        Me.flowRightToLeftBtn = New System.Windows.Forms.RadioButton
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button4)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(47, 55)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'wrapContentsCheckBox
        '
        Me.wrapContentsCheckBox.Location = New System.Drawing.Point(46, 162)
        Me.wrapContentsCheckBox.Name = "wrapContentsCheckBox"
        Me.wrapContentsCheckBox.TabIndex = 1
        Me.wrapContentsCheckBox.Text = "Wrap Contents"
        '
        'flowTopDownBtn
        '
        Me.flowTopDownBtn.Location = New System.Drawing.Point(45, 193)
        Me.flowTopDownBtn.Name = "flowTopDownBtn"
        Me.flowTopDownBtn.TabIndex = 2
        Me.flowTopDownBtn.Text = "Flow TopDown"
        '
        'flowBottomUpBtn
        '
        Me.flowBottomUpBtn.Location = New System.Drawing.Point(44, 224)
        Me.flowBottomUpBtn.Name = "flowBottomUpBtn"
        Me.flowBottomUpBtn.TabIndex = 3
        Me.flowBottomUpBtn.Text = "Flow BottomUp"
        '
        'flowLeftToRight
        '
        Me.flowLeftToRight.Location = New System.Drawing.Point(156, 193)
        Me.flowLeftToRight.Name = "flowLeftToRight"
        Me.flowLeftToRight.TabIndex = 4
        Me.flowLeftToRight.Text = "Flow LeftToRight"
        '
        'flowRightToLeftBtn
        '
        Me.flowRightToLeftBtn.Location = New System.Drawing.Point(155, 224)
        Me.flowRightToLeftBtn.Name = "flowRightToLeftBtn"
        Me.flowRightToLeftBtn.TabIndex = 5
        Me.flowRightToLeftBtn.Text = "Flow RightToLeft"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(84, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(3, 32)
        Me.Button3.Name = "Button3"
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Button3"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(84, 32)
        Me.Button4.Name = "Button4"
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Button4"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.flowRightToLeftBtn)
        Me.Controls.Add(Me.flowLeftToRight)
        Me.Controls.Add(Me.flowBottomUpBtn)
        Me.Controls.Add(Me.flowTopDownBtn)
        Me.Controls.Add(Me.wrapContentsCheckBox)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

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
' </snippet1>
