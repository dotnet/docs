Imports System
Imports System.Windows.Forms

' <Snippet1>
Public Class Form1
    Inherits System.Windows.Forms.Form
    ' Required designer variable.
    Private components As System.ComponentModel.Container
    
    ' Declares variables.
    Private tab3RadioButton2 As System.Windows.Forms.RadioButton
    Private tab3RadioButton1 As System.Windows.Forms.RadioButton
    Private tab2CheckBox3 As System.Windows.Forms.CheckBox
    Private tab2CheckBox2 As System.Windows.Forms.CheckBox
    Private tab2CheckBox1 As System.Windows.Forms.CheckBox
    Private tab1Label1 As System.Windows.Forms.Label
    Private WithEvents tab1Button1 As System.Windows.Forms.Button
    Private tabPage3 As System.Windows.Forms.TabPage
    Private tabPage2 As System.Windows.Forms.TabPage
    Private tabPage1 As System.Windows.Forms.TabPage
    Private tabControl1 As System.Windows.Forms.TabControl    
    
    Public Sub New()
        ' This call is required for Windows Form Designer support.
        InitializeComponent()
    End Sub    
    
    
    ' This method is required for Designer support.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.tab2CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.tab3RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tab2CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.tab2CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.tab3RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.tab1Label1 = New System.Windows.Forms.Label()
        Me.tabPage3 = New System.Windows.Forms.TabPage()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.tab1Button1 = New System.Windows.Forms.Button()
        
        tabPage1.Text = "tabPage1"
        tabPage1.Size = New System.Drawing.Size(256, 214)
        tabPage1.TabIndex = 0
        tab2CheckBox3.Location = New System.Drawing.Point(32, 136)
        tab2CheckBox3.Text = "checkBox3"
        tab2CheckBox3.Size = New System.Drawing.Size(176, 32)
        tab2CheckBox3.TabIndex = 2
        tab2CheckBox3.Visible = True
        tab3RadioButton2.Location = New System.Drawing.Point(40, 72)
        tab3RadioButton2.Text = "radioButton2"
        tab3RadioButton2.Size = New System.Drawing.Size(152, 24)
        tab3RadioButton2.TabIndex = 1
        tab3RadioButton2.Visible = True
        tabControl1.Location = New System.Drawing.Point(16, 16)
        tabControl1.Size = New System.Drawing.Size(264, 240)
        tabControl1.SelectedIndex = 0
        tabControl1.TabIndex = 0
        tab2CheckBox2.Location = New System.Drawing.Point(32, 80)
        tab2CheckBox2.Text = "checkBox2"
        tab2CheckBox2.Size = New System.Drawing.Size(176, 32)
        tab2CheckBox2.TabIndex = 1
        tab2CheckBox2.Visible = True
        tab2CheckBox1.Location = New System.Drawing.Point(32, 24)
        tab2CheckBox1.Text = "checkBox1"
        tab2CheckBox1.Size = New System.Drawing.Size(176, 32)
        tab2CheckBox1.TabIndex = 0
        tab3RadioButton1.Location = New System.Drawing.Point(40, 32)
        tab3RadioButton1.Text = "radioButton1"
        tab3RadioButton1.Size = New System.Drawing.Size(152, 24)
        tab3RadioButton1.TabIndex = 0
        tab1Label1.Location = New System.Drawing.Point(16, 24)
        tab1Label1.Text = "label1"
        tab1Label1.Size = New System.Drawing.Size(224, 96)
        tab1Label1.TabIndex = 1
        tabPage3.Text = "tabPage3"
        tabPage3.Size = New System.Drawing.Size(256, 214)
        tabPage3.TabIndex = 2
        tabPage2.Text = "tabPage2"
        tabPage2.Size = New System.Drawing.Size(256, 214)
        tabPage2.TabIndex = 1
        tab1Button1.Location = New System.Drawing.Point(88, 144)
        tab1Button1.Size = New System.Drawing.Size(80, 40)
        tab1Button1.TabIndex = 0
        tab1Button1.Text = "button1"
        Me.Text = "Form1"
        
        ' Adds controls to the second tab page.
        tabPage2.Controls.Add(Me.tab2CheckBox3)
        tabPage2.Controls.Add(Me.tab2CheckBox2)
        tabPage2.Controls.Add(Me.tab2CheckBox1)
        ' Adds controls to the third tab page.
        tabPage3.Controls.Add(Me.tab3RadioButton2)
        tabPage3.Controls.Add(Me.tab3RadioButton1)
        ' Adds controls to the first tab page.
        tabPage1.Controls.Add(Me.tab1Label1)
        tabPage1.Controls.Add(Me.tab1Button1)
        ' Adds the TabControl to the form.
        Me.Controls.Add(tabControl1)
        ' Adds the tab pages to the TabControl.
        tabControl1.Controls.Add(Me.tabPage1)
        tabControl1.Controls.Add(Me.tabPage2)
        tabControl1.Controls.Add(Me.tabPage3)
    End Sub   
    
    Private Sub tab1Button1_Click(sender As Object, e As System.EventArgs) _
        Handles tab1Button1.Click
        
        ' Inserts the code that should run when the button is clicked.
    End Sub
    
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub
    
End Class

' </Snippet1>
