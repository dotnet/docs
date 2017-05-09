<!-- The following import statements support the standin below -->
<%@ Import Namespace="System.Web.Services" %>
<%@ Import Namespace="System.Web.Services.Protocols" %>
<!--<Snippet1> -->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Net" %>

<html>

    <script runat=server>

        Public Sub EnterBtn_Click(src As Object, E As EventArgs) 

	  ' Create a new instance of a proxy class for your XML Web service.
	  Dim su As ServerUsage = new ServerUsage()
          Dim cookieJar As CookieContainer

	  ' Check to see if the cookies have already been saved for this session.
	  If (Session("CookieJar") Is Nothing) 
	    cookieJar= new CookieContainer()
          Else
	   cookieJar = Session("CookieJar")
	  End If
   

		' Assign the CookieContainer to the proxy class.
		su.CookieContainer = cookieJar

	  ' Invoke an XML Web service method that uses session state and thus cookies.
	  Dim count As Integer = su.PerSessionServiceUsage()         

	  ' Store the cookies received in the session state for future retrieval by this session.
	  Session("CookieJar") = cookieJar

          ' Populate the text box with the results from the call to the XML Web service method.
          SessionCount.Text = count.ToString()  
	End Sub
         
    </script>
    <body>
       <form runat=server ID="Form1">
           
             Click to bump up the Session Counter.
             <p>
             <asp:button text="Bump Up Counter" Onclick="EnterBtn_Click" runat=server ID="Button1" NAME="Button1"/>
             <p>
             <asp:label id="SessionCount"  runat=server/>
          
       </form>
    </body>
</html>
<!--</Snippet1> -->

<!-- The following code is used as a stand-in for compilation purposes.  Please
	 see the associated .asmx file for the real code. To run the code above in 
	 a full environment, comment out the code below. -->
<script runat=server>

Public Class ServerUsage
    Inherits HttpWebClientProtocol
    
    Public Function ServiceUsage() As Integer
        Return 1
    End Function    
    
    Public Function PerSessionServiceUsage() As Integer
        Return 1
    End Function
End Class
</script>