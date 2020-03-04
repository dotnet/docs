<%@ Page Language="C#" Debug="true" %>
<html>
   <script language="C#" runat="server">

  int myFirstValue = 0;
  int mySecValue= 0;

  public void Submit_Click(Object sender, EventArgs E)
  {
      try 
      {
        myFirstValue = Int32.Parse(myFirstTextBox.Text);
        mySecValue = Int32.Parse(mySecondTextBox.Text);
      }
      catch (Exception e) 
      { 
         Response.Write("Exception :" + e.Message); 
      }

      Math service = new Math();
 

        switch (((Control)sender).ID)
        {
          case "Add"      : Result.Text = "<b>Result</b> = " + service.Add(myFirstValue, mySecValue).ToString(); 
          break;
          case "Subtract" : Result.Text = "<b>Result</b> = " + service.Subtract(myFirstValue, mySecValue).ToString(); 
          break;
          case "Divide"   : Result.Text = "<b>Result</b> = " + service.Divide(myFirstValue, mySecValue).ToString(); 
          break;
          
        }
  }


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

<!-- The following code is used as a stand-in for compilation purposes.  Please
	 see the associated .asmx file for the real code. To run the code above in 
	 a full environment, comment out the code below. -->
<script language="C#" runat=server>
    public class Math : System.Web.Services.Protocols.SoapHttpClientProtocol 
    {
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        public Math() {
            this.Url = "http://www.contoso.com/math.asmx";
        }
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Add(int num1, int num2) {
            object[] results = this.Invoke("Add", new object[] {num1,
                        num2});
            return ((int)(results[0]));
        }
	[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Subtract(int num1, int num2) {
            object[] results = this.Invoke("Subtract", new object[] {num1,
                        num2});
            return ((int)(results[0]));
        }
      	[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Divide(int num1, int num2) {
            object[] results = this.Invoke("Divide", new object[] {num1,
                        num2});
            return ((int)(results[0]));
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        public System.IAsyncResult BeginAdd(int num1, int num2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Add", new object[] {num1,
                        num2}, callback, asyncState);
        }
        
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        public int EndAdd(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
    }
</script>