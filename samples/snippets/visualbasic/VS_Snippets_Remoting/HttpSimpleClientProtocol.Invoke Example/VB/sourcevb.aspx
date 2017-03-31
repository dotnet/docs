
'<Snippet2>
<%@ Page Language="VB" %>
<html>
    <script language="VB" runat="server">
    Sub EnterBtn_Click(Src As Object, E As EventArgs)
        Dim math As New Math()
        
        ' Call to Add XML Web service method.
        Dim result As Integer = math.Add(Convert.ToInt32(Num1.Text),Convert.ToInt32(Num2.Text))
        
        Total.Text = "Total: " & result.ToString()
    End Sub 'EnterBtn_Click
 
  </script>
 
    <body>
       <form action="MathClient.aspx" runat=server>
           
          Enter the two numbers you want to add and then press the Total button.
          <p>
          Number 1: <asp:textbox id="Num1" runat=server/>  +
          Number 2: <asp:textbox id="Num2" runat=server/> =
          <asp:button text="Total" Onclick="EnterBtn_Click" runat=server/>
          <p>
          <asp:label id="Total"  runat=server/>
          
       </form>
    </body>
 </html>
'</Snippet2>


<script runat="server">

    Public Class Math
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        <System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.Url = "http://www.contoso.com/math.asmx"
        End Sub
        
        <System.Diagnostics.DebuggerStepThroughAttribute(),  _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Add(ByVal num1 As Integer, ByVal num2 As Integer) As Integer
            Dim results() As Object = Me.Invoke("Add", New Object() {num1, num2})
            Return CType(results(0),Integer)
        End Function
        
        <System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Function BeginAdd(ByVal num1 As Integer, ByVal num2 As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Add", New Object() {num1, num2}, callback, asyncState)
        End Function
        
        <System.Diagnostics.DebuggerStepThroughAttribute()>  _
        Public Function EndAdd(ByVal asyncResult As System.IAsyncResult) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Integer)
        End Function
    End Class
</script>