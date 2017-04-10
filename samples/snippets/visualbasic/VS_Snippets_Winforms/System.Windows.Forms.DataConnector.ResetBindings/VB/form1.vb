 '<snippet1>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections


Class Form1
    Inherits Form

    ' Declare the objects on the form.
    Private label1 As Label
    Private label2 As Label
    Private textBox1 As TextBox
    Private textBox2 As TextBox
    Private WithEvents button1 As Button
    Private bindingSource1 As BindingSource
    Private states As ArrayList
    
    Public Sub New()

        ' Basic form setup.
        Me.button1 = New System.Windows.Forms.Button()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.textBox2 = New System.Windows.Forms.TextBox()
        Me.button1.Location = New System.Drawing.Point(12, 18)
        Me.button1.Size = New System.Drawing.Size(119, 38)
        Me.button1.Text = "RemoveAt(0)"
        Me.textBox1.Location = New System.Drawing.Point(55, 75)
        Me.textBox1.ReadOnly = True
        Me.textBox1.Size = New System.Drawing.Size(119, 20)
        Me.label1.Location = New System.Drawing.Point(12, 110)
        Me.label1.Size = New System.Drawing.Size(43, 14)
        Me.label1.Text = "Capital:"
        Me.label2.Location = New System.Drawing.Point(12, 78)
        Me.label2.Size = New System.Drawing.Size(34, 14)
        Me.label2.Text = "State:"
        Me.textBox2.Location = New System.Drawing.Point(55, 110)
        Me.textBox2.Size = New System.Drawing.Size(119, 20)
        Me.textBox2.ReadOnly = True
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.button1)
        Me.Text = "Form1"

        ' Create an ArrayList containing some of the State objects.
        states = New ArrayList()
        states.Add(New State("California", "Sacramento"))
        states.Add(New State("Oregon", "Salem"))
        states.Add(New State("Washington", "Olympia"))
        states.Add(New State("Idaho", "Boise"))
        states.Add(New State("Utah", "Salt Lake City"))
        states.Add(New State("Hawaii", "Honolulu"))
        states.Add(New State("Colorado", "Denver"))
        states.Add(New State("Montana", "Helena"))

        bindingSource1 = New BindingSource()

        ' Bind BindingSource1 to the list of states.
        bindingSource1.DataSource = states

        ' Bind the two text boxes to properties of State.
        textBox1.DataBindings.Add("Text", bindingSource1, "Name")
        textBox2.DataBindings.Add("Text", bindingSource1, "Capital")

    End Sub
    '<snippet3>

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        ' If items remain in the list, remove the first item. 
        If states.Count > 0 Then
            states.RemoveAt(0)

            ' Call ResetBindings to update the textboxes.
            bindingSource1.ResetBindings(False)
        End If

    End Sub 'button1_Click
    
    '</snippet3>
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub
    
    ' The State class to add to the ArrayList.
    Private Class State
        Private stateName As String

        Public ReadOnly Property Name() As String
            Get
                Return stateName
            End Get
        End Property

        Private stateCapital As String

        Public ReadOnly Property Capital() As String
            Get
                Return stateCapital
            End Get
        End Property

        Public Sub New(ByVal name As String, ByVal capital As String)
            stateName = name
            stateCapital = capital

        End Sub
    End Class
End Class
'</snippet1>