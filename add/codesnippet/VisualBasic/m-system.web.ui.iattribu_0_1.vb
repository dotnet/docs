   ' Implement the SetAttribute method for the control. When
   ' this method is called from a page, the control's properties
   ' are set to values defined in the page.
   Public Sub SetAttribute(name As String, value1 As String) Implements IAttributeAccessor.SetAttribute
      ViewState(name) = value1
   End Sub 'SetAttribute
   