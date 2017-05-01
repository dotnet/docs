' <Snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic

Namespace MonthCalender
   ' Summary description for Form1.
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private monthCalendar1 As System.Windows.Forms.MonthCalendar
      Private listBox1 As System.Windows.Forms.ListBox
      Private comboBox1 As System.Windows.Forms.ComboBox
      Private textBox1 As System.Windows.Forms.TextBox
      Private textBox2 As System.Windows.Forms.TextBox
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private dateTimePicker1 As System.Windows.Forms.DateTimePicker
      Private dateTimePicker2 As System.Windows.Forms.DateTimePicker
      Private button1 As System.Windows.Forms.Button
      Private button2 As System.Windows.Forms.Button
      Private button3 As System.Windows.Forms.Button
      Private checkBox1 As System.Windows.Forms.CheckBox
      Private checkBox2 As System.Windows.Forms.CheckBox
      
      ' Required designer variable.
      Private components As System.ComponentModel.Container
      
      Public Sub New()
         MyBase.New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
         
         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         AddHandler Me.Closing, AddressOf Me.this_Closing
         setCalendarLook()
         
         dateTimePicker1.Value = monthCalendar1.MinDate
         dateTimePicker2.Value = monthCalendar1.MaxDate
         textBox1.Text = monthCalendar1.MaxSelectionCount.ToString()
         Dim day As Day
         For day = Day.Monday To Day.Default
            comboBox1.Items.Add(day.ToString())
         Next day
         comboBox1.SelectedItem = comboBox1.Items(comboBox1.Items.IndexOf(monthCalendar1.FirstDayOfWeek.ToString()))
         loadDates()
      End Sub 'New
      
      
      ' Form overrides dispose to clean up the component list.
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
          If disposing Then
              If (components IsNot Nothing) Then
                  components.Dispose()
              End If
          End If
          MyBase.Dispose(disposing)
      End Sub
       
      ' Required method for Designer support - do not modify
      ' the contents of this method with the code editor.
      Private Sub InitializeComponent()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.dateTimePicker2 = New System.Windows.Forms.DateTimePicker()
         Me.dateTimePicker1 = New System.Windows.Forms.DateTimePicker()
         Me.textBox2 = New System.Windows.Forms.TextBox()
         Me.button1 = New System.Windows.Forms.Button()
         Me.textBox1 = New System.Windows.Forms.TextBox()
         Me.button3 = New System.Windows.Forms.Button()
         Me.checkBox1 = New System.Windows.Forms.CheckBox()
         Me.listBox1 = New System.Windows.Forms.ListBox()
         Me.checkBox2 = New System.Windows.Forms.CheckBox()
         Me.monthCalendar1 = New System.Windows.Forms.MonthCalendar()
         Me.button2 = New System.Windows.Forms.Button()
         Me.comboBox1 = New System.Windows.Forms.ComboBox()
         Me.SuspendLayout()
         ' 
         ' label4
         ' 
         Me.label4.Location = New System.Drawing.Point(216, 176)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(248, 16)
         Me.label4.TabIndex = 8
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(8, 24)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(128, 16)
         Me.label1.TabIndex = 2
         Me.label1.Text = "Max Selection Count"
         ' 
         ' label2
         ' 
         Me.label2.Location = New System.Drawing.Point(8, 56)
         Me.label2.Name = "label2"
         Me.label2.TabIndex = 4
         Me.label2.Text = "Min Date"
         ' 
         ' label3
         ' 
         Me.label3.Location = New System.Drawing.Point(8, 104)
         Me.label3.Name = "label3"
         Me.label3.TabIndex = 6
         Me.label3.Text = "Max Date"
         ' 
         ' dateTimePicker2
         ' 
         Me.dateTimePicker2.Location = New System.Drawing.Point(8, 128)
         Me.dateTimePicker2.Name = "dateTimePicker2"
         Me.dateTimePicker2.TabIndex = 7
         AddHandler Me.dateTimePicker2.ValueChanged, AddressOf Me.dateTimePicker2_ValueChanged
         
         ' 
         ' dateTimePicker1
         ' 
         Me.dateTimePicker1.Location = New System.Drawing.Point(8, 80)
         Me.dateTimePicker1.Name = "dateTimePicker1"
         Me.dateTimePicker1.TabIndex = 5
         AddHandler Me.dateTimePicker1.ValueChanged, AddressOf Me.dateTimePicker1_ValueChanged
         ' 
         ' textBox2
         ' 
         Me.textBox2.Enabled = False
         Me.textBox2.Location = New System.Drawing.Point(216, 192)
         Me.textBox2.Name = "textBox2"
         Me.textBox2.Size = New System.Drawing.Size(144, 20)
         Me.textBox2.TabIndex = 9
         Me.textBox2.Text = ""
         AddHandler Me.textBox2.TextChanged, AddressOf Me.textBox2_TextChanged
         ' 
         ' button1
         ' 
         Me.button1.Enabled = False
         Me.button1.Location = New System.Drawing.Point(216, 216)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(112, 24)
         Me.button1.TabIndex = 10
         Me.button1.Text = "Add Description"
         AddHandler Me.button1.Click, AddressOf Me.button1_Click
         ' 
         ' textBox1
         ' 
         Me.textBox1.Location = New System.Drawing.Point(136, 24)
         Me.textBox1.Name = "textBox1"
         Me.textBox1.Size = New System.Drawing.Size(24, 20)
         Me.textBox1.TabIndex = 3
         Me.textBox1.Text = ""
         AddHandler Me.textBox1.KeyPress, AddressOf Me.textBox1_keypress
         AddHandler Me.textBox1.Validating, AddressOf Me.textBox1_Validate
         AddHandler Me.textBox1.LostFocus, AddressOf Me.textBox1_LostFocus
                  
         ' 
         ' button3
         ' 
         Me.button3.Enabled = False
         Me.button3.Location = New System.Drawing.Point(488, 224)
         Me.button3.Name = "button3"
         Me.button3.Size = New System.Drawing.Size(104, 24)
         Me.button3.TabIndex = 12
         Me.button3.Text = "Clear All"
         AddHandler Me.button3.Click, AddressOf Me.button3_Click

         ' 
         ' checkBox1
         ' 
         Me.checkBox1.Location = New System.Drawing.Point(8, 160)
         Me.checkBox1.Name = "checkBox1"
         Me.checkBox1.Size = New System.Drawing.Size(144, 24)
         Me.checkBox1.TabIndex = 13
         Me.checkBox1.Text = "Show Todays Date"
         ' 
         ' listBox1
         ' 
         Me.listBox1.Location = New System.Drawing.Point(488, 16)
         Me.listBox1.Name = "listBox1"
         Me.listBox1.Size = New System.Drawing.Size(176, 160)
         Me.listBox1.TabIndex = 1
         AddHandler Me.listBox1.SelectedIndexChanged, AddressOf Me.listBox1_SelectedIndexChanged
         ' 
         ' checkBox2
         ' 
         Me.checkBox2.Location = New System.Drawing.Point(8, 192)
         Me.checkBox2.Name = "checkBox2"
         Me.checkBox2.Size = New System.Drawing.Size(120, 24)
         Me.checkBox2.TabIndex = 14
         Me.checkBox2.Text = "Show Today Circle"
         AddHandler Me.checkBox2.CheckedChanged, AddressOf Me.checkBox2_CheckedChanged
         ' 
         ' monthCalendar1
         ' 
         Me.monthCalendar1.Location = New System.Drawing.Point(216, 8)
         Me.monthCalendar1.Name = "monthCalendar1"
         Me.monthCalendar1.TabIndex = 0
         AddHandler Me.monthCalendar1.DateSelected, AddressOf Me.monthCalendar1_DateSelected
         ' 
         ' button2
         ' 
         Me.button2.Enabled = False
         Me.button2.Location = New System.Drawing.Point(488, 184)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(104, 24)
         Me.button2.TabIndex = 11
         Me.button2.Text = "Delete Selected"
         AddHandler Me.button2.Click, AddressOf Me.button2_Click
         ' 
         ' comboBox1
         ' 
         Me.comboBox1.DropDownWidth = 121
         Me.comboBox1.Location = New System.Drawing.Point(8, 232)
         Me.comboBox1.Name = "comboBox1"
         Me.comboBox1.Size = New System.Drawing.Size(121, 21)
         Me.comboBox1.TabIndex = 15
         Me.comboBox1.Text = "comboBox1"
         AddHandler Me.checkBox1.CheckedChanged, AddressOf Me.checkBox1_CheckedChanged
         AddHandler Me.comboBox1.SelectedIndexChanged, AddressOf Me.comboBox1_SelectedIndexChanged
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(672, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.comboBox1, Me.checkBox2, Me.checkBox1, Me.button3, Me.button2, Me.button1, Me.textBox2, Me.label4, Me.dateTimePicker2, Me.label3, Me.dateTimePicker1, Me.label2, Me.textBox1, Me.label1, Me.listBox1, Me.monthCalendar1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
      ' The main entry point for the application.
      Public Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      
      '<Snippet8>
      Private Sub checkBox1_CheckedChanged(sender As Object, e As System.EventArgs)
         If checkBox1.Checked = True Then
            monthCalendar1.ShowToday = True
         Else
            monthCalendar1.ShowToday = False
         End If
      End Sub 'checkBox1_CheckedChanged
      '</Snippet8>
       
      '<Snippet9>   
      Private Sub checkBox2_CheckedChanged(sender As Object, e As System.EventArgs)
         If checkBox2.Checked = True Then
            monthCalendar1.ShowTodayCircle = True
         Else
            monthCalendar1.ShowTodayCircle = False
         End If
      End Sub 'checkBox2_CheckedChanged
      '</Snippet9>
       
      Private Sub dateTimePicker1_ValueChanged(sender As Object, e As EventArgs)
         If dateTimePicker1.Value <> monthCalendar1.MinDate Then
            If dateTimePicker1.Value > monthCalendar1.MaxDate Then
               dateTimePicker2.Value = dateTimePicker1.Value.AddDays(monthCalendar1.MaxSelectionCount)
            End If
            monthCalendar1.MinDate = dateTimePicker1.Value
         End If
      End Sub 'dateTimePicker1_ValueChanged
      
      
      Private Sub dateTimePicker2_ValueChanged(sender As Object, e As EventArgs)
         If dateTimePicker2.Value <> monthCalendar1.MaxDate Then
            If dateTimePicker2.Value < monthCalendar1.MinDate Then
               dateTimePicker1.Value = dateTimePicker2.Value.AddDays(- monthCalendar1.MaxSelectionCount)
            End If
            monthCalendar1.MaxDate = dateTimePicker2.Value
         End If
      End Sub 'dateTimePicker2_ValueChanged
      
      Private Sub textBox1_keypress(sender As Object, k As KeyPressEventArgs)
         k.Handled = True
         If k.KeyChar >= "0"c And k.KeyChar <= "9"c Or k.KeyChar = ControlChars.Tab Or k.KeyChar = ControlChars.Back Or k.KeyChar = ControlChars.Lf Then
            k.Handled = False
         End If
         If k.KeyChar = ControlChars.Lf Then
            monthCalendar1.Focus()
         End If
      End Sub 'textBox1_keypress
      
      Private Sub textBox1_Validate(sender As Object, c As CancelEventArgs)
         If Integer.Parse(textBox1.Text) < 1 Or Integer.Parse(textBox1.Text) > 365 Then
            MessageBox.Show("Max Selection Count must be greater than zero and less than 366.")
            c.Cancel = True
         End If
      End Sub 'textBox1_Validate
      
      '<Snippet5>
      Private Sub textBox1_LostFocus(sender As Object, e As EventArgs)
         monthCalendar1.MaxSelectionCount = Integer.Parse(textBox1.Text)
      End Sub 'textBox1_LostFocus
      '</Snippet5>
      
      '<Snippet6>
      Private Sub comboBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs)
         monthCalendar1.FirstDayOfWeek = CType(comboBox1.SelectedIndex, Day)
      End Sub 'comboBox1_SelectedIndexChanged
      '</Snippet6>
      
      Private Sub monthCalendar1_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs)
         label4.Text = "Enter description for " + monthCalendar1.SelectionStart.ToShortDateString()
         If monthCalendar1.SelectionEnd <> monthCalendar1.SelectionStart Then
            label4.Text += " to " + monthCalendar1.SelectionEnd.ToShortDateString()
         End If
         textBox2.Enabled = True
      End Sub 'monthCalendar1_DateSelected


      Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         Dim i As Integer
         i = 0
         Do
            listBox1.Items.Add((monthCalendar1.SelectionStart.AddDays(i).ToShortDateString() + " " + textBox2.Text))
            i = i + 1
         Loop While monthCalendar1.SelectionStart.AddDays(i) <= monthCalendar1.SelectionEnd
         label4.Text = ""
         textBox2.Enabled = False
         button1.Enabled = False
         button3.Enabled = True
      End Sub 'button1_Click


      Private Sub textBox2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
         If textBox2.Text.Trim() = "" Then
            textBox2.Text = textBox2.Text.Trim()
            button1.Enabled = False
         Else
            button1.Enabled = True
         End If
      End Sub 'textBox2_TextChanged

      Private Sub this_Closing(ByVal Sender As Object, ByVal c As CancelEventArgs)
         Dim myOutputStream As StreamWriter = File.CreateText("myDates.txt")
         Dim myDates As IEnumerator = listBox1.Items.GetEnumerator()
         While myDates.MoveNext() = True

            myOutputStream.WriteLine(myDates.Current.ToString())
         End While
         myOutputStream.Flush()
         myOutputStream.Close()
      End Sub 'this_Closing


      Private Sub listBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
         If listBox1.SelectedIndex <> -1 Then
            button2.Enabled = True
         Else
            button2.Enabled = False
         End If
      End Sub 'listBox1_SelectedIndexChanged

      '<Snippet2>
      ' The following method uses Add to add dates that are 
      ' bolded, followed by an UpdateBoldedDates to make the
      ' added dates visible.
      Private Sub loadDates()
         Dim myInput As [String]
         Try
            Dim myInputStream As StreamReader = File.OpenText("myDates.txt")
            myInput = myInputStream.ReadLine()
            While myInput IsNot Nothing
               monthCalendar1.AddBoldedDate(DateTime.Parse(myInput.Substring(0, myInput.IndexOf(" "))))
               listBox1.Items.Add(myInput)
               myInput = myInputStream.ReadLine()
            End While
            monthCalendar1.UpdateBoldedDates()
            myInputStream.Close()
            File.Delete("myDates.txt")
         Catch fnfe As FileNotFoundException
         End Try
      End Sub 'loadDates
      '</Snippet2>

      '<Snippet3>   
      Private Sub button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         monthCalendar1.RemoveBoldedDate(DateTime.Parse(listBox1.SelectedItem.ToString().Substring(0, listBox1.SelectedItem.ToString().IndexOf(" "))))
         monthCalendar1.UpdateBoldedDates()
         listBox1.Items.RemoveAt(listBox1.SelectedIndex)
         If listBox1.Items.Count = 0 Then
            button3.Enabled = False
         End If
      End Sub 'button2_Click
      '</Snippet3>

      '<Snippet4>
      Private Sub button3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         monthCalendar1.RemoveAllBoldedDates()
         monthCalendar1.UpdateBoldedDates()
         listBox1.Items.Clear()
         button3.Enabled = False
      End Sub 'button3_Click
      '</Snippet4>

      '<Snippet7> 
      Private Sub setCalendarLook()
         monthCalendar1.MinDate = DateTime.Parse("1/1/1900")
         monthCalendar1.MaxDate = DateTime.Parse("12/31/2099")

         checkBox1.Checked = True
         checkBox2.Checked = True
      End Sub 'setCalendarLook
      '</Snippet7>
   End Class 'Form1
End Namespace 'MonthCalender
'</Snippet1>
