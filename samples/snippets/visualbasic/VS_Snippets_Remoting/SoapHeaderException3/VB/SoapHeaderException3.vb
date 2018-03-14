
'   This program is just used to show a client proxy which helps 
'   accessing a web service.

Imports System
Imports System.Web.Services.Protocols

Public Class MySoapHeader
   Inherits SoapHeader
   Public number As Integer
End Class 'MySoapHeader

<System.Web.Services.WebServiceBindingAttribute(Name := "MathSvcSoap", _
 Namespace := "http://tempuri.org/")>  _
Public Class MathSvc
   Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
   Public mySoapHeader As MySoapHeader

   <SoapHeaderAttribute("mySoapHeader", Direction := SoapHeaderDirection.In), _
   System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", _
   Use := System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle := _
   System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
   Public Function Add(xValue As System.Single, yValue As System.Single) As System.Single
      mySoapHeader = New MySoapHeader()
      mySoapHeader.number = 0
      Dim results As Object() = Me.Invoke("Add", New Object() {xValue, yValue})
      Return CType(results(0), System.Single)
   End Function 'Add

   <System.Diagnostics.DebuggerStepThroughAttribute()>  _
   Public Sub New()
      Me.Url = "http://localhost/MathSvc_SoapHeaderException3.vb.asmx"
   End Sub 'New

   Public Function BeginAdd(xValue As System.Single, yValue As System.Single, _
      callback As System.AsyncCallback, asyncState As Object) As System.IAsyncResult
      Return Me.BeginInvoke("Add", New Object() {xValue, yValue}, callback, asyncState)
   End Function 'BeginAdd

   Public Function EndAdd(asyncResult As System.IAsyncResult) As System.Single
      Dim results As Object() = Me.EndInvoke(asyncResult)
      Return CType(results(0), System.Single)
   End Function 'EndAdd
End Class 'MathSvc