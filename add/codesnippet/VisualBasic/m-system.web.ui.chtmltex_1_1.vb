    ' Create a custom CHTML Adapter for a 
    ' class, named SimpleLabel.
    Public Class ChtmlSimpleLabelAdapter
         Inherits WebControlAdapter

      ' Create the Control property to access
      ' the properties and methods of the
      ' SimpleLabel class.
      Protected Shadows ReadOnly Property Control() As SimpleLabel
         Get
            Return CType(MyBase.Control, SimpleLabel)
         End Get
      End Property
   
   
      ' Override the Render method to render text
      ' in CHTML with the style defined by the control
      ' and a <br> element after the text and styles
      ' have been written to the output stream. 
        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
            Dim w As ChtmlTextWriter = New ChtmlTextWriter(writer)
            Dim value As String = Control.Text

            ' Render the text of the control using
            ' the control's style settings.
            w.EnterStyle(Control.ControlStyle)
            w.Write(value)
            w.ExitStyle(Control.ControlStyle)
            w.WriteBreak()

        End Sub
  End Class