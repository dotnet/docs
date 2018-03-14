<%@ Assembly Name="Source" %>
<%@ Import Namespace="MyMath" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="System.Xml.Serialization" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web.Services.Protocols" %>
<%@ Import Namespace="System.Web.Services" %>

//<Snippet2>
<%@ Page Language="C#" %>
<html>
    <script language="C#" runat="server">
       void EnterBtn_Click(Object Src, EventArgs E) 
          {
             MyMath.Math math = new MyMath.Math();
             // If the user types in a URL, attempt to dynamically bind to it.
             if (DiscoURL.Text != String.Empty)
                { 
                  math.Url = DiscoURL.Text;
                  try
                      { math.Discover();}
                  catch (Exception)
                      {
                        DiscoURL.Text = "Could not bind to MathSoap bindng at given URL.  ";
                      }
                }
 
         // Call the Add XML Web service method. 
         int total = math.Add(Convert.ToInt32(Num1.Text),Convert.ToInt32(Num2.Text));
             
             Total.Text = "Total: " + total.ToString();
         }
 
    </script>
 
    <body>
       <form action="MathClient.aspx" runat=server>
          
          Enter the URL of a disdovery document describing the MathSoap binding.
          <p> 
          <asp:textbox id="DiscoURL" runat=server Columns=80/>
          <p><p>
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
//</Snippet2>

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