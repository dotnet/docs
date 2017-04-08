
#Region "Using directives"

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms


#End Region


Class Form1
    Inherits Form
    Private BindingSource1 As BindingSource
    Private components As System.ComponentModel.IContainer

    Private WithEvents button1 As Button



    Public Sub New()
        AddHandler Me.Load, AddressOf Form1_Load
        AddHandler Me.Paint, AddressOf Form1_Paint
        Me.BindingSource1 = New BindingSource()
        Me.button1 = New Button()
        button1.Text = "Move Next"
        Me.button1.Location = New System.Drawing.Point(147, 129)
        AddHandler Me.button1.Click, AddressOf Me.button1_Click

        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.button1)

    End Sub 'New

    ' The following snippet demonstrates the BindingSource.MoveNext, BindingSource.Current,
    ' BindingSource.CurrentItem, BindingSource.Position and the BindingSourceItem.Value members.
    ' To run this example paste the code into a form that imports the System.Drawing.Drawing2d 
    ' namespace and contains a BindingSource
    ' named BindingSource1 and a button named button1.  Associate the
    ' Form1_Load and the Form1_Paint method with the load and paint events for the form,
    ' and the button1_click method with the click event for button1.

    ' If you are using VB, you may need to add a reference to the System.Data.dll.
    '<snippet1>
    Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        ' Set the data source to the Brush type and populate
        ' BindingSource1 with some brushes.
        BindingSource1.DataSource = GetType(System.Drawing.Brush)
        BindingSource1.Add(New TextureBrush(New Bitmap(GetType(Button), _
            "Button.bmp")))
        BindingSource1.Add(New HatchBrush(HatchStyle.Cross, Color.Red))
        BindingSource1.Add(New SolidBrush(Color.Blue))

    End Sub



    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
         Handles button1.Click

        ' If you are not at the end of the list, move to the next item
        ' in the BindingSource.
        If BindingSource1.Position + 1 < BindingSource1.Count Then
            BindingSource1.MoveNext()

            ' Otherwise, move back to the first item.
        Else
            BindingSource1.MoveFirst()
        End If

        ' Force the form to repaint.
        Me.Invalidate()

    End Sub


    Sub Form1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)

        ' Get the current item in the BindingSource.
        Dim item As Brush = CType(BindingSource1.Current, Brush)

        ' If the current type is a TextureBrush, fill an ellipse.
        If item.GetType().Equals(GetType(TextureBrush)) Then
            e.Graphics.FillEllipse(item, _
            e.ClipRectangle)

            ' If the current type is a HatchBrush, fill a triangle.
        ElseIf item.GetType().Equals(GetType(HatchBrush)) Then
            e.Graphics.FillPolygon(item, New Point() _
             {New Point(0, 0), New Point(0, 200), New Point(200, 0)})

            ' Otherwise, fill a rectangle.
        Else
            e.Graphics.FillRectangle(item, e.ClipRectangle)
        End If

    End Sub

    '</snippet1>
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub 'Main

    Private Sub InitializeComponent()
        '
        'Form1
       
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"

    End Sub
End Class 'Form1 




