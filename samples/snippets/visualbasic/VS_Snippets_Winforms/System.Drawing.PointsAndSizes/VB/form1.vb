Option Strict On
Option Explicit On 


Imports System.Drawing
Imports System
Imports System.Windows.Forms

' The following code example demonstrates how to override the  
' OnClosed method on a class derived from Form. 

'<snippet6>
Public Class myForm
    Inherits Form

    Protected Overrides Sub OnClosed(ByVal e As EventArgs)
        MessageBox.Show("The form is now closing.", "Close Warning", _
            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        MyBase.OnClosed(e)
    End Sub

    Public Sub New()
        MyBase.New()
    End Sub

End Class

'</snippet6>


Public Class Form1
    Inherits myForm

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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents subtractButton As System.Windows.Forms.Button
    Friend WithEvents addButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.subtractButton = New System.Windows.Forms.Button
        Me.addButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'subtractButton
        '
        Me.subtractButton.Location = New System.Drawing.Point(192, 40)
        Me.subtractButton.Name = "subtractButton"
        Me.subtractButton.TabIndex = 0
        Me.subtractButton.Text = "subtractButton"
        '
        'addButton
        '
        Me.addButton.Location = New System.Drawing.Point(192, 80)
        Me.addButton.Name = "addButton"
        Me.addButton.TabIndex = 1
        Me.addButton.Text = "addButton"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 224)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Label2"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.subtractButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' The following code example creates points and sizes using several
    ' of the overloaded operators defined for these types. It also
    ' demonstrates how to use a SystemPen.

    ' This example is designed to be used with Windows Forms. Create
    ' a form that contains a Button named subtractButton. Paste the  
    ' code into the form and call the CreatePointsAndSizes method  
    ' from the form's Paint event-handling method, passing e as
    ' PaintEventArgs.
    '<snippet1>
    Private Sub CreatePointsAndSizes(ByVal e As PaintEventArgs)

        ' Create the starting point.
        Dim startPoint As New Point(subtractButton.Size)

        ' Use the addition operator to get the end point.
        Dim endPoint As Point = Point.op_Addition(startPoint, _
            New Size(140, 150))

        ' Draw a line between the points.
        e.Graphics.DrawLine(SystemPens.Highlight, startPoint, endPoint)

        ' Convert the starting point to a size and compare it to the
        ' subtractButton size.  
        Dim buttonSize As Size = Point.op_Explicit(startPoint)
        If (Size.op_Equality(buttonSize, subtractButton.Size)) Then

            ' If the sizes are equal, tell the user.
            e.Graphics.DrawString("The sizes are equal.", _
                New Font(Me.Font, FontStyle.Italic), _
                Brushes.Indigo, 10.0F, 65.0F)
        End If

    End Sub
    '</snippet1>

    ' The following code example demonstrates the G,B,R, and A 
    ' properties of a Color and the Size.op_Implicit member.

    ' This example is designed to be used with a Windows Form. 
    ' Paste the code into the form and call the 
    ' ShowPropertiesOfSlateBlue method from the form's Paint 
    ' event-handling method, passing e as PaintEventArgs.
    '<snippet3>
    Private Sub ShowPropertiesOfSlateBlue(ByVal e As PaintEventArgs)
        Dim slateBlue As Color = Color.FromName("SlateBlue")
        Dim g As Byte = slateBlue.G
        Dim b As Byte = slateBlue.B
        Dim r As Byte = slateBlue.R
        Dim a As Byte = slateBlue.A
        Dim text As String = _
        String.Format("Slate Blue has these ARGB values: Alpha:{0}, " _
           & "red:{1}, green: {2}, blue {3}", New Object() {a, r, g, b})
        e.Graphics.DrawString(text, New Font(Me.Font, FontStyle.Italic), _
            New SolidBrush(slateBlue), _
            New RectangleF(New PointF(0.0F, 0.0F), _
            Size.op_Implicit(Me.Size)))
    End Sub
    '</snippet3>

    Private Sub Form1_Paint(ByVal sender As Object, _
        ByVal e As PaintEventArgs) Handles MyBase.Paint
        'CreatePointsAndSizes(e)
        ShowPropertiesOfSlateBlue(e)

    End Sub

    ' The following code example demonstrates the Subtraction operator.  
    ' The example is designed to be used with Windows Forms. 
    ' To run the example, paste it into a form that contains a button 
    ' named subtractionButton and associate this method with the
    ' button's Click event.
    '<snippet2>
    Private Sub subtractButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles subtractButton.Click
        subtractButton.Size = Size.op_Subtraction(subtractButton.Size, _
            New Size(10, 10))
    End Sub
    '</snippet2>

    ' The following code example demonstrates the Addition operator.  
    ' The example is designed to be used with Windows Forms. To run 
    ' this example, paste it into a form that contains a button named 
    ' addButton and associate this method with the button's Click event.
    '<snippet4>
    Private Sub addButton_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles addButton.Click
        addButton.Size = Size.op_Addition(addButton.Size, New Size(10, 10))
    End Sub
    '</snippet4>

    ' The following code example demonstrates how to use static Round
    ' and Truncate methods to convert a SizeF to a Size.  This example is 
    ' designed to be used with Windows Forms. To run this example paste 
    ' it into a form that contains two Label objects named Label1 
    ' and Label2 and then call this method from the form's constructor.
    '<snippet5>
    Private Sub TruncateAndRoundSizes()

        ' Create a SizeF.
        Dim theSize As New SizeF(75.9, 75.9)

        ' Round the Size.
        Dim roundedSize As Size = Size.Round(theSize)

        ' Truncate the Size.
        Dim truncatedSize As Size = Size.Truncate(theSize)

        'Print out the values on two labels.
        Label1.Text = "Rounded size = " & roundedSize.ToString()
        Label2.Text = "Truncated size = " & truncatedSize.ToString

    End Sub
    '</snippet5>

 ' The following code example demonstrates how to use the 
    ' Point#ctor(int) and Size#ctor(int, int) constructors and the 
    ' ContentAlignment enumeration. To run this example paste this code into  
    ' a Windows Form that contains a label named Label1 and call the 
    ' IntializeLabel1 method in the form's constructor.
    '<snippet7>
    Private Sub InitializeLabel1()

        ' Set a border.
        Label1.BorderStyle = BorderStyle.FixedSingle

        ' Set the size, constructing a size from two integers.
        Label1.Size = New Size(100, 50)

        ' Set the location, constructing a point from a 32-bit integer
        ' (using hexadecimal).
        Label1.Location = New Point(&H280028)

        ' Set and align the text on the lower-right side of the label.
        Label1.TextAlign = ContentAlignment.BottomRight
        Label1.Text = "Bottom Right Alignment"
    End Sub
    '</snippet7>

    Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As EventArgs) Handles MyBase.Load
        TruncateAndRoundSizes()
    End Sub

    <STAThread()> Public Shared Sub main()
        Application.Run(New Form1)
    End Sub
End Class


