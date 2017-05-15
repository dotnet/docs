Imports System
Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 40)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(264, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "TextBox1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 276)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetDataPresent2()
    End Sub
    ' <snippet1>
    Private Sub GetDataPresent2()
        ' Creates a component to store in the data object.
        Dim myComponent As New System.ComponentModel.Component()

        ' Creates a new data object and assigns it the component.
        Dim myDataObject As New DataObject(myComponent)

        'Creates a type to store the type of data.
        Dim myType As Type = myComponent.GetType()

        ' Checks whether the specified data type exists in the object.
        If myDataObject.GetDataPresent(myType) Then
            MessageBox.Show("The specified data is stored in the data object.")
            ' Displays the type of data.
            TextBox1.Text = "The data type is " & myDataObject.GetData(myType).GetType().Name & "."
        Else
            MessageBox.Show("The specified data is not stored in the data object.")
        End If
    End Sub 'GetDataPresent2
    ' </snippet1>


    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub
    
End Class
