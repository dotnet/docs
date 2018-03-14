/*
   This program demonstrates 'GetCredential' method of 'ICredentials' interface.
   The 'CredentialList' class implements 'ICredentials' interface which stores credentials for multiple 
   internet resources.The Program takes URL, Username, Password and Domain name from commandline and adds 
   it to an instance of 'CredentialList' class.An instance of 'WebRequest' class is obtained and 'Credentials'
   property of 'WebRequest' class is set to an instance of 'NetworkCredential' class obtained by calling 
   'GetCredential' method of 'CredentialList' class. Then it sends the request and obtains a response.
*/


namespace CrendentialSample
{
	using System;
	using System.Net;
	using System.Collections;

// <Snippet1>
	class CredentialList : ICredentials
	{
		class CredentialInfo
		{
			public Uri uriObj;
			public String authenticationType;
			public NetworkCredential networkCredentialObj;
      
			public CredentialInfo(Uri uriObj, String authenticationType, NetworkCredential networkCredentialObj)
			{
				this.uriObj = uriObj;
				this.authenticationType = authenticationType;
				this.networkCredentialObj = networkCredentialObj;
			}
		}

		private ArrayList arrayListObj;

		public CredentialList()
		{
			arrayListObj = new ArrayList();
		}

		public void Add (Uri uriObj, String authenticationType, NetworkCredential credential)
		{
			// Add a 'CredentialInfo' object into a list.
			arrayListObj.Add (new CredentialInfo(uriObj, authenticationType, credential));      
		}
		// Remove the 'CredentialInfo' object from the list that matches to the given 'Uri' and 'AuthenticationType'
		public void Remove (Uri uriObj, String authenticationType)
		{
			for(int index=0;index < arrayListObj.Count; index++)
			{
				CredentialInfo credentialInfo = (CredentialInfo)arrayListObj[index];
				if(uriObj.Equals(credentialInfo.uriObj)&& authenticationType.Equals(credentialInfo.authenticationType))
					arrayListObj.RemoveAt(index);
			}
		}
		public NetworkCredential GetCredential (Uri uriObj, String authenticationType)
		{
			for(int index=0;index < arrayListObj.Count; index++)
			{
				CredentialInfo credentialInfoObj = (CredentialInfo)arrayListObj[index];
				if(uriObj.Equals(credentialInfoObj.uriObj) && authenticationType.Equals(credentialInfoObj.authenticationType))
					return credentialInfoObj.networkCredentialObj;
			}
			return null;
		}
	};
// </Snippet1>

	// The 'CredentialTest' is defined to test the 'CredentialList' class.
	class CredentialTest
	{
		public static void Main()
		{
			string urlString, username, password, domainname;
			Console.Write("Enter a URL(for e.g. http://www.microsoft.com : ");
			urlString = Console.ReadLine();
			Console.Write("Enter User name : ");
			username = Console.ReadLine();
			Console.Write("Enter Password :");
			password = Console.ReadLine();
			Console.Write("Enter Domain name : ");
			domainname = Console.ReadLine();
			GetPage(urlString, username, password, domainname);
		}
	
		public static void GetPage(string urlString, string UserName, string password, string DomainName)
		{
			try 
			{
				CredentialList credentialListObj = new CredentialList();
				// Dummy names used as credentials.
				credentialListObj.Add(new Uri(urlString), "Basic", new NetworkCredential(UserName, password, DomainName));
				credentialListObj.Add(new Uri("http://www.msdn.microsoft.com"), "Basic", new NetworkCredential("User1", "Passwd1","Domain1"));
				// Create a 'WebRequest' for the specified url. 
				WebRequest myWebRequest = WebRequest.Create(urlString); 
				// Call 'GetCredential' to obtain the credentials specific to a Uri.
				myWebRequest.Credentials = credentialListObj.GetCredential(new Uri(urlString), "Basic");

				// Send the request and get the  response.
				WebResponse myWebResponse = myWebRequest.GetResponse(); 
				// ....Process the response here.
				Console.WriteLine("\n Response Received.");
				myWebResponse.Close();
			}
			catch(WebException e) 
			{
				Console.WriteLine("WebException caught !!!");
				Console.WriteLine("Message : " + e.Message);
			}
			catch(Exception e) 
			{
				Console.WriteLine("Exception caught !!!");
				Console.WriteLine("Message : " + e.Message);
			}
		}
	}
}
