' System.Web.Services.Protocols.LogicalMethodTypes.Sync
' System.Web.Services.Protocols.LogicalMethodTypes.LogicalMethodTypes
' System.Web.Services.Protocols.LogicalMethodInfo.MethodInfo

' All the following have been grouped as one snippet : Snippet4

' System.Web.Services.Protocols.LogicalMethodInfo.GetCustomAttribute(Type)
' System.Web.Services.Protocols.LogicalMethodInfo.GetCustomAttributes(Type)
' System.Web.Services.Protocols.LogicalMethodInfo.ReturnTypeCustomAttributeProvider
' System.Web.Services.Protocols.LogicalMethodInfo.CustomAttributeProvider

' This following example demonstrates the 'MethodInfo',
' 'ReturnTypeCustomAttributeProvider', 'CustomAttributeProvider',
' properties and 'GetCustomAttribute(Type)', 
' 'GetCustomAttributes(Type)' methods of the 'LogicalMethodInfo' class
' and 'Sync' enum member of 'LogicalMethodTypes' enumeration. 
' This example demonstrates custom attributes and return attributes of the
' 'Add' method.
' 
' Note : The 'LogicalMethodInfo' class should only be used with
' 'SoapMessage'. 'SoapClientMessage' and 'SoapServerMessage' contain
' a property named 'MethodInfo' which provides for an instance of
' 'LogicalMethodInfo'. If you are interested only in the reflection
' of a type then use the 'System.Reflection' namespace and not this
' class. This class gives information about the method invoked for
' a web service and hence should only be used as such. For example
' purposes it is being showed in a more simplified scenario.


' <Snippet4>
Imports System
Imports System.Reflection
Imports System.Web.Services.Protocols
Imports MicroSoft.VisualBasic

' Define a custom attribute with one named parameter.
<AttributeUsage(AttributeTargets.Method Or AttributeTargets.ReturnValue, AllowMultiple := True)>  _
Public Class MyAttribute
   Inherits Attribute

   Private myName As String
   
   Public Sub New(name As String)
      myName = name
   End Sub 'New
   
   Public ReadOnly Property Name() As String
      Get
         Return myName
      End Get
   End Property
End Class 'MyAttribute

Public Class MyService
   
<MyAttribute("This is the first sample attribute"), MyAttribute("This is the second sample attribute")>  _
   Public Function Add(xValue As Integer, yValue As Integer)  _
                 As<MyAttribute("This is the return sample attribute")> Integer
      Return xValue + yValue
   End Function 'Add
End Class 'MyService


Public Class LogicalMethodInfo_GetCustomAttribute
   
   Public Shared Sub Main()
' <Snippet3>      
      Dim myType As Type = GetType(MyService)
      Dim myMethodInfo As MethodInfo = myType.GetMethod("Add")
' <Snippet1>
' <Snippet2>
      ' Create a synchronous 'LogicalMethodInfo' instance.
      Dim myLogicalMethodInfo As LogicalMethodInfo = _
                 LogicalMethodInfo.Create(New MethodInfo() {myMethodInfo}, LogicalMethodTypes.Sync)(0)
' </Snippet2>
' </Snippet1>
      ' Display the method for which the attributes are being displayed.
      Console.WriteLine(ControlChars.NewLine + "Displaying the attributes for the method : {0}" + _
                 ControlChars.NewLine, myLogicalMethodInfo.MethodInfo.ToString())
      
' </Snippet3>
      ' Displaying a custom attribute of type 'MyAttribute'
      Console.WriteLine(ControlChars.NewLine + "Displaying attribute of type 'MyAttribute'" + _
                 ControlChars.NewLine)
      Dim attribute As Object = myLogicalMethodInfo.GetCustomAttribute(GetType(MyAttribute))
      Console.WriteLine(CType(attribute, MyAttribute).Name)
      
      ' Display all custom attribute of type 'MyAttribute'.
      Console.WriteLine(ControlChars.NewLine + "Displaying all attributes of type 'MyAttribute'" + _
                 ControlChars.NewLine)
      Dim attributes As Object() = myLogicalMethodInfo.GetCustomAttributes(GetType(MyAttribute))
      Dim i As Integer
      For i = 0 To attributes.Length - 1
         Console.WriteLine(CType(attributes(i), MyAttribute).Name)
      Next i 
      ' Display all return attributes of type 'MyAttribute'.
      Console.WriteLine(ControlChars.NewLine + "Displaying all return attributes of type 'MyAttribute'" + _
                 ControlChars.NewLine)
      Dim myCustomAttributeProvider As ICustomAttributeProvider = _
                 myLogicalMethodInfo.ReturnTypeCustomAttributeProvider
      If myCustomAttributeProvider.IsDefined(GetType(MyAttribute), True) Then
         attributes = myCustomAttributeProvider.GetCustomAttributes(True)

         For i = 0 To attributes.Length - 1
            If attributes(i).GetType().Equals(GetType(MyAttribute)) Then
               Console.WriteLine(CType(attributes(i), MyAttribute).Name)
            End If
         Next i 
      End If ' Display all the custom attributes of type 'MyAttribute'.
      Console.WriteLine(ControlChars.NewLine + "Displaying all attributes of type 'MyAttribute'" + _
                 ControlChars.NewLine)
      myCustomAttributeProvider = myLogicalMethodInfo.CustomAttributeProvider
      If myCustomAttributeProvider.IsDefined(GetType(MyAttribute), True) Then
         attributes = myCustomAttributeProvider.GetCustomAttributes(True)

         For i = 0 To attributes.Length - 1
            If attributes(i).GetType().Equals(GetType(MyAttribute)) Then
               Console.WriteLine(CType(attributes(i), MyAttribute).Name)
            End If
         Next i
      End If
   End Sub 'Main 
End Class 'LogicalMethodInfo_GetCustomAttribute
' </Snippet4>