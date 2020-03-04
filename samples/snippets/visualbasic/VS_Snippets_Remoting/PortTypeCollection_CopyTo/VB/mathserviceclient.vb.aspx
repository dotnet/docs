<%@ Page Language="VB" Debug="true" %>
<html>
   <script language="VB" runat="server">

      Dim myFirstValue As Integer = 0
      Dim mySecValue As Integer = 0


      Public Sub Submit_Click(sender As Object, E As EventArgs)
         Try
            myFirstValue = Int32.Parse(myFirstTextBox.Text)
            mySecValue = Int32.Parse(mySecondTextBox.Text)
         Catch e1 As Exception
            Response.Write("Exception :" + e1.Message)
         End Try
         
         Dim service As New Math()
         
         
         Select Case CType(sender, Control).ID
            Case "Add"
               Result.Text = "<b>Result</b> = " + service.Add(myFirstValue, mySecValue).ToString()
            Case "Subtract"
               Result.Text = "<b>Result</b> = " + service.Subtract(myFirstValue, mySecValue). _
                                                                                       ToString()
            Case "Divide"
               Result.Text = "<b>Result</b> = " + service.Divide(myFirstValue, mySecValue). _
                                                                                       ToString()
         End Select
      End Sub 'Submit_Click 

   </script>
   <body style="font: 10pt verdana">
      <h4>
         Using a Simple Math Service
      </h4>
      <form runat="server">
         <div style="padding:15,15,15,15;background-color:beige;width:300;border-color:black;border-width:1;border-style:solid">
            First Number:
            <br>
            <asp:TextBox id="myFirstTextBox" Text="15" runat="server" />
            <br>
            Second Number:
            <br>
            <asp:TextBox id="mySecondTextBox" Text="5" runat="server" />
            <p>
               <input type="submit" id="Add" value="Add" OnServerClick="Submit_Click" runat="server">
               <input type="submit" id="Subtract" value="Subtract" OnServerClick="Submit_Click" runat="server">
               <input type="submit" id="Divide" value="Divide" OnServerClick="Submit_Click" runat="server">
            <p>
               <asp:Label id="Result" runat="server" />
         </div>
      </form>
   </body>
</html>
<script language="VB" runat=server>
Public Class Math
    Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
    
    
    <System.Diagnostics.DebuggerStepThroughAttribute()>  _
    Public Sub New() 
        Me.Url = "http://www.contoso.com/math.asmx"
    
    End Sub 'New
    
    
    <System.Diagnostics.DebuggerStepThroughAttribute(), System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use := System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle := System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
    Public Function Add(ByVal num1 As Integer, ByVal num2 As Integer) As Integer 
        Dim results As Object() = Me.Invoke("Add", New Object() {num1, num2})
        Return Fix(results(0))
    
    End Function 'Add
    
    <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use := System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle := System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
    Public Function Subtract(ByVal num1 As Integer, ByVal num2 As Integer) As Integer 
        Dim results As Object() = Me.Invoke("Subtract", New Object() {num1, num2})
        Return Fix(results(0))
    
    End Function 'Subtract
    
    <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use := System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle := System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
    Public Function Divide(ByVal num1 As Integer, ByVal num2 As Integer) As Integer 
        Dim results As Object() = Me.Invoke("Divide", New Object() {num1, num2})
        Return Fix(results(0))
    
    End Function 'Divide
    
    
    <System.Diagnostics.DebuggerStepThroughAttribute()>  _
    Public Function BeginAdd(ByVal num1 As Integer, ByVal num2 As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult 
        Return Me.BeginInvoke("Add", New Object() {num1, num2}, callback, asyncState)
    
    End Function 'BeginAdd
    
    
    <System.Diagnostics.DebuggerStepThroughAttribute()>  _
    Public Function EndAdd(ByVal asyncResult As System.IAsyncResult) As Integer 
        Dim results As Object() = Me.EndInvoke(asyncResult)
        Return Fix(results(0))
    
    End Function 'EndAdd
End Class 'Math
</script>