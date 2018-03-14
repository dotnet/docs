' All the following have been marked as 1 snippet : Snippet1

' System.Web.Services.Protocols.LogicalMethodInfo.LogicalMethodInfo(MethodInfo)
' System.Web.Services.Protocols.LogicalMethodInfo.DeclaringType
' System.Web.Services.Protocols.LogicalMethodInfo.Parameters
' System.Web.Services.Protocols.LogicalMethodInfo.ReturnType
' System.Web.Services.Protocols.LogicalMethodInfo.Invoke(object, object[])
' System.Web.Services.Protocols.LogicalMethodInfo.ToString()

' This following example demonstrates the constructor, 'DeclaringType',
' 'Parameters', 'ReturnType' properties and 'Invoke(object, object[])',
' 'ToString()' methods of the 'LogicalMethodInfo' class. This example
' displays the declaring type, parameters, return type of a method
' named 'Add' in the class named 'MyService'.

' Note : The 'LogicalMethodInfo' class should only be used with
' 'SoapMessage'. 'SoapClientMessage' and 'SoapServerMessage' contain
' a property named 'MethodInfo' which provides for an instance of
' 'LogicalMethodInfo'. If you are interested only in the reflection
' of a type then use the 'System.Reflection' namespace and not this
' class. This class gives information about the method invoked for
' a web service and hence should only be used as such. For example
' purposes it is being showed in a more simplified scenario.

' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Security.Permissions
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic

Public Class MyService
   
   Public Function Add(xValue As Integer, yValue As Integer) As Integer
      Return xValue + yValue
   End Function 'Add
End Class 'MyService

Class LogicalMethodInfo_Constructor

<PermissionSetAttribute(SecurityAction.Demand, Name := "FullTrust")>  _
   Shared Sub Run()
      Dim myType As Type = GetType(MyService)
      Dim myMethodInfo As MethodInfo = myType.GetMethod("Add")
      Dim myLogicalMethodInfo As New LogicalMethodInfo(myMethodInfo)
      
      Console.WriteLine(ControlChars.NewLine + "Printing properties of method : {0}" + _
                              ControlChars.NewLine, myLogicalMethodInfo.ToString())
      
      Console.WriteLine(ControlChars.NewLine + "The declaring type of the method {0} is :" + _
                                    ControlChars.NewLine, myLogicalMethodInfo.Name)
      Console.WriteLine(ControlChars.Tab + myLogicalMethodInfo.DeclaringType.ToString())
      
      Console.WriteLine(ControlChars.NewLine + "The parameters of the method {0} are :" + _
                                    ControlChars.NewLine, myLogicalMethodInfo.Name)
      Dim myParameters As ParameterInfo() = myLogicalMethodInfo.Parameters
      Dim i As Integer
      For i = 0 To myParameters.Length - 1
         Console.WriteLine(ControlChars.Tab + myParameters(i).Name + " : " + _
                                                      myParameters(i).ParameterType.ToString())
      Next i
      
      Console.WriteLine(ControlChars.NewLine + "The return type of the method {0} is :" + _
                                             ControlChars.NewLine, myLogicalMethodInfo.Name)
      Console.WriteLine(ControlChars.Tab + myLogicalMethodInfo.ReturnType.ToString())
      
      Dim service As New MyService()
      Console.WriteLine(ControlChars.NewLine + "Invoking the method {0}" + _
                                                ControlChars.NewLine, myLogicalMethodInfo.Name)
      Console.WriteLine(ControlChars.Tab + "The sum of 10 and 10 is : {0}", _
                                    myLogicalMethodInfo.Invoke(service, New Object() {10, 10}))

   End Sub 'Run
   
   Shared Sub Main()
      Run()
   End Sub 'Main
End Class 'LogicalMethodInfo_Constructor
' </Snippet1>