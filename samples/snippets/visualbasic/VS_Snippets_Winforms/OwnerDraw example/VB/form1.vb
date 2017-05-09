Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data

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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()



        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 133)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CreateMyMenu()

    End Sub

    Private Sub CreateMyMenu()

        ' Create a new MainMenu and a group of menu items...

        Me.MainMenu1 = New System.Windows.Forms.MainMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()


        ' Add the MenuItem objects to the MainMenu...

        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3})

        '
        'MenuItem1 properties...
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = ""
        Me.MenuItem1.OwnerDraw = True

        ' MenuItem2 properties...


        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = ""
        Me.MenuItem2.OwnerDraw = True

        ' MenuItem3 properties...

        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = ""
        Me.MenuItem3.OwnerDraw = True

        ' Set the main menu...

        Me.Menu = Me.MainMenu1


    End Sub

    '<snippet1>
    ' The DrawItem event handler.
    Private Sub MenuItem1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MenuItem1.DrawItem


        Dim MyCaption As String = "Owner Draw Item1"

        ' Create a Brush and a Font with which to draw the item.
        Dim MyBrush As System.Drawing.Brush = System.Drawing.Brushes.AliceBlue
        Dim MyFont As New Font(FontFamily.GenericSerif, 14, FontStyle.Underline, GraphicsUnit.Pixel)
        Dim MySizeF As SizeF = e.Graphics.MeasureString(MyCaption, MyFont)

        ' Draw the item, and then draw a Rectangle around it.
        e.Graphics.DrawString(MyCaption, MyFont, MyBrush, e.Bounds.X, e.Bounds.Y)
        e.Graphics.DrawRectangle(Drawing.Pens.Black, New Rectangle(e.Bounds.X, e.Bounds.Y, MySizeF.Width, MySizeF.Height))

    End Sub

    '</snippet1>

    Private Sub MenuItem2_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MenuItem2.DrawItem


        Dim MyCaption As String = "Owner Draw Item2"
        Dim MyBrush As System.Drawing.Brush = System.Drawing.Brushes.AliceBlue
        Dim MyFont As New Font(FontFamily.GenericSerif, 14, FontStyle.Underline, GraphicsUnit.Pixel)
        Dim MySizeF As SizeF = e.Graphics.MeasureString(MyCaption, MyFont)

        e.Graphics.DrawString(MyCaption, MyFont, MyBrush, e.Bounds.X, e.Bounds.Y + 20)
        e.Graphics.DrawRectangle(Drawing.Pens.Black, New Rectangle(e.Bounds.X, e.Bounds.Y + 20, MySizeF.Width, MySizeF.Height))


    End Sub

    Private Sub MenuItem3_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MenuItem3.DrawItem

        Dim MyCaption As String = "Owner Draw Item3"
        Dim MyBrush As System.Drawing.Brush = System.Drawing.Brushes.AliceBlue
        Dim MyFont As New Font(FontFamily.GenericSerif, 14, FontStyle.Underline, GraphicsUnit.Pixel)
        Dim MySizeF As SizeF = e.Graphics.MeasureString(MyCaption, MyFont)

        e.Graphics.DrawString(MyCaption, MyFont, MyBrush, e.Bounds.X, e.Bounds.Y + 40)
        e.Graphics.DrawRectangle(Drawing.Pens.Black, New Rectangle(e.Bounds.X, e.Bounds.Y + 40, MySizeF.Width, MySizeF.Height))

    End Sub

   Public Shared Sub Main()
      Application.Run(New Form1())
   End Sub
End Class
