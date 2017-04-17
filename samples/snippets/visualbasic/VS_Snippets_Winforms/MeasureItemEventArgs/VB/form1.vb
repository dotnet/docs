Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace ListBoxOwnerDrawSnippet

   '<Snippet1>
   Public Class Form1
      Inherits System.Windows.Forms.Form
      Private WithEvents listBox1 As System.Windows.Forms.ListBox
      Private components As System.ComponentModel.Container = Nothing

      Private FontSize As Single = 12.0F

      '
      '  This sample displays a ListBox that contains a list of all the fonts
      '  installed on the system and draws each item in its respective font.
      '
      Public Sub New()
         InitializeComponent()

         ' Populate control with the fonts installed on the system.
         Dim families As FontFamily() = FontFamily.Families

         Dim family As FontFamily
         For Each family In families
            Dim style As FontStyle = FontStyle.Regular

            ' Monotype Corsiva is only available in italic
            If family.Name = "Monotype Corsiva" Then
               style = style Or FontStyle.Italic
            End If

            listBox1.Items.Add(New ListBoxFontItem(New Font(family.Name, FontSize, style, GraphicsUnit.Point)))
         Next family
      End Sub


      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If

            If (foreColorBrush IsNot Nothing) Then
               foreColorBrush.Dispose()
            End If
         End If

         MyBase.Dispose(disposing)
      End Sub

      Private Sub InitializeComponent()
         Me.listBox1 = New System.Windows.Forms.ListBox()
         Me.SuspendLayout()
         ' 
         ' listBox1
         ' 
         Me.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
         Me.listBox1.Location = New System.Drawing.Point(16, 48)
         Me.listBox1.Name = "listBox1"
         Me.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
         Me.listBox1.Size = New System.Drawing.Size(256, 134)
         Me.listBox1.TabIndex = 0
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.listBox1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         Me.ResumeLayout(False)
      End Sub

      <STAThread()> Shared Sub Main()
         Application.Run(New Form1())
      End Sub

      Private Sub listBox1_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles listBox1.MeasureItem
         Dim font As Font = CType(listBox1.Items(e.Index), ListBoxFontItem).Font
         Dim stringSize As SizeF = e.Graphics.MeasureString(font.Name, font)

         ' Set the height and width of the item
         e.ItemHeight = CInt(stringSize.Height)
         e.ItemWidth = CInt(stringSize.Width)
      End Sub

      ' For efficiency, cache the brush used for drawing.
      Private foreColorBrush As SolidBrush

      Private Sub listBox1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles listBox1.DrawItem
         Dim brush As Brush

         ' Create the brush using the ForeColor specified by the DrawItemEventArgs
         If foreColorBrush Is Nothing Then
            foreColorBrush = New SolidBrush(e.ForeColor)
         Else
            If Not foreColorBrush.Color.Equals(e.ForeColor) Then
               ' The control's ForeColor has changed, so dispose of the cached brush and
               ' create a new one.
               foreColorBrush.Dispose()
               foreColorBrush = New SolidBrush(e.ForeColor)
            End If
         End If

         ' Select the appropriate brush depending on if the item is selected.
         ' Since State can be a combinateion (bit-flag) of enum values, you can't use
         ' "==" to compare them.
         If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            brush = SystemBrushes.HighlightText
         Else
            brush = foreColorBrush
         End If

         ' Perform the painting.
         Dim font As Font = CType(listBox1.Items(e.Index), ListBoxFontItem).Font
         e.DrawBackground()
         e.Graphics.DrawString(font.Name, font, brush, e.Bounds.X, e.Bounds.Y)
         e.DrawFocusRectangle()
      End Sub

      '
      '  A wrapper class for use with storing Fonts in a ListBox.  Since ListBox uses the
      '  ToString() of its items for the text it displays, this class is needed to return
      '  the name of the font, rather than its ToString() value.
      '
      Public Class ListBoxFontItem
         Public Font As Font

         Public Sub New(ByVal f As Font)
            Font = f
         End Sub

         Public Overrides Function ToString() As String
            Return Font.Name
         End Function
      End Class
   End Class
   '</Snippet1>
End Namespace 'ListBoxOwnerDrawSnippet
