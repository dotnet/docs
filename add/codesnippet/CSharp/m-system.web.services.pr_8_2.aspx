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