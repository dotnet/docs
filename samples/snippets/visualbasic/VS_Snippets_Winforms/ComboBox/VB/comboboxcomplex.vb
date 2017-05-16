Imports System
Imports System.Windows.Forms

Namespace Win32Form1Namespace

    Public Class Win32Form1
        Inherits System.Windows.Forms.Form
        Private comboBox1 As System.Windows.Forms.ComboBox
        Private button1 As System.Windows.Forms.Button
        Private textBox2 As System.Windows.Forms.TextBox
        Private label1 As System.Windows.Forms.Label
        Private label4 As System.Windows.Forms.Label
        Private textBox1 As System.Windows.Forms.TextBox
        Private radioButton1 As System.Windows.Forms.RadioButton
        Private radioButton2 As System.Windows.Forms.RadioButton
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label

        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
        End Sub

        <System.STAThreadAttribute()> Public Shared Sub Main()
            System.Windows.Forms.Application.Run(New Win32Form1())
        End Sub

        Private Sub InitializeComponent()
            Me.textBox2 = New System.Windows.Forms.TextBox()
            Me.button1 = New System.Windows.Forms.Button()
            Me.comboBox1 = New System.Windows.Forms.ComboBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.label4 = New System.Windows.Forms.Label()
            Me.textBox1 = New System.Windows.Forms.TextBox()
            Me.radioButton1 = New System.Windows.Forms.RadioButton()
            Me.radioButton2 = New System.Windows.Forms.RadioButton()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label3 = New System.Windows.Forms.Label()
            Me.textBox2.Location = New System.Drawing.Point(48, 72)
            Me.textBox2.Size = New System.Drawing.Size(208, 20)
            Me.textBox2.TabIndex = 4
            Me.textBox2.Text = ""
            Me.button1.Location = New System.Drawing.Point(184, 104)
            Me.button1.TabIndex = 1
            Me.button1.Text = "Add"
            AddHandler Me.button1.Click, AddressOf Me.button1_Click
            Me.comboBox1.DropDownWidth = 280
            Me.comboBox1.Location = New System.Drawing.Point(8, 248)
            Me.comboBox1.Size = New System.Drawing.Size(280, 21)
            Me.comboBox1.TabIndex = 0
            Me.label1.Location = New System.Drawing.Point(48, 16)
            Me.label1.Size = New System.Drawing.Size(100, 16)
            Me.label1.TabIndex = 6
            Me.label1.Text = "Add new item"
            Me.label4.Location = New System.Drawing.Point(8, 152)
            Me.label4.Size = New System.Drawing.Size(216, 23)
            Me.label4.TabIndex = 9
            Me.label4.Text = "Select field to display in the ComboBox"
            Me.textBox1.Location = New System.Drawing.Point(48, 40)
            Me.textBox1.Size = New System.Drawing.Size(208, 20)
            Me.textBox1.TabIndex = 3
            Me.textBox1.Text = ""
            Me.radioButton1.Location = New System.Drawing.Point(8, 184)
            Me.radioButton1.Size = New System.Drawing.Size(128, 24)
            Me.radioButton1.TabIndex = 5
            Me.radioButton1.Text = "String 1"
            AddHandler Me.radioButton1.CheckedChanged, AddressOf Me.radioButton1_CheckedChanged
            Me.radioButton2.Location = New System.Drawing.Point(8, 216)
            Me.radioButton2.Size = New System.Drawing.Size(128, 24)
            Me.radioButton2.TabIndex = 5
            Me.radioButton2.Text = "String 2"
            Me.label2.Location = New System.Drawing.Point(0, 40)
            Me.label2.Size = New System.Drawing.Size(48, 24)
            Me.label2.TabIndex = 7
            Me.label2.Text = "Sring 1"
            Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.label3.Location = New System.Drawing.Point(0, 72)
            Me.label3.Size = New System.Drawing.Size(48, 23)
            Me.label3.TabIndex = 8
            Me.label3.Text = "String 2"
            Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.ClientSize = New System.Drawing.Size(292, 273)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label4, Me.label3, Me.label2, Me.label1, Me.radioButton2, Me.radioButton1, Me.textBox2, Me.textBox1, Me.button1, Me.comboBox1})
            Me.Text = "Win32Form1"
        End Sub

'<Snippet6>        
        'Sample class to use for the ComboBox item.
        Private Class Item
            Dim strng1 As String
            Dim strng2 As String

            Public Sub New(ByVal s1 As String, ByVal s2 As String)
                strng1 = s1
                strng2 = s2
            End Sub

            Public Property String1() As String
                Get
                    Return strng1
                End Get
                Set(ByVal Value As String)
                    strng1 = value
                End Set
            End Property

            Public Property String2() As String
                Get
                    Return strng2
                End Get
                Set(ByVal Value As String)
                    strng2 = value
                End Set
            End Property
        End Class
        
        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            'Adds a new instance ot the Item class to the ComboBox
            Dim newItem As Item
            newItem = New Item(textBox1.Text, textBox2.Text)
            MessageBox.Show(textBox1.Text + " " +  textBox2.Text)
            comboBox1.Items.Add(newItem)
        End Sub

        Private Sub radioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            'swaps the ComboBox's DisplayMember
            If (radioButton1.Checked) Then
                comboBox1.DisplayMember = "String1"
            Else
                comboBox1.DisplayMember = "String2"
            End If
        End Sub
'</Snippet6>
        
    End Class
End Namespace

