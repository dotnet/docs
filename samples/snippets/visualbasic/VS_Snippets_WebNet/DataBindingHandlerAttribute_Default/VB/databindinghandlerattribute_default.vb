' System.Web.UI.DataBindingHandlerAttribute.Default

' The following program demonstrates 'Default' field of 'DataBindingHandlerAttribute' class.
' It obtains an instance of 'DataBindingHandlerAttribute' class by using 'Default' field
' of 'DataBindingHandlerAttribute' class. Then it displays the value of 'HandlerTypeName'
' property.

Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design

Namespace DataBindingHandlerAttributeTest
   Class TestAttributes
      Public Shared Sub Main()
         Try
' <Snippet1>
            Dim myDataBindingHandlerAttribute As DataBindingHandlerAttribute = _
                  DataBindingHandlerAttribute.Default
' </Snippet1>
            Console.WriteLine("Hash code for DataBindingHandlerAttribute " + _
                  "instance is : " + myDataBindingHandlerAttribute.GetHashCode().ToString)
         Catch e As Exception
            Console.WriteLine("Exception : " + e.Message)
         End Try
      End Sub
   End Class 
End Namespace