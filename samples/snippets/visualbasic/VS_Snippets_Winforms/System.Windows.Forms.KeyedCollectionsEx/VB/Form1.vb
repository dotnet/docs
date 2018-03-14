
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Class Form1
    Inherits Form
  
    Public Sub New() 
        
        InitializeComponent()
        ShowShippingOptions()

        '<snippet2>
        Me.BackgroundImage = imageList1.Images("logo.gif")
        '</snippet2>
    End Sub

    
    Private Sub ShowShippingOptions()

        '<snippet3>
        tabControl1.SelectedTab = tabControl1.TabPages("shippingOptions")
        '</snippet3>

    End Sub

    
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)  Handles button1.Click

        '<snippet1>
        Dim OrderForm1 As New OrderForm()
        OrderForm1.Show()
        OrderForm1.Controls.Find("textBox1", True)(0).Focus()
        '</snippet1>

    End Sub

    
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    
    End Sub 'Main
    
    Private WithEvents button1 As System.Windows.Forms.Button
    Private imageList1 As System.Windows.Forms.ImageList
    Private tabControl1 As System.Windows.Forms.TabControl
    Private products As System.Windows.Forms.TabPage
    Private components As System.ComponentModel.IContainer
    Private shippingOptions As System.Windows.Forms.TabPage
    
    Private Sub InitializeComponent() 
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.button1 = New System.Windows.Forms.Button
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.products = New System.Windows.Forms.TabPage
        Me.shippingOptions = New System.Windows.Forms.TabPage
        Me.tabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(66, 218)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 0
        Me.button1.Text = "Show Order Form"
        Me.button1.UseVisualStyleBackColor = True
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "order.GIF")
        Me.imageList1.Images.SetKeyName(1, "logo.gif")
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.products)
        Me.tabControl1.Controls.Add(Me.shippingOptions)
        Me.tabControl1.Location = New System.Drawing.Point(12, 12)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(264, 175)
        Me.tabControl1.TabIndex = 1
        '
        'products
        '
        Me.products.Location = New System.Drawing.Point(4, 22)
        Me.products.Name = "products"
        Me.products.Padding = New System.Windows.Forms.Padding(3)
        Me.products.Size = New System.Drawing.Size(256, 149)
        Me.products.TabIndex = 0
        Me.products.Text = "Products"
        Me.products.UseVisualStyleBackColor = True
        '
        'shippingOptions
        '
        Me.shippingOptions.Location = New System.Drawing.Point(4, 22)
        Me.shippingOptions.Name = "shippingOptions"
        Me.shippingOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.shippingOptions.Size = New System.Drawing.Size(256, 149)
        Me.shippingOptions.TabIndex = 1
        Me.shippingOptions.Text = "Shipping Options"
        Me.shippingOptions.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.button1)
        Me.Name = "Form1"
        Me.tabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
End Class 'Form1


Public Class OrderForm
    Inherits Form
    
    Public Sub New() 
        InitializeComponent()
    End Sub

    Private panel1 As System.Windows.Forms.Panel
    Private label4 As System.Windows.Forms.Label
    Private textBox4 As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Private textBox3 As System.Windows.Forms.TextBox
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private textBox2 As System.Windows.Forms.TextBox
    Private textBox1 As System.Windows.Forms.TextBox
    Private label5 As System.Windows.Forms.Label
    Private checkBox1 As System.Windows.Forms.CheckBox
    Private panel2 As System.Windows.Forms.Panel
    Private label6 As System.Windows.Forms.Label
    Private listView1 As System.Windows.Forms.ListView
    Private imageList1 As System.Windows.Forms.ImageList
    
    
    Private Sub InitializeComponent() 
        
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label5 = New System.Windows.Forms.Label()
        Me.checkBox1 = New System.Windows.Forms.CheckBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.textBox4 = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.textBox3 = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.textBox2 = New System.Windows.Forms.TextBox()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        imageList1 = New ImageList()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.listView1 = New System.Windows.Forms.ListView()
        Me.label6 = New System.Windows.Forms.Label()
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        ' 
        ' panel1
        ' 
        Me.panel1.Controls.Add(Me.label5)
        Me.panel1.Controls.Add(Me.checkBox1)
        Me.panel1.Controls.Add(Me.label4)
        Me.panel1.Controls.Add(Me.textBox4)
        Me.panel1.Controls.Add(Me.label3)
        Me.panel1.Controls.Add(Me.textBox3)
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Controls.Add(Me.textBox2)
        Me.panel1.Controls.Add(Me.textBox1)
        Me.panel1.Location = New System.Drawing.Point(3, 69)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(287, 198)
        Me.panel1.TabIndex = 1
        ' 
        ' label5
        ' 
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(6, 4)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(89, 13)
        Me.label5.TabIndex = 9
        Me.label5.Text = "Billing Information"
        ' 
        ' checkBox1
        ' 
        Me.checkBox1.AutoSize = True
        Me.checkBox1.Location = New System.Drawing.Point(150, 4)
        Me.checkBox1.Name = "checkBox1"
        Me.checkBox1.Size = New System.Drawing.Size(127, 17)
        Me.checkBox1.TabIndex = 8
        Me.checkBox1.Text = "Ship to same address"
        Me.checkBox1.UseVisualStyleBackColor = True
        ' 
        ' label4
        ' 
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 167)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(76, 13)
        Me.label4.TabIndex = 7
        Me.label4.Text = "City, State, Zip"
        ' 
        ' textBox4
        ' 
        Me.textBox4.Location = New System.Drawing.Point(6, 105)
        Me.textBox4.Name = "textBox4"
        Me.textBox4.Size = New System.Drawing.Size(187, 20)
        Me.textBox4.TabIndex = 6
        ' 
        ' label3
        ' 
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(3, 128)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(76, 13)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Address, line 2"
        ' 
        ' textBox3
        ' 
        Me.textBox3.Location = New System.Drawing.Point(6, 144)
        Me.textBox3.Name = "textBox3"
        Me.textBox3.Size = New System.Drawing.Size(187, 20)
        Me.textBox3.TabIndex = 4
        ' 
        ' label2
        ' 
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(3, 89)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(76, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Address, line 1"
        ' 
        ' label1
        ' 
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 50)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(35, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Name"
        ' 
        ' textBox2
        ' 
        Me.textBox2.Location = New System.Drawing.Point(6, 66)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New System.Drawing.Size(187, 20)
        Me.textBox2.TabIndex = 1
        ' 
        ' textBox1
        ' 
        Me.textBox1.Location = New System.Drawing.Point(3, 27)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(190, 20)
        Me.textBox1.TabIndex = 0
        ' 
        ' panel2
        ' 
        Me.panel2.Controls.Add(Me.label6)
        Me.panel2.Controls.Add(Me.listView1)
        Me.panel2.Location = New System.Drawing.Point(3, 2)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(287, 61)
        Me.panel2.TabIndex = 0
        ' 
        ' listView1
        ' 
        Me.listView1.Location = New System.Drawing.Point(3, 23)
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New System.Drawing.Size(274, 35)
        Me.listView1.TabIndex = 0
        ' 
        ' label6
        ' 
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(3, 7)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(46, 13)
        Me.label6.TabIndex = 1
        Me.label6.Text = "Item List"
        ' 
    
        ' 
        ' OrderForm
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(panel2)
        Me.Controls.Add(panel1)
        Me.Name = "OrderForm"
        Me.Text = "Order Form"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        Me.ResumeLayout(False)
    
    End Sub 'InitializeComponent 
End Class 'OrderForm

