<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<html>
    <script language="C#" runat="server">
       void EnterBtn_Click(Object Src, EventArgs E) 
          {
             MyMath.Math math = new MyMath.Math();
 
         // Call the Add XML Web service method asynchronously.
         IAsyncResult result = math.BeginAdd(Convert.ToInt32(Num1.Text), Convert.ToInt32(Num2.Text), null, null);
             
         // Wait for the asynchronous call to complete.
         result.AsyncWaitHandle.WaitOne();
 
         // Complete the asynchronous call to the Add XML Web service method.
         int total = math.EndAdd(result);
 
         Total.Text = "Total: " + total.ToString();
         }
 
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
<!-- </Snippet1> -->

