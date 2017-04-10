' System.Web.UI.DataBindingHandlerAttribute.HandlerTypeName

'   The following program demonstrates 'HandlerTypeName' property of 
'   'DataBindingHandlerAttribute' class.
'   A new control 'SimpleWebControl' is created. DataBindingHandlerAttribute is attached
'   to the 'SimpleWebControl'. The attributes and their corresponding handler type name 
'   of the custom control are displayed to the console.

Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel


Namespace DataBindingHandlerAttributeTest
' <Snippet1>
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
' </Snippet1>
End Namespace 'DataBindingHandlerAttributeTest
