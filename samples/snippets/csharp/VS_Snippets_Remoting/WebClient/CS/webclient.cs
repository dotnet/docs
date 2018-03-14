using System;
using System.Net;
using System.Text;
using System.Collections.Specialized;

public class WebClientSample
{
    public static void Main()
    {
    	//<snippet1>
        try {
			
		// Download the data to a buffer.
	       	WebClient client = new WebClient();

  		Byte[] pageData = client.DownloadData("http://www.contoso.com");
		string pageHtml = Encoding.ASCII.GetString(pageData);
		Console.WriteLine(pageHtml);

		// Download the data to a file.
	        	client.DownloadFile("http://www.contoso.com", "page.htm");

		// Upload some form post values.
		NameValueCollection form = new NameValueCollection();		
		form.Add("MyName", "MyValue");		
		Byte[] responseData = client.UploadValues("http://www.contoso.com/form.aspx", form);		

        }
        catch (WebException webEx) {
          	Console.WriteLine(webEx.ToString());
           	if(webEx.Status == WebExceptionStatus.ConnectFailure) {
           		Console.WriteLine("Are you behind a firewall?  If so, go through the proxy server.");
           	}
        }
        //</snippet1>
    }        
}





