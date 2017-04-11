' All the following have been marked as 1 snippet : Snippet1

' System.Web.Services.Protocols.LogicalMethodInfo.Create(MethodInfo)
' System.Web.Services.Protocols.LogicalMethodInfo.Name
' System.Web.Services.Protocols.LogicalMethodInfo.InParameters
' System.Web.Services.Protocols.LogicalMethodInfo.OutParameters
' System.Web.Services.Protocols.LogicalMethodInfo.IsVoid

'  This following example demonstrates the 'Name',
'  'InParameters', 'OutParameters', 'IsVoid' properties and 
'  'Create(MethodInfo)' method of the 'LogicalMethodInfo' class. 
'  This example displays the parameters, the in parameters and 
'  out parameters.
'  
'  Note : The 'LogicalMethodInfo' class should only be used with
'  'SoapMessage'. 'SoapClientMessage' and 'SoapServerMessage' contain
'  a property named 'MethodInfo' which provides for an instance of
'  'LogicalMethodInfo'. If you are interested only in the reflection
'  of a type then use the 'System.Reflection' namespace and not this
'  class. This class gives information about the method invoked for
'  a web service and hence should only be used as such. For example
'  purposes it is being showed in a more simplified scenario.


' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic

Public Class MyService
   
   Public Sub MyMethod(inParameter As Integer, ByRef outParameter As Integer)
      outParameter = inParameter
   End Sub 'MyMethod
End Class 'MyService

Public Class LogicalMethodInfo_Create
   
   Public Shared Sub Main()
      Dim myType As Type = GetType(MyService)
      Dim myMethodInfo As MethodInfo = myType.GetMethod("MyMethod")
      Dim myLogicalMethodInfo As LogicalMethodInfo = _
                             LogicalMethodInfo.Create(New MethodInfo() {myMethodInfo})(0)
      
      Console.WriteLine _
        (ControlChars.Newline + "Printing parameters for the method : {0}", myLogicalMethodInfo.Name)
      
      Console.WriteLine _
        (ControlChars.Newline + "The parameters of the method {0} are :" + _
                                           ControlChars.Newline, myLogicalMethodInfo.Name)
      Dim myParameters As ParameterInfo() = myLogicalMethodInfo.Parameters
      Dim i As Integer
      For i = 0 To myParameters.Length - 1
         Console.WriteLine _
         (ControlChars.Tab + myParameters(i).Name + " : " + myParameters(i).ParameterType.toString())
      Next i
      
      Console.WriteLine _
          (ControlChars.Newline + "The in parameters of the method {0} are :" + _
                                               ControlChars.Newline, myLogicalMethodInfo.Name)
      myParameters = myLogicalMethodInfo.InParameters

      For i = 0 To myParameters.Length - 1
         Console.WriteLine(ControlChars.Tab + myParameters(i).Name + " : " + _
                                                   myParameters(i).ParameterType.toString())
      Next i
      
      Console.WriteLine(ControlChars.Newline + "The out parameters of the method {0} are :" + _
                                                    ControlChars.Newline, myLogicalMethodInfo.Name)
      myParameters = myLogicalMethodInfo.OutParameters

      For i = 0 To myParameters.Length - 1
         Console.WriteLine(ControlChars.Tab + myParameters(i).Name + " : " + _
                                                     myParameters(i).ParameterType.toString())
      Next i
      
      If myLogicalMethodInfo.IsVoid Then
         Console.WriteLine(ControlChars.Newline + "The return type is void")
      Else
         Console.WriteLine _
             (ControlChars.Newline + "The return type is {0}", myLogicalMethodInfo.ReturnType)
      End If
   End Sub 'Main 
End Class 'LogicalMethodInfo_Create
' </Snippet1>