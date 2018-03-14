 ' <snippet1>
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms


' <snippet2>
Public Class FirstControl
   Inherits Control
   ' </snippet2>

   Public Sub New()
   End Sub 
   
   
   ' <snippet3>
   ' ContentAlignment is an enumeration defined in the System.Drawing
   ' namespace that specifies the alignment of content on a drawing 
   ' surface.
   Private alignmentValue As ContentAlignment = ContentAlignment.MiddleLeft
   
   ' <snippet5>
   <Category("Alignment"), Description("Specifies the alignment of text.")> _
   Public Property TextAlignment() As ContentAlignment
   ' </snippet5>
      
      Get
         Return alignmentValue
      End Get
      Set
         alignmentValue = value
         
         ' The Invalidate method invokes the OnPaint method described 
         ' in step 3.
         Invalidate()
      End Set
   End Property
' </snippet3>
   
   
   ' <snippet4>
   Protected Overrides Sub OnPaint(e As PaintEventArgs)

      MyBase.OnPaint(e)
      Dim style As New StringFormat()
      style.Alignment = StringAlignment.Near
      Select Case alignmentValue
         Case ContentAlignment.MiddleLeft
            style.Alignment = StringAlignment.Near
         Case ContentAlignment.MiddleRight
            style.Alignment = StringAlignment.Far
         Case ContentAlignment.MiddleCenter
            style.Alignment = StringAlignment.Center
      End Select
      
      ' Call the DrawString method of the System.Drawing class to write   
      ' text. Text and ClientRectangle are properties inherited from
      ' Control.
      e.Graphics.DrawString( _
          me.Text, _
          me.Font, _
          New SolidBrush(ForeColor), _
          RectangleF.op_Implicit(ClientRectangle), _
          style)

   End Sub
   ' </snippet4>

End Class
' </snippet1>