
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace SelectionRangew

   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents monthCalendar1 As System.Windows.Forms.MonthCalendar
      Private WithEvents textBox1 As System.Windows.Forms.TextBox
      Private WithEvents textBox2 As System.Windows.Forms.TextBox
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private WithEvents button1 As System.Windows.Forms.Button

      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
       
      Private Sub InitializeComponent()
         Me.monthCalendar1 = New System.Windows.Forms.MonthCalendar()
         Me.textBox1 = New System.Windows.Forms.TextBox()
         Me.textBox2 = New System.Windows.Forms.TextBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.button1 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' monthCalendar1
         ' 
         Me.monthCalendar1.Location = New System.Drawing.Point(10, 8)
         Me.monthCalendar1.Name = "monthCalendar1"
         Me.monthCalendar1.TabIndex = 0
         ' 
         ' textBox1
         ' 
         Me.textBox1.Location = New System.Drawing.Point(96, 176)
         Me.textBox1.Name = "textBox1"
         Me.textBox1.Size = New System.Drawing.Size(104, 20)
         Me.textBox1.TabIndex = 1
         Me.textBox1.Text = ""
         ' 
         ' textBox2
         ' 
         Me.textBox2.Location = New System.Drawing.Point(96, 208)
         Me.textBox2.Name = "textBox2"
         Me.textBox2.Size = New System.Drawing.Size(104, 20)
         Me.textBox2.TabIndex = 2
         Me.textBox2.Text = ""
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(24, 176)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(72, 23)
         Me.label1.TabIndex = 3
         Me.label1.Text = "Start"
         ' 
         ' label2
         ' 
         Me.label2.Location = New System.Drawing.Point(24, 208)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(72, 23)
         Me.label2.TabIndex = 4
         Me.label2.Text = "End"
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(72, 248)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 5
         Me.button1.Text = "button1"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(216, 277)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1, Me.label2, Me.label1, Me.textBox2, Me.textBox1, Me.monthCalendar1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      

'<snippet1>
Private Sub button1_Click(sender As Object, _
  e As EventArgs) Handles button1.Click
   ' Create a SelectionRange object and set its Start and End properties.
   Dim sr As New SelectionRange()
   sr.Start = DateTime.Parse(Me.textBox1.Text)
   sr.End = DateTime.Parse(Me.textBox2.Text)
   ' Assign the SelectionRange object to the
   ' SelectionRange property of the MonthCalendar control. 
   Me.monthCalendar1.SelectionRange = sr
End Sub 


Private Sub monthCalendar1_DateChanged(sender As Object, _
  e As DateRangeEventArgs) Handles monthCalendar1.DateChanged
   ' Display the Start and End property values of
   ' the SelectionRange object in the text boxes. 
   Me.textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString()
   Me.textBox2.Text = monthCalendar1.SelectionRange.End.Date.ToShortDateString()
End Sub
'</snippet1>

   End Class 
End Namespace 