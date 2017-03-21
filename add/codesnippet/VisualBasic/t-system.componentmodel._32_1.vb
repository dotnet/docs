Dim events As EventDescriptorCollection = TypeDescriptor.GetEvents(Button1)
' Displays each event's information in the collection in a text box.
Dim myEvent As EventDescriptor
For Each myEvent In events
    TextBox1.Text &= myEvent.Category & ControlChars.Cr
    TextBox1.Text &= myEvent.Description & ControlChars.Cr
    TextBox1.Text &= myEvent.DisplayName & ControlChars.Cr
Next myEvent