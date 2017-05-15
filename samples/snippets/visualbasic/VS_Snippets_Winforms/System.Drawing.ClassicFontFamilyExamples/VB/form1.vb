Imports System.Drawing
Imports System
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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.Text = "Form1"
    End Sub

#End Region


    ' Snippet for: M:System.Drawing.FontFamily.Equals(System.Object)
    ' <snippet1>
    Public Sub Equals_Example(ByVal e As PaintEventArgs)

        ' Create two FontFamily objects.
        Dim firstFontFamily As New FontFamily("Arial")
        Dim secondFontFamily As New FontFamily("Times New Roman")

        ' Check to see if the two font families are equivalent.
        Dim equalFonts As Boolean = _
        firstFontFamily.Equals(secondFontFamily)

        ' Display the result of the test in a message box.
        MessageBox.Show(equalFonts.ToString())
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.FontFamily.GetCellAscent(System.Drawing.FontStyle)
    ' <snippet2>
    Public Sub GetCellAscent_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim ascentFontFamily As New FontFamily("arial")

        ' Get the cell ascent of the font family in design units.
        Dim cellAscent As Integer = _
        ascentFontFamily.GetCellAscent(FontStyle.Regular)

        ' Draw the result as a string to the screen.
        e.Graphics.DrawString("ascentFontFamily.GetCellAscent() returns " _
        & cellAscent.ToString() & ".", New Font(ascentFontFamily, 16), _
        Brushes.Black, New PointF(0, 0))
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.FontFamily.GetCellDescent(System.Drawing.FontStyle)
    ' <snippet3>
    Public Sub GetCellDescent_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim descentFontFamily As New FontFamily("arial")

        ' Get the cell descent of the font family in design units.
        Dim cellDescent As Integer = _
        descentFontFamily.GetCellDescent(FontStyle.Regular)

        ' Draw the result as a string to the screen.
        e.Graphics.DrawString("descentFontFamily.GetCellDescent() returns " _
        & cellDescent.ToString() & ".", New Font(descentFontFamily, 16), _
        Brushes.Black, New PointF(0, 0))
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.FontFamily.GetEmHeight(System.Drawing.FontStyle)
    ' <snippet4>
    Public Sub GetEmHeight_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim emFontFamily As New FontFamily("arial")

        ' Get the em height of the font family in design units.
        Dim emHeight As Integer = _
        emFontFamily.GetEmHeight(FontStyle.Regular)

        ' Draw the result as a string to the screen.
        e.Graphics.DrawString("emFontFamily.GetEmHeight() returns " & _
        emHeight.ToString() + ".", New Font(emFontFamily, 16), _
        Brushes.Black, New PointF(0, 0))
    End Sub
    ' </snippet4>


     ' Snippet for: M:System.Drawing.FontFamily.GetFamilies(System.Drawing.Graphics)
    ' <snippet5>
    Public Sub GetFamilies_Example(ByVal e As PaintEventArgs)

        ' Get an array of the available font families.
        Dim families As FontFamily() = FontFamily.GetFamilies(e.Graphics)

        ' Draw text using each of the font families.
        Dim familiesFont As Font
        Dim familyString As String
        Dim spacing As Single = 0
        Dim family As FontFamily
        For Each family In families
            If (family.IsStyleAvailable(FontStyle.Regular)) Then
                familiesFont = New Font(family, 16)
                familyString = "This is the " + family.Name + " family."
                e.Graphics.DrawString(familyString, familiesFont, _
                    Brushes.Black, New PointF(0, spacing))
                spacing += familiesFont.Height
            End If

        Next family
    End Sub
    ' </snippet5>

    ' Snippet for: M:System.Drawing.FontFamily.GetHashCode
    ' <snippet6>
    Public Sub GetHashCode_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim myFontFamily As New FontFamily("Arial")

        ' Get the hash code for myFontFamily.
        Dim hashCode As Integer = myFontFamily.GetHashCode()

        ' Draw the value of hashCode to the screen as a string.
        e.Graphics.DrawString("hashCode = " & hashCode.ToString(), _
        New Font(myFontFamily, 16), Brushes.Black, New PointF(0, 0))
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.FontFamily.GetLineSpacing(System.Drawing.FontStyle)
    ' <snippet7>
    Public Sub GetLineSpacing_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim myFontFamily As New FontFamily("Arial")

        ' Get the line spacing for myFontFamily.
        Dim lineSpacing As Integer = _
        myFontFamily.GetLineSpacing(FontStyle.Regular)

        ' Draw the value of lineSpacing to the screen as a string.
        e.Graphics.DrawString("lineSpacing = " & lineSpacing.ToString(), _
        New Font(myFontFamily, 16), Brushes.Black, New PointF(0, 0))
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.FontFamily.GetName(System.Int32)
    ' <snippet8>
    Public Sub GetName_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim myFontFamily As New FontFamily("Arial")

        ' Get the name of myFontFamily.
        Dim familyName As String = myFontFamily.GetName(0)

        ' Draw the name of the myFontFamily to the screen as a string.
        e.Graphics.DrawString("The family name is " & familyName, _
        New Font(myFontFamily, 16), Brushes.Black, New PointF(0, 0))
    End Sub
    ' </snippet8>


    ' Snippet for: M:System.Drawing.FontFamily.IsStyleAvailable(System.Drawing.FontStyle)
    ' <snippet9>
    Public Sub IsStyleAvailable_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim myFontFamily As New FontFamily("Arial")

        ' Test whether myFontFamily is available in Italic.
        If myFontFamily.IsStyleAvailable(FontStyle.Italic) Then

            ' Create a Font object using myFontFamily.
            Dim familyFont As New Font(myFontFamily, 16, FontStyle.Italic)

            ' Use familyFont to draw text to the screen.
            e.Graphics.DrawString(myFontFamily.Name & _
            " is available in Italic", familyFont, Brushes.Black, _
            New PointF(0, 0))
        End If
    End Sub
    ' </snippet9>


    ' Snippet for: M:System.Drawing.FontFamily.ToString
    ' <snippet10>
    Public Sub ToString_Example(ByVal e As PaintEventArgs)

        ' Create a FontFamily object.
        Dim myFontFamily As New FontFamily("Arial")

        ' Draw a string representation of myFontFamily to the screen.
        e.Graphics.DrawString(myFontFamily.ToString(), _
        New Font(myFontFamily, 16), Brushes.Black, New PointF(0, 0))
    End Sub
    ' </snippet10>

     <System.STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
