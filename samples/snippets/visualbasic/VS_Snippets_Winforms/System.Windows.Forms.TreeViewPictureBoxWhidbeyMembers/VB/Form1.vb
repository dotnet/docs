
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Private WithEvents pictureBox1 As PictureBox
    Private WithEvents startLoadButton As Button
    Private progressBar1 As ProgressBar
    Private WithEvents cancelLoadButton As Button
    Private WithEvents treeView1 As TreeView
    
    
    Public Sub New() 
        InitializeComponent()
        
    
    End Sub 'New
     
    'Demonstrates the TreeViewHitTest method, TreeViewHitTestInfo and TreeViewHitTestLocations    
    '<snippet1>
    Private Sub HandleMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles Me.MouseDown, treeView1.MouseDown
        Dim info As TreeViewHitTestInfo = treeView1.HitTest(e.X, e.Y)
        If (info IsNot Nothing) Then
            MessageBox.Show("Hit the " + info.Location.ToString())
        End If

    End Sub
     '</snippet1>
    
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
    
    
    Private Sub InitializeComponent() 
        Dim treeNode5 As New System.Windows.Forms.TreeNode("Node2")
        Dim treeNode6 As New System.Windows.Forms.TreeNode("Node0", New System.Windows.Forms.TreeNode() {treeNode5})
        Dim treeNode7 As New System.Windows.Forms.TreeNode("Node3")
        Dim treeNode8 As New System.Windows.Forms.TreeNode("Node1", New System.Windows.Forms.TreeNode() {treeNode7})
        Me.treeView1 = New System.Windows.Forms.TreeView()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.startLoadButton = New System.Windows.Forms.Button()
        Me.progressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cancelLoadButton = New System.Windows.Forms.Button()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ' 
        ' treeView1
        ' 
        Me.treeView1.Location = New System.Drawing.Point(112, 87)
        Me.treeView1.Name = "treeView1"
        treeNode5.Name = "Node2"
        treeNode5.Text = "Node2"
        treeNode6.Name = "Node0"
        treeNode6.Text = "Node0"
        treeNode7.Name = "Node3"
        treeNode7.Text = "Node3"
        treeNode8.Name = "Node1"
        treeNode8.Text = "Node1"
        Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {treeNode6, treeNode8})
        Me.treeView1.Size = New System.Drawing.Size(121, 97)
        Me.treeView1.TabIndex = 0
        ' 
        ' pictureBox1
        ' 
        Me.pictureBox1.Location = New System.Drawing.Point(112, 12)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.pictureBox1.TabIndex = 1
        Me.pictureBox1.TabStop = False
        ' 
        ' startButton
        ' 
        Me.startLoadButton.Location = New System.Drawing.Point(21, 12)
        Me.startLoadButton.Name = "startButton"
        Me.startLoadButton.Size = New System.Drawing.Size(75, 23)
        Me.startLoadButton.TabIndex = 2
        Me.startLoadButton.Text = "button1"
        ' 
        ' progressBar1
        ' 
        Me.progressBar1.Location = New System.Drawing.Point(6, 55)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(100, 23)
        Me.progressBar1.TabIndex = 3
        ' 
        ' cancelButton
        ' 
        Me.cancelLoadButton.Location = New System.Drawing.Point(21, 101)
        Me.cancelLoadButton.Name = "cancelButton"
        Me.cancelLoadButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelLoadButton.TabIndex = 4
        Me.cancelLoadButton.Text = "button2"
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(cancelLoadButton)
        Me.Controls.Add(progressBar1)
        Me.Controls.Add(startLoadButton)
        Me.Controls.Add(pictureBox1)
        Me.Controls.Add(treeView1)
        Me.Name = "Form1"
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    
    End Sub 'InitializeComponent
     
    '<snippet4>
    Private Sub cancelLoadButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles cancelLoadButton.Click
        pictureBox1.CancelAsync()

    End Sub
    '</snippet4> 
    '<snippet3>
    Private Sub startLoadButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles startLoadButton.Click

        ' Ensure WaitOnLoad is false.
        pictureBox1.WaitOnLoad = False

        ' Load the image asynchronously.
        pictureBox1.LoadAsync("http://localhost/print.gif")

    End Sub
    
    '</snippet3>
    '<snippet5>
    Private Sub pictureBox1_LoadProgressChanged(ByVal sender As Object, _
        ByVal e As ProgressChangedEventArgs) _
        Handles pictureBox1.LoadProgressChanged

        progressBar1.Value = e.ProgressPercentage

    End Sub 
'</snippet5>
End Class 'Form1 