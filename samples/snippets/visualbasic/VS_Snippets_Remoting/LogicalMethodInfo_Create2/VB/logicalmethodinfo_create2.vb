' System.Web.Services.Protocols.LogicalMethodInfo.Create(MethodInfo[], LogicalMethodTypes)
' System.Web.Services.Protocols.LogicalMethodInfo.AsyncCallbackParameter
' System.Web.Services.Protocols.LogicalMethodInfo.AsyncStateParameter
' System.Web.Services.Protocols.LogicalMethodInfo.AsyncResultParameter

' System.Web.Services.Protocols.LogicalMethodInfo.BeginMethodInfo
' System.Web.Services.Protocols.LogicalMethodInfo.EndMethodInfo
' System.Web.Services.Protocols.LogicalMethodInfo.IsAsync
' System.Web.Services.Protocols.LogicalMethodTypes.Async

'   This following example demonstrates the 'AsyncCallbackParameter',
'   'AsyncResultParameter', 'AsyncStateParameter', 'BeginMethodInfo',
'   'EndMethodInfo', 'IsAsync' properties and 
'   'Create(MethodInfo[], LogicalMethodTypes)' method of the 
'   'LogicalMethodInfo' class and the 'Async' enum member of the 
'   'LogicalMethodTypes' enumeration. This example displays the callback,
'   result and state parameters for asynchronous methods. It also displays 
'   the begin and end for such asynchronous methods.
'   
'   Note : The 'LogicalMethodInfo' class should only be used with
'   'SoapMessage'. 'SoapClientMessage' and 'SoapServerMessage' contain
'   a property named 'MethodInfo' which provides for an instance of
'   'LogicalMethodInfo'. If you are interested only in the reflection
'   of a type then use the 'System.Reflection' namespace and not this
'   class. This class gives information about the method invoked for
'   a web service and hence should only be used as such. For example
'   purposes it is being showed in a more simplified scenario.

' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic

Public Class MyService
   Inherits SoapHttpClientProtocol
   
   Public Function BeginAdd _
       (xValue As Integer, yValue As Integer, callback As AsyncCallback, asyncState As Object) _
                                                                                    As IAsyncResult
      Return Me.BeginInvoke("Add", New Object() {xValue, yValue}, callback, asyncState)
   End Function 'BeginAdd
   
   Public Function EndAdd(asyncResult As System.IAsyncResult) As Integer
      Dim results As Object() = Me.EndInvoke(asyncResult)
      Return CInt(results(0))
   End Function 'EndAdd
End Class 'MyService

Public Class LogicalMethodInfo_Create
   
   Public Shared Sub Main()
      Dim myType As Type = GetType(MyService)
      Dim myBeginMethod As MethodInfo = myType.GetMethod("BeginAdd")
      Dim myEndMethod As MethodInfo = myType.GetMethod("EndAdd")
      Dim myLogicalMethodInfo As LogicalMethodInfo = _
          LogicalMethodInfo.Create(New MethodInfo() _
                          {myBeginMethod, myEndMethod}, LogicalMethodTypes.Async)(0)
      
      Console.WriteLine _
        (ControlChars.Newline + "The asynchronous callback parameter of method {0} is :" + _ 
                                             ControlChars.Newline, myLogicalMethodInfo.Name)
      Console.WriteLine _
        (ControlChars.Tab + myLogicalMethodInfo.AsyncCallbackParameter.Name + " : " + _
                    myLogicalMethodInfo.AsyncCallbackParameter.ParameterType.ToString())
      
      Console.WriteLine _
        (ControlChars.Newline + "The asynchronous state parameter of method {0} is :" + _
                                             ControlChars.Newline, myLogicalMethodInfo.Name)
      Console.WriteLine _
       (ControlChars.Tab + myLogicalMethodInfo.AsyncStateParameter.Name + " : " + _
                               myLogicalMethodInfo.AsyncStateParameter.ParameterType.ToString())
      
      Console.WriteLine _
       (ControlChars.Newline + "The asynchronous result parameter of method {0} is :" + _
                                                     ControlChars.Newline, myLogicalMethodInfo.Name)
      Console.WriteLine _
       (ControlChars.Tab + myLogicalMethodInfo.AsyncResultParameter.Name + " : " + _
                               myLogicalMethodInfo.AsyncResultParameter.ParameterType.ToString())
      
      Console.WriteLine _
        (ControlChars.Newline + "The begin method of the asynchronous method {0} is :" + _
                                             ControlChars.Newline, myLogicalMethodInfo.Name)
      Console.WriteLine(ControlChars.Tab + myLogicalMethodInfo.BeginMethodInfo.ToString())
      
      Console.WriteLine _
       (ControlChars.Newline + "The end method of the asynchronous method {0} is :" + _
                                                     ControlChars.Newline, myLogicalMethodInfo.Name)
      Console.WriteLine(ControlChars.Tab + myLogicalMethodInfo.EndMethodInfo.ToString())
      
      If myLogicalMethodInfo.IsAsync Then
         Console.WriteLine(ControlChars.Newline + "{0} is asynchronous", myLogicalMethodInfo.Name)
      Else
         Console.WriteLine(ControlChars.Newline + "{0} is synchronous", myLogicalMethodInfo.Name)
      End If 
   End Sub 'Main
End Class 'LogicalMethodInfo_Create
' </Snippet1>
