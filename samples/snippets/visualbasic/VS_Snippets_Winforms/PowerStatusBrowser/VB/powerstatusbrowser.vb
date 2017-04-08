'<Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms

Public Class PowerStatusBrowserForm
    Inherits System.Windows.Forms.Form
    Private listBox1 As System.Windows.Forms.ListBox
    Private textBox1 As System.Windows.Forms.TextBox  
    
    Public Sub New()
        Me.SuspendLayout()
        InitForm()
        
        'Add each property of the PowerStatus class to the list box.
        Dim t As Type = GetType(System.Windows.Forms.PowerStatus)
        Dim pi As PropertyInfo() = t.GetProperties()
        Dim i As Integer
        For i = 0 To pi.Length - 1
            listBox1.Items.Add(pi(i).Name)
        Next i
        textBox1.Text = "The PowerStatus class has " + pi.Length.ToString() + " properties." + ControlChars.CrLf
        
        ' Configure the list item selected handler for the list box to invoke a 
        ' method that displays the value of each property.           
        AddHandler listBox1.SelectedIndexChanged, AddressOf listBox1_SelectedIndexChanged
        Me.ResumeLayout(False)
    End Sub
        
    Private Sub listBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Return if no item is selected.
        If listBox1.SelectedIndex = - 1 Then
            Return
        End If 
        ' Get the property name from the list item
        Dim propname As String = listBox1.Text
        
        ' Display the value of the selected property of the PowerStatus type.
        Dim t As Type = GetType(System.Windows.Forms.PowerStatus)
        Dim pi As PropertyInfo() = t.GetProperties()
        Dim prop As PropertyInfo = Nothing
        Dim i As Integer
        For i = 0 To pi.Length - 1
            If pi(i).Name = propname Then
                prop = pi(i)
                Exit For
            End If
        Next i 
        Dim propval As Object = prop.GetValue(SystemInformation.PowerStatus, Nothing)
        textBox1.Text += ControlChars.CrLf + "The value of the " + propname + " property is: " + propval.ToString()
    End Sub
    
    Private Sub InitForm()
        ' Initialize the form settings
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.listBox1.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        Me.listBox1.Location = New System.Drawing.Point(8, 16)
        Me.listBox1.Size = New System.Drawing.Size(172, 496)
        Me.listBox1.TabIndex = 0
        Me.textBox1.Anchor = CType(System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        Me.textBox1.Location = New System.Drawing.Point(188, 16)
        Me.textBox1.Multiline = True
        Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textBox1.Size = New System.Drawing.Size(420, 496)
        Me.textBox1.TabIndex = 1
        Me.ClientSize = New System.Drawing.Size(616, 525)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.listBox1)
        Me.Text = "Select a PowerStatus property to get the value of"
    End Sub    
    
    <STAThread()>  _
    Shared Sub Main()
        Application.Run(New PowerStatusBrowserForm())
    End Sub

End Class
'</Snippet1>