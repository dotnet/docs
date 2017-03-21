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
      Dim myType As Type = GetType(MyService)
      Dim myMethodInfo As MethodInfo = myType.GetMethod("Add")
      ' Create a synchronous 'LogicalMethodInfo' instance.
      Dim myLogicalMethodInfo As LogicalMethodInfo = _
                 LogicalMethodInfo.Create(New MethodInfo() {myMethodInfo}, LogicalMethodTypes.Sync)(0)
      ' Display the method for which the attributes are being displayed.
      Console.WriteLine(ControlChars.NewLine + "Displaying the attributes for the method : {0}" + _
                 ControlChars.NewLine, myLogicalMethodInfo.MethodInfo.ToString())
      
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