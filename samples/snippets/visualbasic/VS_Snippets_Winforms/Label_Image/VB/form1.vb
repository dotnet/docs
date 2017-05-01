Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
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
                    
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    '<Snippet1>
    Private Sub CreateMyLabel()

        ' Create a new label and bitmap.

        Dim Label1 As New Label()
        Dim Image1 As Image

        Image1 = Image.FromFile("c:\\MyImage.bmp")
       

        ' Set the size of the label to accommodate the bitmap size.

        Label1.Size = Image1.Size        

        ' Initialize the label control's Image property.

        Label1.Image = Image1

        ' ...Code to add the control to the form...

    End Sub
    '</Snippet1>

   Public Shared Sub Main()
      Application.Run(new Form1())
   End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CreateMyLabel()

    End Sub
End Class
