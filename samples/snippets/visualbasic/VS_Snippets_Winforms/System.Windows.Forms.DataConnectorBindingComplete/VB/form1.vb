'<snippet3>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Class Form1
    Inherits Form

    Private  BindingSource1 As New BindingSource()
    Private textBox1 As New TextBox()
    Private textBox2 As New TextBox()
    Private textBox3 As New TextBox()

    Public Sub New()

        'Set up the textbox controls.
        Me.textBox1.Location = New System.Drawing.Point(82, 13)
        Me.textBox1.TabIndex = 1
        Me.textBox2.Location = New System.Drawing.Point(81, 47)
        Me.textBox2.TabIndex = 2
        Me.textBox3.Location = New System.Drawing.Point(81, 83)
        Me.textBox3.TabIndex = 3

        ' Add the textbox controls to the form
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.textBox3)

    End Sub

    '<snippet1>
    Private WithEvents partNameBinding As Binding
    Private WithEvents partNumberBinding As Binding

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        ' Set the DataSource of BindingSource1 to the Part type.
        BindingSource1.DataSource = GetType(Part)

        ' Bind the textboxes to the properties of the Part type, 
        ' enabling formatting.
        partNameBinding = textBox1.DataBindings.Add("Text", BindingSource1, _
            "PartName", True)
        partNumberBinding = textBox2.DataBindings.Add("Text", BindingSource1, _
            "PartNumber", True)
        
        'Bind the textbox to the PartPrice value with currency formatting.
        textBox3.DataBindings.Add("Text", BindingSource1, "PartPrice", _
            True, DataSourceUpdateMode.OnPropertyChanged, 0, "C")

        ' Add a new part to BindingSource1.
        BindingSource1.Add(New Part("Widget", 1234, 12.45))
    End Sub

    ' Handle the BindingComplete event to catch errors and exceptions 
    ' in binding process.
    Sub partNumberBinding_BindingComplete(ByVal sender As Object, _
        ByVal e As BindingCompleteEventArgs) _
        Handles partNumberBinding.BindingComplete

        If Not e.BindingCompleteState = BindingCompleteState.Success Then
            MessageBox.Show("partNumberBinding: " + e.ErrorText)
        End If

    End Sub

    ' Handle the BindingComplete event to catch errors and exceptions 
    ' in binding process.
    Sub partNameBinding_BindingComplete(ByVal sender As Object, _
        ByVal e As BindingCompleteEventArgs) _
        Handles partNameBinding.BindingComplete

        If Not e.BindingCompleteState = BindingCompleteState.Success Then
            MessageBox.Show("partNameBinding: " + e.ErrorText)
        End If
       
    End Sub
    '</snippet1>

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

End Class

'<snippet2>
' Represents a business object that throws exceptions when invalid 
' values are entered for some of its properties.
Public Class Part
    Private name As String
    Private number As Integer
    Private price As Double

    Public Sub New(ByVal name As String, ByVal number As Integer, _
        ByVal price As Double)

        PartName = name
        PartNumber = number
        PartPrice = price
    End Sub


    Public Property PartName() As String
        Get
            Return name
        End Get
        Set(ByVal value As String)
            If Value.Length <= 0 Then
                Throw New Exception("Each part must have a name.")
            Else
                name = Value
            End If
        End Set
    End Property

    Public Property PartPrice() As Double
        Get
            Return price
        End Get
        Set(ByVal value As Double)
            price = Value
        End Set
    End Property

    Public Property PartNumber() As Integer
        Get
            Return number
        End Get
        Set(ByVal value As Integer)
            If Value < 100 Then
                Throw New Exception("Invalid part number." _
                    & " Part numbers must be greater than 100.")
            Else
                number = Value
            End If
        End Set
    End Property
End Class
'</snippet2>
'</snippet3>