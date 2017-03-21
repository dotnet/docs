   ' Implement the GetAttribute method for the control. When
   ' this method is called from a page, the values for the control's
   ' properties can be displayed in the page.
   Public Function GetAttribute(name As String) As String Implements IAttributeAccessor.GetAttribute
      Return CType(ViewState(name), String)
   End Function 'GetAttribute
   