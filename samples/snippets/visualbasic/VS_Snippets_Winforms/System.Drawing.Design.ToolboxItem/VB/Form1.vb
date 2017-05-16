'<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Runtime.Serialization
Imports System.Text
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Private components As System.ComponentModel.IContainer = Nothing
    Friend WithEvents UserControl11 As UserControl1
    Friend WithEvents label1 As System.Windows.Forms.Label

    Public Sub New() 
        InitializeComponent()
    End Sub
    
    
    Private Sub InitializeComponent() 
        Me.label1 = New System.Windows.Forms.Label
        Me.UserControl11 = New UserControl1
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(15, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(265, 62)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Build the project and drop UserControl1" + _
            " from the toolbox onto the form."
        '
        'UserControl11
        '
        Me.UserControl11.LabelText = "This is a custom user control.  " + _
            "The text you see here is provided by a custom too" + _
            "lbox item when the user control is dropped on the form."
        Me.UserControl11.Location = New System.Drawing.Point(74, 85)
        Me.UserControl11.Name = "UserControl11"
        Me.UserControl11.Padding = New System.Windows.Forms.Padding(6)
        Me.UserControl11.TabIndex = 1
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.UserControl11)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub
     
    
    Protected Overrides Sub Dispose(ByVal disposing As Boolean) 
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
    
    
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
End Class

' Configure this user control to have a custom toolbox item.
'<snippet2>
<ToolboxItem(GetType(MyToolboxItem))> _
Public Class UserControl1
    Inherits UserControl
'</snippet2>
    Private components As System.ComponentModel.IContainer = Nothing
    Private label1 As System.Windows.Forms.Label


    Public Sub New()
        InitializeComponent()
    End Sub


    Public Property LabelText() As String
        Get
            Return label1.Text
        End Get
        Set(ByVal value As String)
            label1.Text = Value
        End Set
    End Property


    Private Sub InitializeComponent()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        ' 
        ' label1
        ' 
        Me.label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.label1.Location = New System.Drawing.Point(6, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(138, 138)
        Me.label1.TabIndex = 0
        Me.label1.Text = "This is a custom user control.  " + _
            "The text you see here is provided by a custom toolbox" + _
            " item when the user control is dropped on the form." + _
            vbCr + vbLf
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        ' 
        ' UserControl1
        ' 
        Me.Controls.Add(label1)
        Me.Name = "UserControl1"
        Me.Padding = New System.Windows.Forms.Padding(6)
        Me.ResumeLayout(False)
    End Sub


    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class

' Toolbox items must be serializable.
'<snippet3>
<Serializable()> _
Class MyToolboxItem
    Inherits ToolboxItem

    ' The add components dialog in Visual Studio looks for a public
    ' constructor that takes a type.
    Public Sub New(ByVal toolType As Type)
        MyBase.New(toolType)
    End Sub


    ' And you must provide this special constructor for serialization.
    ' If you add additional data to MyToolboxItem that you
    ' want to serialize, you may override Deserialize and
    ' Serialize methods to add that data.  
'<snippet4>
    Sub New(ByVal info As SerializationInfo, _
        ByVal context As StreamingContext)
        Deserialize(info, context)
    End Sub
'</snippet4>


    ' Let's override the creation code and pop up a dialog.
'<snippet5>
    Protected Overrides Function CreateComponentsCore( _
        ByVal host As System.ComponentModel.Design.IDesignerHost, _
        ByVal defaultValues As System.Collections.IDictionary) _
        As IComponent()
        ' Get the string we want to fill in the custom
        ' user control.  If the user cancels out of the dialog,
        ' return null or an empty array to signify that the 
        ' tool creation was canceled.
        Using d As New ToolboxItemDialog()
            If d.ShowDialog() = DialogResult.OK Then
                Dim [text] As String = d.CreationText
                Dim comps As IComponent() = _
                    MyBase.CreateComponentsCore(host, defaultValues)
                ' comps will have a single component: our data type.
                CType(comps(0), UserControl1).LabelText = [text]
                Return comps
            Else
                Return Nothing
            End If
        End Using
    End Function
'</snippet5>
End Class
'</snippet3>


Public Class ToolboxItemDialog
    Inherits Form
    Private components As System.ComponentModel.IContainer = Nothing
    Private label1 As System.Windows.Forms.Label
    Private textBox1 As System.Windows.Forms.TextBox
    Private button1 As System.Windows.Forms.Button
    Private button2 As System.Windows.Forms.Button
    
    
    Public Sub New() 
        InitializeComponent()
    End Sub
    
    Private Sub InitializeComponent() 
        Me.label1 = New System.Windows.Forms.Label()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        ' 
        ' label1
        ' 
        Me.label1.Location = New System.Drawing.Point(10, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(273, 43)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Enter the text you would like" + _
            " to have the user control populated with:"
        ' 
        ' textBox1
        ' 
        Me.textBox1.AutoSize = False
        Me.textBox1.Location = New System.Drawing.Point(10, 58)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(270, 67)
        Me.textBox1.TabIndex = 1
        Me.textBox1.Text = "This is a custom user control.  " + _
            "The text you see here is provided by a custom toolbox" + _
            " item when the user control is dropped on the form."
        ' 
        ' button1
        ' 
        Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.button1.Location = New System.Drawing.Point(124, 131)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 2
        Me.button1.Text = "OK"
        ' 
        ' button2
        ' 
        Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.button2.Location = New System.Drawing.Point(205, 131)
        Me.button2.Name = "button2"
        Me.button2.TabIndex = 3
        Me.button2.Text = "Cancel"
        ' 
        ' ToolboxItemDialog
        ' 
        Me.AcceptButton = Me.button1
        Me.CancelButton = Me.button2
        Me.ClientSize = New System.Drawing.Size(292, 162)
        Me.ControlBox = False
        Me.Controls.Add(button2)
        Me.Controls.Add(button1)
        Me.Controls.Add(textBox1)
        Me.Controls.Add(label1)
        Me.FormBorderStyle = _
            System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ToolboxItemDialog"
        Me.Text = "ToolboxItemDialog"
        Me.ResumeLayout(False)
    
    End Sub
    
    Public ReadOnly Property CreationText() As String 
        Get
            Return textBox1.Text
        End Get
    End Property
    
    
    Protected Overrides Sub Dispose(ByVal disposing As Boolean) 
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    
    End Sub
End Class
'</snippet1>
