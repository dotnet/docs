	public static void Main()
	{           
		try {

			WebClient client = new WebClient();

  			client.Credentials = CredentialCache.DefaultCredentials;
	
			Byte[] pageData = client.DownloadData("http://www.contoso.com");
			string pageHtml = Encoding.ASCII.GetString(pageData);
			Console.WriteLine(pageHtml);

		} catch (WebException webEx) {
			Console.Write(webEx.ToString());
		}
	}    