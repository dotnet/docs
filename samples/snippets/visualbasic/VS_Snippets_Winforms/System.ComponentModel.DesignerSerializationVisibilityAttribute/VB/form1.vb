' <snippet1>
' <snippet2>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
' </snippet2>

' This sample demonstrates the use of the 
' DesignerSerializationVisibility attribute
' to serialize a collection of strings
' at design time.
Class Form1
   Inherits Form
   Private serializationDemoControl1 As SerializationDemoControl

   
   Public Sub New()
      InitializeComponent()
    End Sub
   
   
   ' The Windows Forms Designer emits code to this method. 
   ' If an instance of SerializationDemoControl is added 
   ' to the form, the Strings will be serialized here.
   Private Sub InitializeComponent()
        Me.serializationDemoControl1 = New SerializationDemoControl
        Me.SuspendLayout()
        '
        'serializationDemoControl1
        '
        Me.serializationDemoControl1.Location = New System.Drawing.Point(0, 0)
        Me.serializationDemoControl1.Name = "serializationDemoControl1"
        Me.serializationDemoControl1.Padding = New System.Windows.Forms.Padding(5)
        Me.serializationDemoControl1.TabIndex = 0
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.serializationDemoControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
    End Sub
End Class

' <snippet3>
Public Class SerializationDemoControl
   Inherits UserControl
   ' This is the TextBox contained by 
   ' the SerializationDemoControl.
   Private textBox1 As System.Windows.Forms.TextBox
   
   ' <snippet4>
   ' This field backs the Strings property.
    Private stringsValue(1) As String
    ' </snippet4>

    Public Sub New()
        InitializeComponent()
    End Sub
   
   ' <snippet5>
   ' When the DesignerSerializationVisibility attribute has
   ' a value of "Content" or "Visible" the designer will 
   ' serialize the property. This property can also be edited 
   ' at design time with a CollectionEditor.
    <DesignerSerializationVisibility( _
        DesignerSerializationVisibility.Content)> _
    Public Property Strings() As String()
        Get
            Return Me.stringsValue
        End Get
        Set(ByVal value As String())
            Me.stringsValue = Value

            ' Populate the contained TextBox with the values
            ' in the stringsValue array.
            Dim sb As New StringBuilder(Me.stringsValue.Length)

            Dim i As Integer
            For i = 0 To (Me.stringsValue.Length) - 1
                sb.Append(Me.stringsValue(i))
                sb.Append(ControlChars.Cr + ControlChars.Lf)
            Next i

            Me.textBox1.Text = sb.ToString()
        End Set
    End Property
    ' </snippet5>

   Private Sub InitializeComponent()
      Me.textBox1 = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      
      ' Settings for the contained TextBox control.
      Me.textBox1.AutoSize = False
      Me.textBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.textBox1.Location = New System.Drawing.Point(5, 5)
      Me.textBox1.Margin = New System.Windows.Forms.Padding(0)
      Me.textBox1.Multiline = True
      Me.textBox1.Name = "textBox1"
      Me.textBox1.ReadOnly = True
      Me.textBox1.ScrollBars = ScrollBars.Vertical
      Me.textBox1.Size = New System.Drawing.Size(140, 140)
      Me.textBox1.TabIndex = 0
      
      ' Settings for SerializationDemoControl.
      Me.Controls.Add(textBox1)
      Me.Name = "SerializationDemoControl"
      Me.Padding = New System.Windows.Forms.Padding(5)
      Me.ResumeLayout(False)
    End Sub
End Class
' </snippet3>
' </snippet1>