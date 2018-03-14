' System.Windows.Forms.Control.Scale(float)
' System.Windows.Forms.Control.SizeChanged

' The following example demonstrates the 'Scale(float)' method
' and 'SizeChanged' event of the 'Control' class. An instance of 
' a 'Button' control has been provided that can be scaled both 
' horizontally and vertically. A 'NumericUpDown' instance has been 
' provided that is used to provide for the horizontal and vertical 
' scale value. The 'Button' instance named 'OK' is used to set the 
' scale values for the 'Button' control instance. Whenever the size
' of the control changes the event handler associated with the 
' 'SizeChanged' event of the control is called. This event handler 
' displays a message box indicating that the size of the control has 
' changed. 

Imports System
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class MyForm
   Inherits Form
   Private myLabel1 As Label
   Private myNumericUpDown1 As NumericUpDown
   Private myButton1 As Button
   Private myButton2 As Button
   
   Private components As Container = Nothing
   
   Public Sub New()
      InitializeComponent()
   End Sub 'New
   
   Protected Overrides Overloads Sub Dispose(disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub 'Dispose
   
   Private Sub InitializeComponent()
      Me.myLabel1 = New System.Windows.Forms.Label()
      Me.myButton1 = New System.Windows.Forms.Button()
      Me.myButton2 = New System.Windows.Forms.Button()
      Me.myNumericUpDown1 = New System.Windows.Forms.NumericUpDown()
      CType(Me.myNumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' Set the properties for 'myLabel1'.
      Me.myLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, _
      System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
      Me.myLabel1.Location = New System.Drawing.Point(16, 168)
      Me.myLabel1.Name = "myLabel1"
      Me.myLabel1.Size = New System.Drawing.Size(152, 24)
      Me.myLabel1.TabIndex = 1
      Me.myLabel1.Text = "Scale (Horizontal & Vertical):"
      Me.myLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      ' Set the properties for 'myButton1'.
      Me.myButton1.Location = New System.Drawing.Point(56, 32)
      Me.myButton1.Name = "myButton1"
      Me.myButton1.Size = New System.Drawing.Size(184, 80)
      Me.myButton1.TabIndex = 0
      Me.myButton1.Text = "Scaleable Control"
      RegisterEventHandler()
      ' Set the properties for 'myButton2'.
      Me.myButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, _
         System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
      Me.myButton2.Location = New System.Drawing.Point(48, 216)
      Me.myButton2.Name = "myButton2"
      Me.myButton2.Size = New System.Drawing.Size(200, 32)
      Me.myButton2.TabIndex = 7
      Me.myButton2.Text = "OK"
      AddHandler myButton2.Click , AddressOf MyButton2_Click
      ' Set the properties for 'myNumericUpDown1'.
      Me.myNumericUpDown1.DecimalPlaces = 1
      Me.myNumericUpDown1.Increment = New System.Decimal(0.1)
      Me.myNumericUpDown1.Location = New System.Drawing.Point(192, 168)
      Me.myNumericUpDown1.Maximum = New System.Decimal(10)
      Me.myNumericUpDown1.Minimum = New System.Decimal(0)
      Me.myNumericUpDown1.Name = "myNumericUpDown1"
      Me.myNumericUpDown1.Size = New System.Drawing.Size(88, 20)
      Me.myNumericUpDown1.TabIndex = 5
      ' Set the properties for 'MyForm'.
      Me.ClientSize = New System.Drawing.Size(292, 261)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.myButton2, Me.myNumericUpDown1, _
                                                                     Me.myLabel1, Me.myButton1})
      Me.Name = "MyForm"
      Me.Text = "MyForm"
      CType(Me.myNumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
   End Sub 'InitializeComponent
   
   <STAThread()>  _
   Shared Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main
   
   
' <Snippet2>
   Private Sub RegisterEventHandler()
      AddHandler myButton1.SizeChanged, AddressOf MyButton1_SizeChanged
   End Sub 'RegisterEventHandler

   Private Sub MyButton2_Click(sender As Object, e As EventArgs) 
' <Snippet1>
      ' Set the scale for the control to the value provided.
      Dim scale As Single = CSng(myNumericUpDown1.Value)
      myButton1.Scale(scale)
' </Snippet1>
   End Sub 'MyButton2_Click
   
   Private Sub MyButton1_SizeChanged(sender As Object, e As EventArgs)
      MessageBox.Show("The size of the 'Button' control has changed")
   End Sub 'MyButton1_SizeChanged
' </Snippet2>
End Class 'MyForm 