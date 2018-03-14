Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

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
        components = New System.ComponentModel.Container
        Me.Text = "Form1"
    End Sub

#End Region


    ' Snippet for: M:System.Drawing.Font.Clone
    ' <snippet1>
    Public Sub Clone_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim myFont As New Font("Arial", 16)

        ' Create a copy of myFont.
        Dim cloneFont As Font = CType(myFont.Clone(), Font)

        ' Use cloneFont to draw text to the screen.
        e.Graphics.DrawString("This is a cloned font", cloneFont, _
        Brushes.Black, 0, 0)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Font.Equals(System.Object)
    ' <snippet2>
    Public Sub Equals_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim firstFont As New Font("Arial", 16)

        ' Create a second Font object.
        Dim secondFont As New Font(New FontFamily("Arial"), 16)

        ' Test to see if firstFont is identical to secondFont.
        Dim fontTest As Boolean = firstFont.Equals(secondFont)

        ' Display a message box with the result of the test.
        MessageBox.Show(fontTest.ToString())
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Font.FromHfont(System.IntPtr)
    ' <snippet3>
    <System.Runtime.InteropServices.DllImportAttribute("GDI32.DLL")> _
    Private Shared Function GetStockObject(ByVal fnObject As Integer) As IntPtr
    End Function
    Public Sub FromHfont_Example(ByVal e As PaintEventArgs)

        ' Get a handle for a GDI font.
        Dim hFont As IntPtr = GetStockObject(17)

        ' Create a Font object from hFont.
        Dim hfontFont As Font = Font.FromHfont(hFont)

        ' Use hfontFont to draw text to the screen.
        e.Graphics.DrawString("This font is from a GDI HFONT", hfontFont, _
        Brushes.Black, 0, 0)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Font.GetHashCode
    ' <snippet4>
    Public Sub GetHashCode_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim myFont As New Font("Arial", 16)

        ' Get the hash code for myFont.
        Dim hashCode As Integer = myFont.GetHashCode()

        ' Display the hash code in a message box.
        MessageBox.Show(hashCode.ToString())
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Font.GetHeight(System.Drawing.Graphics)
    ' <snippet5>
    Public Sub GetHeight_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim myFont As New Font("Arial", 16)

        'Draw text to the screen with myFont.
        e.Graphics.DrawString("This is the first line", myFont, _
        Brushes.Black, New PointF(0, 0))

        'Get the height of myFont.
        Dim height As Single = myFont.GetHeight(e.Graphics)

        'Draw text immediately below the first line of text.
        e.Graphics.DrawString("This is the second line", myFont, _
        Brushes.Black, New PointF(0, height))
    End Sub
    ' </snippet5>

 ' Snippet for: M:System.Drawing.Font.ToHfont
    ' <snippet6>

    ' Reference the DeleteObject method in the GDI library.
    <System.Runtime.InteropServices.DllImportAttribute("GDI32.DLL")> _
    Private Shared Function DeleteObject(ByVal objectHandle As IntPtr) As Boolean
    End Function

    Public Sub ToHfont_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim myFont As New Font("Arial", 16)

        ' Get a handle to the Font object.
        Dim hFont As IntPtr = myFont.ToHfont()

        ' Display a message box with the value of hFont.
        MessageBox.Show(hFont.ToString())

        ' Dispose of the hFont.
        DeleteObject(hFont)
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.Font.ToString
    ' <snippet7>
    Public Sub ToString_Example(ByVal e As PaintEventArgs)

        ' Create a Font object.
        Dim myFont As New Font("Arial", 16)

        ' Get a string that represents myFont.
        Dim fontString As String = myFont.ToString()

        ' Display a message box with fontString.
        MessageBox.Show(fontString)
    End Sub
    ' </snippet7>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
