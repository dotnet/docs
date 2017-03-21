<System.Web.Services.WebServiceBindingAttribute(Name := "MathSvcSoap", _
    Namespace := "http://tempuri.org/")>  _
Public Class MathSvc
   Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
   Public mySoapHeaders() As SoapHeader

   <SoapHeaderAttribute("mySoapHeaders", _
      Direction := SoapHeaderDirection.In), _
   System.Web.Services.Protocols.SoapDocumentMethodAttribute( _
      "http://tempuri.org/Add", _
      Use := System.Web.Services.Description.SoapBindingUse.Literal, _
      ParameterStyle := System.Web.Services.Protocols.SoapParameterStyle.Wrapped), _
   MySoapExtensionAttribute()>  _
   Public Function Add(xValue As System.Single, yValue As System.Single) _
      As System.Single
      Dim mySoapHeaderCollection As New SoapHeaderCollection()
      Dim mySoapHeader As MySoapHeader
      mySoapHeader = New MySoapHeader()
      mySoapHeader.text = "This is the first SOAP header"
      mySoapHeaderCollection.Add(mySoapHeader)
      mySoapHeader = New MySoapHeader()
      mySoapHeader.text = "This is the second SOAP header"
      mySoapHeaderCollection.Add(mySoapHeader)
      mySoapHeader = New MySoapHeader()
      mySoapHeader.text = "This header is inserted before the first header"
      mySoapHeaderCollection.Insert(0, mySoapHeader)
      mySoapHeaders = New MySoapHeader(mySoapHeaderCollection.Count-1) {}
      mySoapHeaderCollection.CopyTo(mySoapHeaders, 0)
      Dim results() As Object = _
         Me.Invoke("Add", New Object() {xValue, yValue})
      Return CType(results(0), System.Single)
   End Function 'Add

   <System.Diagnostics.DebuggerStepThroughAttribute()>  _
   Public Sub New()
      Me.Url = "http://localhost/MathSvc_SoapHeaderCollection.vb.asmx"
   End Sub 'New

   Public Function BeginAdd(xValue As System.Single, yValue As System.Single, _
      callback As System.AsyncCallback, asyncState As Object) _
      As System.IAsyncResult
      Return Me.BeginInvoke("Add", New Object() {xValue, yValue}, _
         callback, asyncState)
   End Function 'BeginAdd

   Public Function EndAdd(asyncResult As System.IAsyncResult) As System.Single
      Dim results As Object() = Me.EndInvoke(asyncResult)
      Return CType(results(0), System.Single)
   End Function 'EndAdd
End Class 'MathSvc