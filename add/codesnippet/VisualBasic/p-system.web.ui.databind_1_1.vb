   <DataBindingHandlerAttribute(GetType(System.Web.UI.Design.TextDataBindingHandler))>  _
   Public Class SimpleWebControl
      Inherits WebControl
      ' Insert code for class members here
   End Class 'SimpleWebControl

   Class TestAttributes
      
      Public Shared Sub Main()
         Dim myAttributes As System.ComponentModel.AttributeCollection = _
            TypeDescriptor.GetAttributes(GetType(SimpleWebControl))
         
         Dim myDataBindingHandlerAttribute As DataBindingHandlerAttribute = _
            myAttributes(GetType(DataBindingHandlerAttribute))
         
         If Not (myDataBindingHandlerAttribute Is Nothing) Then
            Console.Write(("DataBindingHandlerAttribute's HandlerTypeName is : " + _
               myDataBindingHandlerAttribute.HandlerTypeName))
         End If
      End Sub 'Main
   End Class 'TestAttributes